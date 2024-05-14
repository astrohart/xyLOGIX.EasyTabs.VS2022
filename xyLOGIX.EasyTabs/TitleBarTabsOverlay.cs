using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Timers;
using System.Windows.Forms;
using Win32Interop.Enums;
using Win32Interop.Methods;
using Win32Interop.Structs;
using Timer = System.Timers.Timer;

namespace xyLOGIX.EasyTabs
{
    /// <summary>
    /// Borderless overlay window that is moved with and rendered on top of the
    /// non-client area of a  <see cref="T:xyLOGIX.EasyTabs.TitleBarTabs" /> instance that's
    /// responsible
    /// for rendering the actual tab content and responding to click events for those
    /// tabs.
    /// </summary>
    public class TitleBarTabsOverlay : Form
    {
        protected static uint
            _doubleClickInterval = User32.GetDoubleClickTime();

        /// <summary>
        /// Flag indicating whether <see cref="F:xyLOGIX.EasyTabs.TitleBarTabsOverlay._hookproc" />
        /// has been installed as a hook.
        /// </summary>
        protected static bool _hookProcInstalled;

        /// <summary>
        /// All the parent forms and their overlays so that we don't create
        /// duplicate overlays across the application domain.
        /// </summary>
        protected static Dictionary<TitleBarTabs, TitleBarTabsOverlay>
            _parents = new Dictionary<TitleBarTabs, TitleBarTabsOverlay>();

        /// <summary>Tab that has been torn off from this window and is being dragged.</summary>
        protected static TitleBarTab _tornTab;

        /// <summary>
        /// Thumbnail representation of
        /// <see cref="F:xyLOGIX.EasyTabs.TitleBarTabsOverlay._tornTab" /> used when dragging.
        /// </summary>
        protected static TornTabForm _tornTabForm;

        /// <summary>
        /// Semaphore to control access to
        /// <see cref="F:xyLOGIX.EasyTabs.TitleBarTabsOverlay._tornTab" />.
        /// </summary>
        protected static object _tornTabLock = new object();

        /// <summary>
        /// Flag used in
        /// <see
        ///     cref="M:xyLOGIX.EasyTabs.TitleBarTabsOverlay.WndProc(System.Windows.Forms.Message@)" />
        /// and
        /// <see
        ///     cref="M:xyLOGIX.EasyTabs.TitleBarTabsOverlay.MouseHookCallback(System.Int32,System.IntPtr,System.IntPtr)" />
        /// to track whether the user was click/dragging when a particular event
        /// occurred.
        /// </summary>
        protected static bool _wasDragging;

        /// <summary>Flag indicating whether the underlying window is active.</summary>
        protected bool _active;

        /// <summary>
        /// Flag indicating whether we should draw the titlebar background (i.e.
        /// we are in a non-Aero environment).
        /// </summary>
        protected bool _aeroEnabled;

        /// <summary>
        /// When a tab is torn from the window, this is where we store the areas on all
        /// open windows where tabs can be dropped to combine the tab with that
        /// window.
        /// </summary>
        protected Tuple<TitleBarTabs, Rectangle>[] _dropAreas;

        protected bool _firstClick = true;

        /// <summary>
        /// Pointer to the low-level mouse hook callback (
        /// <see
        ///     cref="M:xyLOGIX.EasyTabs.TitleBarTabsOverlay.MouseHookCallback(System.Int32,System.IntPtr,System.IntPtr)" />
        /// ).
        /// </summary>
        protected IntPtr _hookId;

        /// <summary>
        /// Delegate of
        /// <see
        ///     cref="M:xyLOGIX.EasyTabs.TitleBarTabsOverlay.MouseHookCallback(System.Int32,System.IntPtr,System.IntPtr)" />
        /// ; declared as a member variable to keep it from being garbage collected.
        /// </summary>
        protected HOOKPROC _hookproc;

        protected bool _isOverAddButton = true;

        /// <summary>Index of the tab, if any, whose close button is being hovered over.</summary>
        protected int _isOverCloseButtonForTab = -1;

        protected bool _isOverSizingBox;
        protected long _lastLeftButtonClickTicks;
        protected Point[] _lastTwoClickCoordinates = new Point[2];

        /// <summary>
        /// Queue of mouse events reported by
        /// <see cref="F:xyLOGIX.EasyTabs.TitleBarTabsOverlay._hookproc" /> that need to be
        /// processed.
        /// </summary>
        protected BlockingCollection<MouseEvent> _mouseEvents =
            new BlockingCollection<MouseEvent>();

        /// <summary>
        /// Consumer thread for processing events in
        /// <see cref="F:xyLOGIX.EasyTabs.TitleBarTabsOverlay._mouseEvents" />.
        /// </summary>
        protected Thread _mouseEventsThread;

        /// <summary>Parent form for the overlay.</summary>
        protected TitleBarTabs _parentForm;

        protected bool _parentFormClosing;
        protected Timer showTooltipTimer;

        /// <summary>
        /// Blank default constructor to ensure that the overlays are only
        /// initialized through
        /// <see cref="M:xyLOGIX.EasyTabs.TitleBarTabsOverlay.GetInstance(xyLOGIX.EasyTabs.TitleBarTabs)" />
        /// .
        /// </summary>
        protected TitleBarTabsOverlay() { }

        /// <summary>
        /// Creates the overlay window and attaches it to
        /// <paramref name="parentForm" />.
        /// </summary>
        /// <param name="parentForm">
        /// Parent form that the overlay should be rendered on top
        /// of.
        /// </param>
        protected TitleBarTabsOverlay(TitleBarTabs parentForm)
        {
            _parentForm = parentForm;
            ShowInTaskbar = false;
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            MinimizeBox = false;
            MaximizeBox = false;
            _aeroEnabled = _parentForm.IsCompositionEnabled;
            Show(_parentForm);
            AttachHandlers();
            showTooltipTimer = new Timer { AutoReset = false };
            showTooltipTimer.Elapsed += ShowTooltipTimer_Elapsed;
        }

        /// <summary>
        /// Makes sure that the window is created with an
        /// <see cref="F:Win32Interop.Enums.WS_EX.WS_EX_LAYERED" /> flag set so that it can
        /// be alpha-blended properly with the content (
        /// <see cref="F:xyLOGIX.EasyTabs.TitleBarTabsOverlay._parentForm" />) underneath the
        /// overlay.
        /// </summary>
        protected override CreateParams CreateParams
        {
            get
            {
                var createParams = base.CreateParams;
                createParams.ExStyle |= 134742016;
                return createParams;
            }
        }

        /// <summary>Type of theme being used by the OS to render the desktop.</summary>
        protected DisplayType DisplayType
        {
            get
            {
                if (_aeroEnabled)
                    return DisplayType.Aero;
                return Application.RenderWithVisualStyles &&
                       Environment.OSVersion.Version.Major >= 6
                    ? DisplayType.Basic
                    : DisplayType.Classic;
            }
        }

        /// <summary>
        /// Screen area in which tabs can be dragged to and dropped for this
        /// window.
        /// </summary>
        public Rectangle TabDropArea
        {
            get
            {
                User32.GetWindowRect(_parentForm.Handle, out var rect);
                return new Rectangle(
                    rect.left + SystemInformation
                        .HorizontalResizeBorderThickness,
                    rect.top + SystemInformation.VerticalResizeBorderThickness,
                    ClientRectangle.Width,
                    _parentForm.NonClientAreaHeight - SystemInformation
                        .VerticalResizeBorderThickness
                );
            }
        }

        /// <summary>Primary color for the titlebar background.</summary>
        protected Color TitleBarColor
            => Application.RenderWithVisualStyles &&
               Environment.OSVersion.Version.Major >= 6
                ?
                !_active
                    ? SystemColors.GradientInactiveCaption
                    : SystemColors.GradientActiveCaption
                : !_active
                    ? SystemColors.InactiveCaption
                    : SystemColors.ActiveCaption;

        /// <summary>Gradient color for the titlebar background.</summary>
        protected Color TitleBarGradientColor
            => !_active
                ?
                !SystemInformation.IsTitleBarGradientEnabled
                    ? SystemColors.InactiveCaption
                    : SystemColors.GradientInactiveCaption
                : !SystemInformation.IsTitleBarGradientEnabled
                    ? SystemColors.ActiveCaption
                    : SystemColors.GradientActiveCaption;

        /// <summary>Retrieves or creates the overlay for <paramref name="parentForm" />.</summary>
        /// <param name="parentForm">Parent form that we are to create the overlay for.</param>
        /// <returns>
        /// Newly-created or previously existing overlay for
        /// <paramref name="parentForm" />.
        /// </returns>
        public static TitleBarTabsOverlay GetInstance(TitleBarTabs parentForm)
        {
            if (!_parents.ContainsKey(parentForm))
                _parents.Add(parentForm, new TitleBarTabsOverlay(parentForm));
            return _parents[parentForm];
        }

        /// <summary>Gets the relative location of the cursor within the overlay.</summary>
        /// <param name="cursorPosition">
        /// Cursor position that represents the absolute
        /// position of the cursor on the screen.
        /// </param>
        /// <returns>The relative location of the cursor within the overlay.</returns>
        public Point GetRelativeCursorPosition(Point cursorPosition)
            => new Point(
                cursorPosition.X - Location.X, cursorPosition.Y - Location.Y
            );

        /// <summary>
        /// Renders the tabs and then calls
        /// <see
        ///     cref="M:Win32Interop.Methods.User32.UpdateLayeredWindow(System.IntPtr,System.IntPtr,Win32Interop.Structs.POINT@,Win32Interop.Structs.SIZE@,System.IntPtr,Win32Interop.Structs.POINT@,System.UInt32,Win32Interop.Structs.BLENDFUNCTION@,Win32Interop.Enums.ULW)" />
        /// to blend the tab content with the underlying window (
        /// <see cref="F:xyLOGIX.EasyTabs.TitleBarTabsOverlay._parentForm" />).
        /// </summary>
        /// <param name="forceRedraw">
        /// Flag indicating whether a full render should be
        /// forced.
        /// </param>
        public void Render(bool forceRedraw = false)
            => Render(Cursor.Position, forceRedraw);

        /// <summary>
        /// Renders the tabs and then calls
        /// <see
        ///     cref="M:Win32Interop.Methods.User32.UpdateLayeredWindow(System.IntPtr,System.IntPtr,Win32Interop.Structs.POINT@,Win32Interop.Structs.SIZE@,System.IntPtr,Win32Interop.Structs.POINT@,System.UInt32,Win32Interop.Structs.BLENDFUNCTION@,Win32Interop.Enums.ULW)" />
        /// to blend the tab content with the underlying window (
        /// <see cref="F:xyLOGIX.EasyTabs.TitleBarTabsOverlay._parentForm" />).
        /// </summary>
        /// <param name="cursorPosition">Current position of the cursor.</param>
        /// <param name="forceRedraw">
        /// Flag indicating whether a full render should be
        /// forced.
        /// </param>
        public void Render(Point cursorPosition, bool forceRedraw = false)
        {
            if (IsDisposed || _parentForm.TabRenderer == null ||
                _parentForm.WindowState == FormWindowState.Minimized ||
                _parentForm.ClientRectangle.Width <= 0) return;

            cursorPosition = GetRelativeCursorPosition(cursorPosition);

            using (var bitmap = new Bitmap(
                       Width, Height, PixelFormat.Format32bppArgb
                   ))
            {
                using (var graphics = Graphics.FromImage(bitmap))
                {
                    DrawTitleBarBackground(graphics);

                    // Since classic mode themes draw over the *entire* titlebar, not just the area immediately behind the tabs, we have to offset the tabs
                    // when rendering in the window
                    var offset =
                        _parentForm.WindowState != FormWindowState.Maximized &&
                        DisplayType == DisplayType.Classic &&
                        !_parentForm.TabRenderer.RendersEntireTitleBar
                            ?
                            new Point(
                                0, SystemInformation.CaptionButtonSize.Height
                            )
                            : _parentForm.WindowState !=
                              FormWindowState.Maximized &&
                              !_parentForm.TabRenderer.RendersEntireTitleBar
                                ? new Point(
                                    0,
                                    SystemInformation
                                        .VerticalResizeBorderThickness -
                                    SystemInformation.BorderSize.Height
                                )
                                : new Point(0, 0);

                    // Render the tabs into the bitmap
                    _parentForm.TabRenderer.Render(
                        _parentForm.Tabs, graphics, offset, cursorPosition,
                        forceRedraw
                    );

                    // Cut out a hole in the background so that the control box on the underlying window can be shown
                    if (DisplayType == DisplayType.Classic &&
                        (_parentForm.ControlBox || _parentForm.MaximizeBox ||
                         _parentForm.MinimizeBox))
                    {
                        var boxWidth = 0;

                        if (_parentForm.ControlBox)
                            boxWidth += SystemInformation.CaptionButtonSize
                                .Width;

                        if (_parentForm.MinimizeBox)
                            boxWidth += SystemInformation.CaptionButtonSize
                                .Width;

                        if (_parentForm.MaximizeBox)
                            boxWidth += SystemInformation.CaptionButtonSize
                                .Width;

                        var oldCompositingMode = graphics.CompositingMode;

                        graphics.CompositingMode = CompositingMode.SourceCopy;
                        graphics.FillRectangle(
                            new SolidBrush(Color.Transparent), Width - boxWidth,
                            0, boxWidth,
                            SystemInformation.CaptionButtonSize.Height
                        );
                        graphics.CompositingMode = oldCompositingMode;
                    }

                    var screenDc = User32.GetDC(IntPtr.Zero);
                    var memDc = Gdi32.CreateCompatibleDC(screenDc);
                    var oldBitmap = IntPtr.Zero;
                    var bitmapHandle = IntPtr.Zero;

                    try
                    {
                        // Copy the contents of the bitmap into memDc
                        bitmapHandle = bitmap.GetHbitmap(Color.FromArgb(0));
                        oldBitmap = Gdi32.SelectObject(memDc, bitmapHandle);

                        var size = new SIZE
                        {
                            cx = bitmap.Width, cy = bitmap.Height
                        };

                        var pointSource = new POINT { x = 0, y = 0 };
                        var topPos = new POINT { x = Left, y = Top };
                        var blend = new BLENDFUNCTION
                        {
                            // We want to blend the bitmap content with the screen content under it
                            BlendOp = Convert.ToByte((int)AC.AC_SRC_OVER),
                            BlendFlags = 0,

                            // Follow the parent forms' opacity level
                            SourceConstantAlpha =
                                (byte)(_parentForm.Opacity * 255),

                            // We use the bitmap alpha channel for blending instead of a pre-defined transparency key
                            AlphaFormat = Convert.ToByte((int)AC.AC_SRC_ALPHA)
                        };

                        // Blend the tab content with the underlying content
                        if (!User32.UpdateLayeredWindow(
                                Handle, screenDc, ref topPos, ref size, memDc,
                                ref pointSource, 0, ref blend, ULW.ULW_ALPHA
                            ))
                        {
                            var error = Marshal.GetLastWin32Error();
                            throw new Win32Exception(
                                error,
                                "Error while calling UpdateLayeredWindow()."
                            );
                        }
                    }

                    // Clean up after ourselves
                    finally
                    {
                        User32.ReleaseDC(IntPtr.Zero, screenDc);

                        if (bitmapHandle != IntPtr.Zero)
                        {
                            Gdi32.SelectObject(memDc, oldBitmap);
                            Gdi32.DeleteObject(bitmapHandle);
                        }

                        Gdi32.DeleteDC(memDc);
                    }
                }
            }
        }

        /// <summary>
        /// Attaches the various event handlers to
        /// <see cref="F:xyLOGIX.EasyTabs.TitleBarTabsOverlay._parentForm" /> so that the overlay
        /// is moved in synchronization to
        /// <see cref="F:xyLOGIX.EasyTabs.TitleBarTabsOverlay._parentForm" />.
        /// </summary>
        protected void AttachHandlers()
        {
            FormClosing += TitleBarTabsOverlay_FormClosing;

            _parentForm.FormClosing += OnParentFormClosing;
            _parentForm.Disposed += OnDisposedParentForm;
            _parentForm.Deactivate += OnDeactivateParentForm;
            _parentForm.Activated += OnParentFormActivated;
            _parentForm.SizeChanged += OnParentFormRefresh;
            _parentForm.Shown += OnParentFormRefresh;
            _parentForm.VisibleChanged += OnParentFormRefresh;
            _parentForm.Move += OnParentFormRefresh;
            _parentForm.SystemColorsChanged += OnSystemColorsChangedParentForm;

            if (_hookproc != null) return;

            // Spin up a consumer thread to process mouse events from _mouseEvents
            _mouseEventsThread = new Thread(InterpretMouseEvents)
            {
                Name = "Low level mouse hooks processing thread",
                Priority = ThreadPriority.Highest
            };
            _mouseEventsThread.Start();

            using (var curProcess = Process.GetCurrentProcess())
            {
                using (var curModule = curProcess.MainModule)
                {
                    // Install the low level mouse hook that will put events into _mouseEvents
                    _hookproc = MouseHookCallback;
                    _hookId = User32.SetWindowsHookEx(
                        WH.WH_MOUSE_LL, _hookproc,
                        Kernel32.GetModuleHandle(curModule.ModuleName), 0
                    );
                }
            }
        }

        /// <summary>
        /// Draws the titlebar background behind the tabs if Aero glass is not
        /// enabled.
        /// </summary>
        /// <param name="graphics">Graphics context with which to draw the background.</param>
        protected virtual void DrawTitleBarBackground(Graphics graphics)
        {
            if (DisplayType == DisplayType.Aero)
                return;
            var rectangle = DisplayType != DisplayType.Basic
                ? new Rectangle(
                    new Point(1, 0), new Size(Width - 2, Height - 1)
                )
                : new Rectangle(
                    new Point(
                        1,
                        Top == 0
                            ? SystemInformation.CaptionHeight - 1
                            : SystemInformation.CaptionHeight +
                              SystemInformation.VerticalResizeBorderThickness -
                              (Top - _parentForm.Top) - 1
                    ), new Size(Width - 2, _parentForm.Padding.Top)
                );
            if (rectangle.Height <= 0)
                return;
            var width1 = 3;
            Size captionButtonSize;
            if (_parentForm.ControlBox && _parentForm.MinimizeBox)
            {
                var num = width1;
                captionButtonSize = SystemInformation.CaptionButtonSize;
                var width2 = captionButtonSize.Width;
                width1 = num + width2;
            }

            if (_parentForm.ControlBox && _parentForm.MaximizeBox)
            {
                var num = width1;
                captionButtonSize = SystemInformation.CaptionButtonSize;
                var width3 = captionButtonSize.Width;
                width1 = num + width3;
            }

            if (_parentForm.ControlBox)
            {
                var num = width1;
                captionButtonSize = SystemInformation.CaptionButtonSize;
                var width4 = captionButtonSize.Width;
                width1 = num + width4;
            }

            var linearGradientBrush = new LinearGradientBrush(
                new Point(24, 0), new Point(rectangle.Width - width1 + 1, 0),
                TitleBarColor, TitleBarGradientColor
            );
            using (var bufferedGraphics =
                   BufferedGraphicsManager.Current.Allocate(
                       graphics, rectangle
                   ))
            {
                bufferedGraphics.Graphics.FillRectangle(
                    new SolidBrush(TitleBarColor), rectangle
                );
                bufferedGraphics.Graphics.FillRectangle(
                    new SolidBrush(TitleBarGradientColor),
                    new Rectangle(
                        new Point(
                            rectangle.Location.X + rectangle.Width - width1,
                            rectangle.Location.Y
                        ), new Size(width1, rectangle.Height)
                    )
                );
                bufferedGraphics.Graphics.FillRectangle(
                    linearGradientBrush,
                    new Rectangle(
                        rectangle.Location,
                        new Size(rectangle.Width - width1, rectangle.Height)
                    )
                );
                bufferedGraphics.Graphics.FillRectangle(
                    new SolidBrush(TitleBarColor),
                    new Rectangle(
                        rectangle.Location, new Size(24, rectangle.Height)
                    )
                );
                bufferedGraphics.Render(graphics);
            }
        }

        /// <summary>
        /// Consumer method that processes mouse events in
        /// <see cref="F:xyLOGIX.EasyTabs.TitleBarTabsOverlay._mouseEvents" /> that are recorded by
        /// <see
        ///     cref="M:xyLOGIX.EasyTabs.TitleBarTabsOverlay.MouseHookCallback(System.Int32,System.IntPtr,System.IntPtr)" />
        /// .
        /// </summary>
        protected void InterpretMouseEvents()
        {
            foreach (var consuming in _mouseEvents.GetConsumingEnumerable())
            {
                var nCode = consuming.Code;
                var wParam = consuming.WParam;
                var mouseData = consuming.MouseData;
                Rectangle desktopBounds;
                if (nCode >= 0 && 512 == (int)wParam)
                {
                    HideTooltip();
                    var cursorPosition = new Point(
                        mouseData.Value.pt.x, mouseData.Value.pt.y
                    );
                    var flag = false;
                    if (_tornTab != null && _dropAreas != null)
                    {
                        for (var index = 0; index < _dropAreas.Length; ++index)
                        {
                            desktopBounds = _dropAreas[index].Item2;
                            if (desktopBounds.Contains(cursorPosition))
                            {
                                TitleBarTab tabToCombine = null;
                                lock (_tornTabLock)
                                {
                                    if (_tornTab != null)
                                    {
                                        tabToCombine = _tornTab;
                                        _tornTab = null;
                                    }
                                }

                                if (tabToCombine != null)
                                {
                                    var i1 = index;
                                    BeginInvoke(
                                        new Action(
                                            () =>
                                            {
                                                _dropAreas[i1]
                                                    .Item1.TabRenderer
                                                    .CombineTab(
                                                        tabToCombine,
                                                        cursorPosition
                                                    );
                                                tabToCombine = null;
                                                _tornTabForm.Close();
                                                _tornTabForm = null;
                                                if (_parentForm.Tabs.Count != 0)
                                                    return;
                                                _parentForm.Close();
                                            }
                                        )
                                    );
                                }
                            }
                        }
                    }
                    else if (!_parentForm.TabRenderer.IsTabRepositioning)
                    {
                        StartTooltipTimer();
                        var relativeCursorPosition =
                            GetRelativeCursorPosition(cursorPosition);
                        if (_isOverCloseButtonForTab != -1 &&
                            (_isOverCloseButtonForTab >=
                             _parentForm.Tabs.Count ||
                             !_parentForm.TabRenderer.IsOverCloseButton(
                                 _parentForm.Tabs[_isOverCloseButtonForTab],
                                 relativeCursorPosition
                             )))
                        {
                            flag = true;
                            _isOverCloseButtonForTab = -1;
                        }
                        else
                        {
                            for (var index = 0;
                                 index < _parentForm.Tabs.Count;
                                 ++index)
                                if (_parentForm.TabRenderer.IsOverCloseButton(
                                        _parentForm.Tabs[index],
                                        relativeCursorPosition
                                    ))
                                {
                                    _isOverCloseButtonForTab = index;
                                    flag = true;
                                    break;
                                }
                        }

                        if (_isOverCloseButtonForTab == -1 && _parentForm
                                .TabRenderer.RendersEntireTitleBar)
                        {
                            if (_parentForm.TabRenderer.IsOverSizingBox(
                                    relativeCursorPosition
                                ))
                            {
                                _isOverSizingBox = true;
                                flag = true;
                            }
                            else if (_isOverSizingBox)
                            {
                                _isOverSizingBox = false;
                                flag = true;
                            }
                        }

                        if (_parentForm.TabRenderer.IsOverAddButton(
                                relativeCursorPosition
                            ))
                        {
                            _isOverAddButton = true;
                            flag = true;
                        }
                        else if (_isOverAddButton)
                        {
                            _isOverAddButton = false;
                            flag = true;
                        }
                    }
                    else
                    {
                        BeginInvoke(
                            new Action(
                                () =>
                                {
                                    _wasDragging = true;
                                    var tabDropArea = TabDropArea;
                                    tabDropArea.Inflate(
                                        _parentForm.TabRenderer
                                                   .TabTearDragDistance,
                                        _parentForm.TabRenderer
                                                   .TabTearDragDistance
                                    );
                                    if (tabDropArea.Contains(cursorPosition) ||
                                        _tornTab != null)
                                        return;
                                    lock (_tornTabLock)
                                    {
                                        if (_tornTab == null)
                                        {
                                            _parentForm.TabRenderer
                                                .IsTabRepositioning = false;
                                            _tornTab = _parentForm.SelectedTab;
                                            _tornTab.ClearSubscriptions();
                                            _tornTabForm = new TornTabForm(
                                                _tornTab,
                                                _parentForm.TabRenderer
                                            );
                                        }
                                    }

                                    if (_tornTab == null)
                                        return;
                                    _parentForm.SelectedTabIndex =
                                        _parentForm.SelectedTabIndex ==
                                        _parentForm.Tabs.Count - 1
                                            ? _parentForm.SelectedTabIndex - 1
                                            : _parentForm.SelectedTabIndex + 1;
                                    _parentForm.Tabs.Remove(_tornTab);
                                    if (_parentForm.Tabs.Count == 0)
                                        _parentForm.Hide();
                                    _tornTabForm.Show();
                                    _dropAreas = _parentForm.ApplicationContext
                                        .OpenWindows
                                        .Where(w => w.Tabs.Count > 0)
                                        .Select(
                                            window
                                                => new Tuple<TitleBarTabs,
                                                    Rectangle>(
                                                    window, window.TabDropArea
                                                )
                                        )
                                        .ToArray();
                                }
                            )
                        );
                    }

                    BeginInvoke(
                        new Action(
                            () => OnMouseMove(
                                new MouseEventArgs(
                                    MouseButtons.None, 0, cursorPosition.X,
                                    cursorPosition.Y, 0
                                )
                            )
                        )
                    );
                    if (_parentForm.TabRenderer.IsTabRepositioning)
                        flag = true;
                    if (flag)
                        BeginInvoke(
                            new Action(() => Render(cursorPosition, true))
                        );
                }
                else if (nCode >= 0 && 515 == (int)wParam)
                {
                    desktopBounds = DesktopBounds;
                    if (desktopBounds.Contains(_lastTwoClickCoordinates[0]))
                    {
                        desktopBounds = DesktopBounds;
                        if (desktopBounds.Contains(_lastTwoClickCoordinates[1]))
                            BeginInvoke(
                                new Action(
                                    () => _parentForm.WindowState =
                                        _parentForm.WindowState ==
                                        FormWindowState.Maximized
                                            ? FormWindowState.Normal
                                            : FormWindowState.Maximized
                                )
                            );
                    }
                }
                else if (nCode >= 0 && 513 == (int)wParam)
                {
                    if (!_firstClick)
                        _lastTwoClickCoordinates[1] =
                            _lastTwoClickCoordinates[0];
                    _lastTwoClickCoordinates[0] = Cursor.Position;
                    _firstClick = false;
                    _wasDragging = false;
                }
                else if (nCode >= 0 && 514 == (int)wParam)
                {
                    if (_tornTab != null)
                    {
                        TitleBarTab tabToRelease = null;
                        lock (_tornTabLock)
                        {
                            if (_tornTab != null)
                            {
                                tabToRelease = _tornTab;
                                _tornTab = null;
                            }
                        }

                        if (tabToRelease != null)
                            BeginInvoke(
                                new Action(
                                    () =>
                                    {
                                        var instance =
                                            (TitleBarTabs)Activator
                                                .CreateInstance(
                                                    _parentForm.GetType()
                                                );
                                        if (instance.WindowState ==
                                            FormWindowState.Maximized)
                                        {
                                            var screen =
                                                Screen.AllScreens.First(
                                                    s => s.WorkingArea.Contains(
                                                        Cursor.Position
                                                    )
                                                );
                                            instance.StartPosition =
                                                FormStartPosition.Manual;
                                            instance.WindowState =
                                                FormWindowState.Normal;
                                            instance.Left =
                                                screen.WorkingArea.Left;
                                            instance.Top =
                                                screen.WorkingArea.Top;
                                            instance.Width =
                                                screen.WorkingArea.Width;
                                            instance.Height =
                                                screen.WorkingArea.Height;
                                        }
                                        else
                                        {
                                            instance.Left = Cursor.Position.X;
                                            instance.Top = Cursor.Position.Y;
                                        }

                                        tabToRelease.Parent = instance;
                                        _parentForm.ApplicationContext
                                                   .OpenWindow(instance);
                                        instance.Show();
                                        instance.Tabs.Add(tabToRelease);
                                        instance.SelectedTabIndex = 0;
                                        instance.ResizeTabContents();
                                        _tornTabForm.Close();
                                        _tornTabForm = null;
                                        if (_parentForm.Tabs.Count != 0)
                                            return;
                                        _parentForm.Close();
                                    }
                                )
                            );
                    }

                    BeginInvoke(
                        new Action(
                            () =>
                            {
                                var position = Cursor.Position;
                                var x = position.X;
                                position = Cursor.Position;
                                var y = position.Y;
                                OnMouseUp(
                                    new MouseEventArgs(
                                        MouseButtons.Left, 1, x, y, 0
                                    )
                                );
                            }
                        )
                    );
                }
            }
        }

        /// <summary>
        /// Hook callback to process
        /// <see cref="F:Win32Interop.Enums.WM.WM_MOUSEMOVE" /> messages to
        /// highlight/un-highlight the close button on each tab.
        /// </summary>
        /// <param name="nCode">The message being received.</param>
        /// <param name="wParam">Additional information about the message.</param>
        /// <param name="lParam">Additional information about the message.</param>
        /// <returns>
        /// A zero value if the procedure processes the message; a nonzero value
        /// if the procedure ignores the message.
        /// </returns>
        protected IntPtr MouseHookCallback(
            int nCode,
            IntPtr wParam,
            IntPtr lParam
        )
        {
            var mouseEvent = new MouseEvent
            {
                Code = nCode, WParam = wParam, LParam = lParam
            };
            if (nCode >= 0 && 512 == (int)wParam)
                mouseEvent.MouseData = (MSLLHOOKSTRUCT)Marshal.PtrToStructure(
                    lParam, typeof(MSLLHOOKSTRUCT)
                );
            _mouseEvents.Add(mouseEvent);
            if (nCode >= 0 && 513 == (int)wParam)
            {
                var ticks = DateTime.Now.Ticks;
                if (_lastLeftButtonClickTicks > 0L &&
                    ticks - _lastLeftButtonClickTicks <
                    _doubleClickInterval * 10000U)
                    _mouseEvents.Add(
                        new MouseEvent
                        {
                            Code = nCode,
                            WParam = new IntPtr(515),
                            LParam = lParam
                        }
                    );
                _lastLeftButtonClickTicks = ticks;
            }

            return User32.CallNextHookEx(_hookId, nCode, wParam, lParam);
        }

        /// <summary>
        /// Sets the position of the overlay window to match that of
        /// <see cref="F:xyLOGIX.EasyTabs.TitleBarTabsOverlay._parentForm" /> so that it moves in
        /// tandem with it.
        /// </summary>
        protected void OnPosition()
        {
            if (IsDisposed)
                return;
            var systemMetrics = DisplayType == DisplayType.Classic
                ? 0
                : User32.GetSystemMetrics(92);
            var top = _parentForm.Top;
            Size size;
            int num1;
            if (DisplayType != DisplayType.Classic)
            {
                if (_parentForm.WindowState != FormWindowState.Maximized)
                {
                    if (!_parentForm.TabRenderer.RendersEntireTitleBar)
                    {
                        num1 = systemMetrics;
                    }
                    else if (!_parentForm.TabRenderer.IsWindows10)
                    {
                        num1 = 0;
                    }
                    else
                    {
                        size = SystemInformation.BorderSize;
                        num1 = size.Width;
                    }
                }
                else
                {
                    num1 = SystemInformation.VerticalResizeBorderThickness +
                           systemMetrics;
                }
            }
            else
            {
                num1 = SystemInformation.VerticalResizeBorderThickness;
            }

            Top = top + num1;
            var num2 = _parentForm.Left +
                       SystemInformation.HorizontalResizeBorderThickness;
            int num3;
            if (!_parentForm.TabRenderer.IsWindows10)
            {
                size = SystemInformation.BorderSize;
                num3 = size.Width;
            }
            else
            {
                num3 = 0;
            }

            Left = num2 - num3 + systemMetrics;
            var num4 = _parentForm.Width -
                       (SystemInformation.VerticalResizeBorderThickness +
                        systemMetrics) * 2;
            int num5;
            if (!_parentForm.TabRenderer.IsWindows10)
            {
                size = SystemInformation.BorderSize;
                num5 = size.Width * 2;
            }
            else
            {
                num5 = 0;
            }

            Width = num4 + num5;
            var tabHeight = _parentForm.TabRenderer.TabHeight;
            int num6;
            if (DisplayType != DisplayType.Classic ||
                _parentForm.WindowState == FormWindowState.Maximized ||
                _parentForm.TabRenderer.RendersEntireTitleBar)
            {
                if (!_parentForm.TabRenderer.IsWindows10)
                {
                    num6 = _parentForm.WindowState != FormWindowState.Maximized
                        ? systemMetrics
                        : 0;
                }
                else
                {
                    size = SystemInformation.BorderSize;
                    num6 = -1 * size.Width;
                }
            }
            else
            {
                size = SystemInformation.CaptionButtonSize;
                num6 = size.Height;
            }

            Height = tabHeight + num6;
            Render();
        }

        /// <summary>
        /// Overrides the message pump for the window so that we can respond to
        /// click events on the tabs themselves.
        /// </summary>
        /// <param name="m">Message received by the pump.</param>
        protected override void WndProc(ref Message m)
        {
            switch ((WM)m.Msg)
            {
                case WM.WM_SYSCOMMAND:
                    if (m.WParam == new IntPtr(0xF030) ||
                        m.WParam == new IntPtr(0xF120) ||
                        m.WParam == new IntPtr(0xF020))
                        _parentForm.ForwardMessage(ref m);
                    else
                        base.WndProc(ref m);

                    break;

                case WM.WM_NCLBUTTONDOWN:
                case WM.WM_LBUTTONDOWN:
                    var relativeCursorPosition =
                        GetRelativeCursorPosition(Cursor.Position);

                    // If we were over a tab, set the capture state for the window so that we'll actually receive a WM_LBUTTONUP message
                    if (_parentForm.TabRenderer.OverTab(
                            _parentForm.Tabs, relativeCursorPosition
                        ) == null &&
                        !_parentForm.TabRenderer.IsOverAddButton(
                            relativeCursorPosition
                        ))
                    {
                        _parentForm.ForwardMessage(ref m);
                    }
                    else
                    {
                        // When the user clicks a mouse button, save the tab that the user was over so we can respond properly when the mouse button is released
                        var clickedTab = _parentForm.TabRenderer.OverTab(
                            _parentForm.Tabs, relativeCursorPosition
                        );

                        if (clickedTab != null)
                        {
                            // If the user clicked the close button, remove the tab from the list
                            if (!_parentForm.TabRenderer.IsOverCloseButton(
                                    clickedTab, relativeCursorPosition
                                ))
                            {
                                _parentForm.ResizeTabContents(clickedTab);
                                _parentForm.SelectedTabIndex =
                                    _parentForm.Tabs.IndexOf(clickedTab);

                                Render();
                            }

                            OnMouseDown(
                                new MouseEventArgs(
                                    MouseButtons.Left, 1, Cursor.Position.X,
                                    Cursor.Position.Y, 0
                                )
                            );
                        }

                        _parentForm.Activate();
                    }

                    break;

                case WM.WM_LBUTTONDBLCLK:
                    _parentForm.ForwardMessage(ref m);
                    break;

                // We always return HTCAPTION for the hit test message so that the underlying window doesn't have its focus removed
                case WM.WM_NCHITTEST:
                    m.Result = new IntPtr(
                        (int)_parentForm.TabRenderer.NonClientHitTest(
                            m, GetRelativeCursorPosition(Cursor.Position)
                        )
                    );
                    break;

                case WM.WM_LBUTTONUP:
                case WM.WM_NCLBUTTONUP:
                case WM.WM_MBUTTONUP:
                case WM.WM_NCMBUTTONUP:
                    var relativeCursorPosition2 =
                        GetRelativeCursorPosition(Cursor.Position);

                    if (_parentForm.TabRenderer.OverTab(
                            _parentForm.Tabs, relativeCursorPosition2
                        ) == null &&
                        !_parentForm.TabRenderer.IsOverAddButton(
                            relativeCursorPosition2
                        ))
                    {
                        _parentForm.ForwardMessage(ref m);
                    }
                    else
                    {
                        // When the user clicks a mouse button, save the tab that the user was over so we can respond properly when the mouse button is released
                        var clickedTab = _parentForm.TabRenderer.OverTab(
                            _parentForm.Tabs, relativeCursorPosition2
                        );

                        if (clickedTab != null)
                        {
                            // If the user clicks the middle button/scroll wheel over a tab, close it
                            if ((WM)m.Msg == WM.WM_MBUTTONUP ||
                                (WM)m.Msg == WM.WM_NCMBUTTONUP)
                            {
                                clickedTab.Content.Close();
                                Render();
                            }
                            else
                            {
                                // If the user clicked the close button, remove the tab from the list
                                if (_parentForm.TabRenderer.IsOverCloseButton(
                                        clickedTab, relativeCursorPosition2
                                    ))
                                {
                                    clickedTab.Content.Close();
                                    Render();
                                }
                                else
                                {
                                    _parentForm.OnTabClicked(
                                        new TitleBarTabEventArgs
                                        {
                                            Tab = clickedTab,
                                            TabIndex =
                                                _parentForm
                                                    .SelectedTabIndex,
                                            Action =
                                                TabControlAction.Selected,
                                            WasDragging = _wasDragging
                                        }
                                    );
                                }
                            }
                        }

                        // Otherwise, if the user clicked the add button, call CreateTab to add a new tab to the list and select it
                        else if (_parentForm.TabRenderer.IsOverAddButton(
                                     relativeCursorPosition2
                                 ))
                        {
                            _parentForm.AddNewTab();
                        }

                        if ((WM)m.Msg == WM.WM_LBUTTONUP ||
                            (WM)m.Msg == WM.WM_NCLBUTTONUP)
                            OnMouseUp(
                                new MouseEventArgs(
                                    MouseButtons.Left, 1, Cursor.Position.X,
                                    Cursor.Position.Y, 0
                                )
                            );
                    }

                    break;

                default:
                    base.WndProc(ref m);
                    break;
            }
        }

        /// <summary>
        /// Event handler that is called when
        /// <see cref="F:xyLOGIX.EasyTabs.TitleBarTabsOverlay._parentForm" />'s
        /// <see cref="E:System.Windows.Forms.Form.Activated" /> event is fired.
        /// </summary>
        /// <param name="sender">Object from which this event originated.</param>
        /// <param name="e">Arguments associated with the event.</param>
        private void OnParentFormActivated(object sender, EventArgs e)
        {
            _active = true;
            Render();
        }

        /// <summary>
        /// Event handler that is called when
        /// <see cref="F:xyLOGIX.EasyTabs.TitleBarTabsOverlay._parentForm" />'s
        /// <see cref="E:System.Windows.Forms.Form.Deactivate" /> event is fired.
        /// </summary>
        /// <param name="sender">Object from which this event originated.</param>
        /// <param name="e">Arguments associated with the event.</param>
        private void OnDeactivateParentForm(object sender, EventArgs e)
        {
            _active = false;
            Render();
        }

        /// <summary>
        /// Event handler that is called when
        /// <see cref="F:xyLOGIX.EasyTabs.TitleBarTabsOverlay._parentForm" />'s
        /// <see cref="E:System.ComponentModel.Component.Disposed" /> event is fired.
        /// </summary>
        /// <param name="sender">Object from which this event originated.</param>
        /// <param name="e">Arguments associated with the event.</param>
        private void OnDisposedParentForm(object sender, EventArgs e) { }

        /// <summary>
        /// Event handler that is called when
        /// <see cref="F:xyLOGIX.EasyTabs.TitleBarTabsOverlay._parentForm" /> is in the process of
        /// closing.  This uninstalls
        /// <see cref="F:xyLOGIX.EasyTabs.TitleBarTabsOverlay._hookproc" /> from the low-level
        /// hooks list and stops the consumer thread that processes those events.
        /// </summary>
        /// <param name="sender">
        /// Object from which this event originated,
        /// <see cref="F:xyLOGIX.EasyTabs.TitleBarTabsOverlay._parentForm" /> in this case.
        /// </param>
        /// <param name="e">Arguments associated with this event.</param>
        private void OnParentFormClosing(object sender, CancelEventArgs e)
        {
            if (e.Cancel)
            {
                _parentFormClosing = false;
            }
            else
            {
                var key = (TitleBarTabs)sender;
                if (key == null)
                    return;
                _parentFormClosing = true;
                if (_parents.ContainsKey(key))
                    _parents.Remove(key);
                User32.UnhookWindowsHookEx(_hookId);
                _mouseEvents.CompleteAdding();
                _mouseEventsThread.Abort();
            }
        }

        /// <summary>
        /// Event handler that is called when
        /// <see cref="F:xyLOGIX.EasyTabs.TitleBarTabsOverlay._parentForm" />'s
        /// <see cref="E:System.Windows.Forms.Control.SizeChanged" />,
        /// <see cref="E:System.Windows.Forms.Control.VisibleChanged" />, or
        /// <see cref="E:System.Windows.Forms.Control.Move" /> events are fired which
        /// re-renders the tabs.
        /// </summary>
        /// <param name="sender">Object from which the event originated.</param>
        /// <param name="e">Arguments associated with the event.</param>
        private void OnParentFormRefresh(object sender, EventArgs e)
        {
            if (_parentForm == null) return;
            if (_parentForm.IsDisposed) return;
            
            if (_parentForm.WindowState == FormWindowState.Minimized)
                Visible = false;
            else
                OnPosition();
        }

        /// <summary>
        /// Event handler that is called when
        /// <see cref="F:xyLOGIX.EasyTabs.TitleBarTabsOverlay._parentForm" />'s
        /// <see cref="E:System.Windows.Forms.Control.SystemColorsChanged" /> event is
        /// fired which re-renders
        /// the tabs.
        /// </summary>
        /// <param name="sender">Object from which the event originated.</param>
        /// <param name="e">Arguments associated with the event.</param>
        private void OnSystemColorsChangedParentForm(object sender, EventArgs e)
        {
            _aeroEnabled = _parentForm.IsCompositionEnabled;
            OnPosition();
        }

        private void HideTooltip()
        {
            showTooltipTimer.Stop();

            if (_parentForm.InvokeRequired)
                _parentForm.BeginInvoke(
                    new Action(() => { _parentForm.Tooltip.Hide(_parentForm); })
                );
            else
                _parentForm.Tooltip.Hide(_parentForm);
        }

        private void InitializeComponent()
        {
            SuspendLayout();
            ClientSize = new Size(284, 261);
            Name = nameof(TitleBarTabsOverlay);
            ResumeLayout(false);
        }

        private void ShowTooltip(TitleBarTabs tabsForm, string caption)
        {
            var tooltipLocation = new Point(
                Cursor.Position.X + 7, Cursor.Position.Y + 55
            );
            tabsForm.Tooltip.Show(
                caption, tabsForm, tabsForm.PointToClient(tooltipLocation),
                tabsForm.Tooltip.AutoPopDelay
            );
        }

        private void ShowTooltipTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (!_parentForm.ShowTooltips) return;

            var relativeCursorPosition =
                GetRelativeCursorPosition(Cursor.Position);
            var hoverTab = _parentForm.TabRenderer.OverTab(
                _parentForm.Tabs, relativeCursorPosition
            );

            if (hoverTab != null)
            {
                var hoverTabForm = hoverTab.Parent;

                if (hoverTabForm.InvokeRequired)
                    hoverTabForm.Invoke(
                        new Action(
                            () =>
                            {
                                ShowTooltip(hoverTabForm, hoverTab.Caption);
                            }
                        )
                    );
                else
                    ShowTooltip(hoverTabForm, hoverTab.Caption);
            }
        }

        private void StartTooltipTimer()
        {
            if (!_parentForm.ShowTooltips)
                return;
            var titleBarTab = _parentForm.TabRenderer.OverTab(
                _parentForm.Tabs, GetRelativeCursorPosition(Cursor.Position)
            );
            if (titleBarTab == null)
                return;
            showTooltipTimer.Interval =
                titleBarTab.Parent.Tooltip.AutomaticDelay;
            showTooltipTimer.Start();
        }

        private void TitleBarTabsOverlay_FormClosing(
            object sender,
            FormClosingEventArgs e
        )
        {
            if (_parentFormClosing)
                return;
            e.Cancel = true;
            _parentFormClosing = true;
            _parentForm.Close();
        }

        /// <summary>
        /// Contains information on mouse events captured by
        /// <see
        ///     cref="M:xyLOGIX.EasyTabs.TitleBarTabsOverlay.MouseHookCallback(System.Int32,System.IntPtr,System.IntPtr)" />
        /// and processed by
        /// <see cref="M:xyLOGIX.EasyTabs.TitleBarTabsOverlay.InterpretMouseEvents" />.
        /// </summary>
        protected class MouseEvent
        {
            /// <summary>LParam value associated with the event.</summary>
            public IntPtr LParam { get; set; }

            /// <summary>Data associated with the mouse event.</summary>
            public MSLLHOOKSTRUCT? MouseData { get; set; }

            /// <summary>Code for the event.</summary>
            public int Code { get; set; }

            /// <summary>WParam value associated with the event.</summary>
            public IntPtr WParam { get; set; }
        }
    }
}