using PostSharp.Patterns.Diagnostics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Win32Interop.Enums;
using Win32Interop.Methods;
using Win32Interop.Structs;

namespace xyLOGIX.EasyTabs
{
    /// <summary>
    /// Contains a semi-transparent window with a thumbnail of a tab that has been torn
    /// away from its parent window.  This thumbnail will follow the cursor
    /// around as it's dragged around the screen.
    /// </summary>
    public class TornTabForm : Form
    {
        /// <summary>Window that contains the actual thumbnail image data.</summary>
        private readonly LayeredWindow _layeredWindow;

        /// <summary>
        /// Offset of the cursor within the torn tab representation while
        /// dragging.
        /// </summary>
        protected Point _cursorOffset;

        /// <summary>
        /// Pointer to the low-level mouse hook callback (
        /// <see
        ///     cref="M:xyLOGIX.EasyTabs.TornTabForm.MouseHookCallback(System.Int32,System.IntPtr,System.IntPtr)" />
        /// ).
        /// </summary>
        protected IntPtr _hookId;

        /// <summary>
        /// Flag indicating whether
        /// <see cref="F:xyLOGIX.EasyTabs.TornTabForm._hookproc" /> is installed.
        /// </summary>
        protected bool _hookInstalled;

        /// <summary>
        /// Delegate of
        /// <see
        ///     cref="M:xyLOGIX.EasyTabs.TornTabForm.MouseHookCallback(System.Int32,System.IntPtr,System.IntPtr)" />
        /// ; declared as a member variable to keep it from being garbage collected.
        /// </summary>
        protected HOOKPROC _hookproc;

        /// <summary>Flag indicating whether the constructor has finished running.</summary>
        private bool _initialized;

        /// <summary>Thumbnail of the tab we are dragging.</summary>
        protected Bitmap _tabThumbnail;

        /// <summary>
        /// Constructor; initializes the window and constructs the tab thumbnail
        /// image to use when dragging.
        /// </summary>
        /// <param name="tab">Tab that was torn out of its parent window.</param>
        /// <param name="tabRenderer">Renderer instance to use when drawing the actual tab.</param>
        public TornTabForm(TitleBarTab tab, TabRendererBase tabRenderer)
        {
            _layeredWindow = new LayeredWindow();
            _initialized = false;

            // Set drawing styles
            SetStyle(ControlStyles.DoubleBuffer, true);

            // This should show up as a semi-transparent borderless window
            Opacity = 0.70;
            ShowInTaskbar = false;
            FormBorderStyle = FormBorderStyle.None;

            // ReSharper disable DoNotCallOverridableMethodsInConstructor
            BackColor = Color.Fuchsia;

            // ReSharper restore DoNotCallOverridableMethodsInConstructor
            TransparencyKey = Color.Fuchsia;
            AllowTransparency = true;

            Disposed += TornTabForm_Disposed;

            // Get the tab thumbnail (full size) and then draw the actual representation of the tab onto it as well
            var tabContents = tab.GetImage();
            var contentsAndTab = new Bitmap(
                tabContents.Width, tabContents.Height + tabRenderer.TabHeight,
                tabContents.PixelFormat
            );
            var tabGraphics = Graphics.FromImage(contentsAndTab);

            tabGraphics.DrawImage(tabContents, 0, tabRenderer.TabHeight);

            var oldShowAddButton = tabRenderer.ShowAddButton;

            tabRenderer.ShowAddButton = false;
            tabRenderer.Render(
                new List<TitleBarTab> { tab }, tabGraphics, new Point(0, 0),
                new Point(0, 0), true
            );
            tabRenderer.ShowAddButton = oldShowAddButton;

            // Scale the thumbnail down to half size
            _tabThumbnail = new Bitmap(
                contentsAndTab.Width / 2, contentsAndTab.Height / 2,
                contentsAndTab.PixelFormat
            );
            var thumbnailGraphics = Graphics.FromImage(_tabThumbnail);

            thumbnailGraphics.InterpolationMode = InterpolationMode.High;
            thumbnailGraphics.CompositingQuality =
                CompositingQuality.HighQuality;
            thumbnailGraphics.SmoothingMode = SmoothingMode.AntiAlias;
            thumbnailGraphics.DrawImage(
                contentsAndTab, 0, 0, _tabThumbnail.Width, _tabThumbnail.Height
            );

            Width = _tabThumbnail.Width - 1;
            Height = _tabThumbnail.Height - 1;

            _cursorOffset = new Point(
                tabRenderer.TabContentWidth / 4, tabRenderer.TabHeight / 4
            );

            SetWindowPosition(Cursor.Position);
        }

        /// <summary>
        /// Calls
        /// <see
        ///     cref="M:xyLOGIX.EasyTabs.LayeredWindow.UpdateWindow(System.Drawing.Bitmap,System.Byte,System.Int32,System.Int32,Win32Interop.Structs.POINT)" />
        /// to update the position of the thumbnail and blend it properly with the
        /// underlying desktop
        /// elements.
        /// </summary>
        public void UpdateLayeredBackground()
        {
            if (_tabThumbnail == null || !_initialized)
                return;
            var num = (byte)(Opacity * byte.MaxValue);
            var layeredWindow = _layeredWindow;
            var tabThumbnail = _tabThumbnail;
            int opacity = num;
            var width = Width;
            var height = Height;
            var point = new POINT();
            ref var local1 = ref point;
            var location = Location;
            var x = location.X;
            local1.x = x;
            ref var local2 = ref point;
            location = Location;
            var y = location.Y;
            local2.y = y;
            var position = point;
            layeredWindow.UpdateWindow(
                tabThumbnail, (byte)opacity, width, height, position
            );
        }

        /// <summary>
        /// Hook callback to process
        /// <see cref="F:Win32Interop.Enums.WM.WM_MOUSEMOVE" /> messages to move the
        /// thumbnail along with the cursor.
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
            if (nCode >= 0 && 512 == (int)wParam)
            {
                var structure = (MSLLHOOKSTRUCT)Marshal.PtrToStructure(
                    lParam, typeof(MSLLHOOKSTRUCT)
                );
                SetWindowPosition(new Point(structure.pt.x, structure.pt.y));
            }

            return User32.CallNextHookEx(_hookId, nCode, wParam, lParam);
        }

        /// <summary>
        /// Event handler that is called when the window is closing; closes
        /// <see cref="F:xyLOGIX.EasyTabs.TornTabForm._layeredWindow" /> as well.
        /// </summary>
        /// <param name="e">Arguments associated with this event.</param>
        protected override void OnClosing([NotLogged] CancelEventArgs e)
        {
            base.OnClosing(e);
            _layeredWindow.Close();
        }

        /// <summary>
        /// Event handler that's called when the window is loaded; shows
        /// <see cref="F:xyLOGIX.EasyTabs.TornTabForm._layeredWindow" /> and installs the mouse
        /// hook via
        /// <see
        ///     cref="M:Win32Interop.Methods.User32.SetWindowsHookEx(Win32Interop.Enums.WH,Win32Interop.Methods.HOOKPROC,System.IntPtr,System.UInt32)" />
        /// .
        /// </summary>
        /// <param name="e">Arguments associated with this event.</param>
        protected override void OnLoad([NotLogged] EventArgs e)
        {
            base.OnLoad(e);

            _initialized = true;

            UpdateLayeredBackground();

            _layeredWindow.Show();
            _layeredWindow.Enabled = false;

            // Installs the mouse hook
            if (!_hookInstalled)
            {
                using (var curProcess = Process.GetCurrentProcess())
                {
                    using (var curModule = curProcess.MainModule)
                    {
                        _hookproc = MouseHookCallback;
                        _hookId = User32.SetWindowsHookEx(
                            WH.WH_MOUSE_LL, _hookproc,
                            Kernel32.GetModuleHandle(curModule.ModuleName), 0
                        );
                    }
                }

                _hookInstalled = true;
            }
        }

        /// <summary>Updates the window position to keep up with the cursor's movement.</summary>
        /// <param name="cursorPosition">Current position of the cursor.</param>
        protected void SetWindowPosition(Point cursorPosition)
        {
            Left = cursorPosition.X - _cursorOffset.X;
            Top = cursorPosition.Y - _cursorOffset.Y;
            UpdateLayeredBackground();
        }

        /// <summary>
        /// Event handler that's called from <see cref="M:System.IDisposable.Dispose" />;
        /// calls
        /// <see cref="M:Win32Interop.Methods.User32.UnhookWindowsHookEx(System.IntPtr)" />
        /// to unsubscribe from the mouse
        /// hook.
        /// </summary>
        /// <param name="sender">Object from which this event originated.</param>
        /// <param name="e">Arguments associated with this event.</param>
        private void TornTabForm_Disposed([NotLogged] object sender, [NotLogged] EventArgs e)
            => User32.UnhookWindowsHookEx(_hookId);
    }
}