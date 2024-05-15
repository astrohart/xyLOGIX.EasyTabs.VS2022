using Core.Logging;
using Microsoft.WindowsAPICodePack.Taskbar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Forms;
using Win32Interop.Enums;
using Win32Interop.Methods;
using Win32Interop.Structs;
using Color = System.Drawing.Color;
using Point = System.Drawing.Point;
using Size = System.Drawing.Size;

namespace xyLOGIX.EasyTabs
{
    /// <summary>
    /// Base class that contains the functionality to render tabs within a WinForms
    /// application's title bar area. This  is done through a borderless overlay
    /// window (<see cref="F:xyLOGIX.EasyTabs.TitleBarTabs._overlay" />) rendered on
    /// top of the
    /// non-client area at the top of this window.  All an implementing class will need
    /// to do is set
    /// the <see cref="P:xyLOGIX.EasyTabs.TitleBarTabs.TabRenderer" /> property and
    /// begin
    /// adding tabs to <see cref="P:xyLOGIX.EasyTabs.TitleBarTabs.Tabs" />.
    /// </summary>
    public abstract class TitleBarTabs : Form
    {
        /// <summary>Required designer variable.</summary>
        public readonly IContainer components;

        /// <summary>
        /// Flag indicating whether each tab has an Aero Peek entry
        /// allowing the user to switch between tabs from the taskbar.
        /// </summary>
        protected bool _aeroPeekEnabled = true;

        /// <summary>Height of the non-client area at the top of the window.</summary>
        protected int _nonClientAreaHeight;

        /// <summary>
        /// The preview images for each tab used to display each tab when Aero
        /// Peek is activated.
        /// </summary>
        protected Dictionary<Form, Bitmap> _previews =
            new Dictionary<Form, Bitmap>();

        /// <summary>
        /// When switching between tabs, this keeps track of the tab that was previously
        /// active so that, when it is switched away from, we can generate a fresh
        /// Aero Peek preview image for it.
        /// </summary>
        protected TitleBarTab _previousSelectedTab;

        /// <summary>
        /// Maintains the previous window state so that we can respond properly to
        /// maximize/restore events in
        /// <see cref="M:xyLOGIX.EasyTabs.TitleBarTabs.OnSizeChanged(System.EventArgs)" />.
        /// </summary>
        protected FormWindowState _previousWindowState = FormWindowState.Normal;

        /// <summary>
        /// Class responsible for actually rendering the tabs in
        /// <see cref="F:xyLOGIX.EasyTabs.TitleBarTabs._overlay" />.
        /// </summary>
        protected TabRendererBase _tabRenderer;

        /// <summary>List of tabs to display for this window.</summary>
        protected IListWithEvents<TitleBarTab> _tabs =
            new ListWithEvents<TitleBarTab>();

        /// <summary>
        /// Constructs a new instance of <see cref="T:xyLOGIX.EasyTabs.TitleBarTabs" /> and
        /// returns a reference to it.
        /// </summary>
        protected TitleBarTabs()
            => CommonConstruct();

        /// <summary>Default constructor.</summary>
        protected TitleBarTabs(IContainer components)
        {
            this.components = components;

            CommonConstruct();
        }

        /// <summary>
        /// Flag indicating whether each tab has an Aero Peek entry
        /// allowing the user to switch between tabs from the taskbar.
        /// </summary>
        public bool AeroPeekEnabled
        {
            get => _aeroPeekEnabled;
            set
            {
                _aeroPeekEnabled = value;
                if (!_aeroPeekEnabled)
                {
                    foreach (var tab in Tabs)
                        TaskbarManager.Instance.TabbedThumbnail
                                      .RemoveThumbnailPreview(tab.Content);
                    _previews.Clear();
                }
                else
                {
                    foreach (var tab in Tabs)
                        CreateThumbnailPreview(tab);
                    if (SelectedTab == null)
                        return;
                    TaskbarManager.Instance.TabbedThumbnail.SetActiveTab(
                        SelectedTab.Content
                    );
                }
            }
        }

        /// <summary>Application context under which this particular window runs.</summary>
        public TitleBarTabsApplicationContext ApplicationContext
        {
            get;
            internal set;
        }

        /// <summary>
        /// Flag indicating whether the application itself should exit when the
        /// last tab is closed.
        /// </summary>
        public bool ExitOnLastTabClose { get; set; } = true;

        /// <summary>Flag indicating whether we are in the process of closing the window.</summary>
        public bool IsClosing { get; set; }

        /// <summary>Flag indicating whether composition is enabled on the desktop.</summary>
        internal bool IsCompositionEnabled
        {
            get
            {
                Dwmapi.DwmIsCompositionEnabled(out var compositionEnabled);
                return compositionEnabled;
            }
        }

        /// <summary>Height of the "glassed" area of the window's non-client area.</summary>
        public int NonClientAreaHeight
            => _nonClientAreaHeight;

        /// <summary>
        /// Borderless window that is rendered over top of the non-client area of
        /// this window.
        /// </summary>
        public TitleBarTabsOverlay Overlay { get; protected set; }

        /// <summary>The tab that is currently selected by the user.</summary>
        public TitleBarTab SelectedTab
        {
            get
            {
                TitleBarTab result = default;

                try
                {
                    if (Tabs == null) return result;
                    if (Tabs.Count == 0) return result;

                    foreach (var tab in Tabs.ToArray())
                    {
                        if (tab == null) continue;
                        if (!tab.Active) continue;

                        result = tab;
                        break;
                    }
                }
                catch (Exception ex)
                {
                    // dump all the exception info to the log
                    DebugUtils.LogException(ex);

                    result = default;
                }

                return result;
            }
            set
            {
                if (value == null) return;
                if (Tabs.ToArray()
                        .Length == 0) return;
                if (!Tabs.ToArray()
                         .Contains(value)) return;

                var targetIndex = -1;

                var tabs = Tabs.ToArray();

                for (var i = 0; i < tabs.Length; i++)
                {
                    if (tabs[i] == null) continue;
                    if (!value.Equals(tabs[i])) continue;

                    targetIndex = i;
                    break;
                }

                SelectedTabIndex = targetIndex;
            }
        }

        /// <summary>
        /// Gets or sets the index of the tab that is currently selected by the
        /// user.
        /// </summary>
        public int SelectedTabIndex
        {
            get
            {
                var result = -1;

                try
                {
                    if (Tabs == null) return result;
                    if (Tabs.Count == 0) return result;

                    var tabArray = Tabs.ToArray();
                    if (tabArray == null) return result;
                    if (tabArray.Length == 0) return result;

                    for (var i = 0; i < tabArray.Length; i++)
                    {
                        if (tabArray[i] == null) continue;
                        if (!tabArray[i].Active) continue;

                        result = i;
                        break;
                    }
                }
                catch (Exception ex)
                {
                    // dump all the exception info to the log
                    DebugUtils.LogException(ex);

                    result = -1;
                }

                return result;
            }
            set
            {
                if (value < 0) return;

                var selectedTab = SelectedTab;
                var selectedTabIndex = SelectedTabIndex;
                if (selectedTab != null && selectedTabIndex != value)
                {
                    var e = new TitleBarTabCancelEventArgs
                    {
                        Action = TabControlAction.Deselecting,
                        Tab = selectedTab,
                        TabIndex = selectedTabIndex
                    };
                    OnTabDeselecting(e);
                    if (e.Cancel)
                        return;
                    selectedTab.Active = false;
                    OnTabDeselected(
                        new TitleBarTabEventArgs
                        {
                            Tab = selectedTab,
                            TabIndex = selectedTabIndex,
                            Action = TabControlAction.Deselected
                        }
                    );
                }

                if (value != -1)
                {
                    var e = new TitleBarTabCancelEventArgs
                    {
                        Action = TabControlAction.Selecting,
                        Tab = Tabs[value],
                        TabIndex = value
                    };
                    OnSelectedTabIndexChanging(e);
                    if (e.Cancel)
                        return;
                    Tabs[value].Active = true;
                    OnSelectedTabIndexChanged(
                        new TitleBarTabEventArgs
                        {
                            Tab = Tabs[value],
                            TabIndex = value,
                            Action = TabControlAction.Selected
                        }
                    );
                }

                if (Overlay == null)
                    return;
                Overlay.Render();
            }
        }

        /// <summary>
        /// Flag indicating whether a tooltip should be shown when hovering over a
        /// tab.
        /// </summary>
        public bool ShowTooltips { get; set; }

        /// <summary>Area of the screen in which tabs can be dropped for this window.</summary>
        public Rectangle TabDropArea
            => Overlay.TabDropArea;

        /// <summary>The renderer to use when drawing the tabs.</summary>
        public TabRendererBase TabRenderer
        {
            get => _tabRenderer;
            set
            {
                _tabRenderer = value;
                SetFrameSize();
            }
        }

        /// <summary>Gets the collection of tabs to display for this window.</summary>
        public IListWithEvents<TitleBarTab> Tabs
            => _tabs;

        /// <summary>Tooltip UI element to show when hovering over a tab.</summary>
        public ToolTip Tooltip { get; set; }

        /// <summary>Event that is raised after a tab has been selected.</summary>
        public event TitleBarTabEventHandler SelectedTabIndexChanged;

        /// <summary>
        /// Event that is raised immediately prior to a tab being selected (
        /// <see cref="E:xyLOGIX.EasyTabs.TitleBarTabs.SelectedTabIndexChanged" />).
        /// </summary>
        public event TitleBarTabCancelEventHandler SelectedTabIndexChanging;

        /// <summary>Event that is raised after a tab has been clicked.</summary>
        public event TitleBarTabEventHandler TabClicked;

        /// <summary>Event that is raised after a tab has been deselected.</summary>
        public event TitleBarTabEventHandler TabDeselected;

        /// <summary>
        /// Event that is raised immediately prior to a tab being deselected (
        /// <see cref="E:xyLOGIX.EasyTabs.TitleBarTabs.TabDeselected" />).
        /// </summary>
        public event TitleBarTabCancelEventHandler TabDeselecting;

        /// <summary>
        /// Calls <see cref="M:xyLOGIX.EasyTabs.TitleBarTabs.CreateTab" />, adds the
        /// resulting tab to the <see cref="P:xyLOGIX.EasyTabs.TitleBarTabs.Tabs" />
        /// collection,
        /// and activates it.
        /// </summary>
        public virtual void AddNewTab()
        {
            var tab = CreateTab();
            Tabs.Add(tab);
            ResizeTabContents(tab);
            SelectedTabIndex = _tabs.Count - 1;
        }

        /// <summary>
        /// Callback that should be implemented by the inheriting class that will create a
        /// new <see cref="T:xyLOGIX.EasyTabs.TitleBarTab" /> object when the add button is
        /// clicked.
        /// </summary>
        /// <returns>A newly created tab.</returns>
        public abstract TitleBarTab CreateTab();

        /// <summary>
        /// Calls
        /// <see cref="M:xyLOGIX.EasyTabs.TitleBarTabsOverlay.Render(System.Boolean)" /> on
        /// <see cref="F:xyLOGIX.EasyTabs.TitleBarTabs._overlay" /> to force a redrawing of
        /// the
        /// tabs.
        /// </summary>
        public void RedrawTabs()
        {
            if (Overlay == null)
                return;
            Overlay.Render(true);
        }

        /// <summary>
        /// Resizes the <see cref="P:xyLOGIX.EasyTabs.TitleBarTab.Content" /> form of the
        /// <paramref name="tab" /> to match the size of the client area for this window.
        /// </summary>
        /// <param name="tab">
        /// Tab whose <see cref="P:xyLOGIX.EasyTabs.TitleBarTab.Content" /> form we should
        /// resize;
        /// if not specified, we default to
        /// <see cref="P:xyLOGIX.EasyTabs.TitleBarTabs.SelectedTab" />.
        /// </param>
        public void ResizeTabContents(TitleBarTab tab = null)
        {
            if (tab == null)
                tab = SelectedTab;
            if (tab == null)
                return;
            var content1 = tab.Content;
            var padding = Padding;
            var point = new Point(0, padding.Top - 1);
            content1.Location = point;
            var content2 = tab.Content;
            var width = ClientRectangle.Width;
            var height1 = ClientRectangle.Height;
            padding = Padding;
            var top = padding.Top;
            var height2 = height1 - top + 1;
            var size = new Size(width, height2);
            content2.Size = size;
        }

        /// <summary>
        /// When a child tab updates its <see cref="P:System.Windows.Forms.Form.Icon" />
        /// property, it should call this method to update the icon in the AeroPeek
        /// preview.
        /// </summary>
        /// <param name="tab">Tab whose icon was updated.</param>
        /// <param name="icon">
        /// The new icon to use.  If this is left as null, we use
        /// <see cref="P:System.Windows.Forms.Form.Icon" /> on <paramref name="tab" />.
        /// </param>
        public virtual void UpdateThumbnailPreviewIcon(
            TitleBarTab tab,
            Icon icon = null
        )
        {
            if (!AeroPeekEnabled)
                return;
            var thumbnailPreview =
                TaskbarManager.Instance.TabbedThumbnail.GetThumbnailPreview(
                    tab.Content
                );
            if (thumbnailPreview == null)
                return;
            if (icon == null)
                icon = tab.Content.Icon;
            thumbnailPreview.SetWindowIcon((Icon)icon.Clone());
        }

        /// <summary>
        /// Forwards a message received by
        /// <see cref="T:xyLOGIX.EasyTabs.TitleBarTabsOverlay" /> to the underlying window.
        /// </summary>
        /// <param name="m">Message received by the overlay.</param>
        internal void ForwardMessage(ref Message m)
        {
            m.HWnd = Handle;
            WndProc(ref m);
        }

        /// <summary>
        /// Callback for the <see cref="E:xyLOGIX.EasyTabs.TitleBarTabs.TabClicked" />
        /// event.
        /// </summary>
        /// <param name="e">Arguments associated with the event.</param>
        protected internal void OnTabClicked(TitleBarTabEventArgs e)
        {
            if (TabClicked == null)
                return;
            TabClicked(this, e);
        }

        /// <summary>
        /// Removes <paramref name="closingTab" /> from
        /// <see cref="P:xyLOGIX.EasyTabs.TitleBarTabs.Tabs" /> and selects the next
        /// applicable tab
        /// in the list.
        /// </summary>
        /// <param name="closingTab">Tab that is being closed.</param>
        protected virtual void CloseTab(TitleBarTab closingTab)
        {
            if (closingTab == null || closingTab.IsDisposed) return;

            var num = Tabs.IndexOf(closingTab);
            var selectedTabIndex = SelectedTabIndex;
            Tabs.Remove(closingTab);
            SelectedTabIndex = selectedTabIndex <= num
                ? selectedTabIndex != num
                    ? selectedTabIndex
                    : Math.Min(selectedTabIndex, Tabs.Count - 1)
                : selectedTabIndex - 1;
            if (_previews.ContainsKey(closingTab.Content))
            {
                _previews[closingTab.Content]
                    .Dispose();
                _previews.Remove(closingTab.Content);
            }

            if (_previousSelectedTab != null &&
                closingTab.Content == _previousSelectedTab.Content)
                _previousSelectedTab = null;
            if (Tabs.Count != 0 || !ExitOnLastTabClose)
                return;
            Close();
        }

        /// <summary>
        /// Creates a new thumbnail for <paramref name="tab" /> when the application is
        /// initially enabled for AeroPeek or when it is turned on sometime during
        /// execution.
        /// </summary>
        /// <param name="tab">Tab that we are to create the thumbnail for.</param>
        /// <returns>Thumbnail created for <paramref name="tab" />.</returns>
        protected virtual TabbedThumbnail CreateThumbnailPreview(
            TitleBarTab tab
        )
        {
            if (TaskbarManager.Instance.TabbedThumbnail.GetThumbnailPreview(
                    tab.Content
                ) != null)
                TaskbarManager.Instance.TabbedThumbnail.RemoveThumbnailPreview(
                    tab.Content
                );
            var preview = new TabbedThumbnail(Handle, tab.Content)
            {
                Title = tab.Content.Text, Tooltip = tab.Content.Text
            };
            preview.SetWindowIcon((Icon)tab.Content.Icon.Clone());
            preview.TabbedThumbnailActivated +=
                OnPreviewTabbedThumbnailActivated;
            preview.TabbedThumbnailClosed += OnPreviewTabbedThumbnailClosed;
            preview.TabbedThumbnailBitmapRequested +=
                OnPreviewTabbedThumbnailBitmapRequested;
            preview.PeekOffset = new Vector(Padding.Left, Padding.Top - 1);
            TaskbarManager.Instance.TabbedThumbnail
                          .AddThumbnailPreview(preview);
            return preview;
        }

        /// <summary>Clean up any resources being used.</summary>
        /// <param name="disposing">
        /// true if managed resources should be disposed;
        /// otherwise, false.
        /// </param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        /// <summary>
        /// Callback for the
        /// <see cref="E:System.Windows.Forms.Control.ClientSizeChanged" /> event that
        /// resizes the <see cref="P:xyLOGIX.EasyTabs.TitleBarTab.Content" /> form of the
        /// currently
        /// selected
        /// tab when the size of the client area for this window changes.
        /// </summary>
        /// <param name="e">Arguments associated with the event.</param>
        protected override void OnClientSizeChanged(EventArgs e)
        {
            base.OnClientSizeChanged(e);
            ResizeTabContents();
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Form.FormClosing" />
        /// event.
        /// </summary>
        /// <param name="e">
        /// A <see cref="T:System.Windows.Forms.FormClosingEventArgs" />
        /// that contains the event data.
        /// </param>
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            foreach (var tab in Tabs.ToArray())
            {
                if (tab == null) continue;
                if (tab.IsDisposed) continue;

                var formClosed = false;
                tab.Content.FormClosed += (_, __) => formClosed = true;
                BeginInvoke(new Action(() => tab.Close()));
                if (formClosed) continue;
                e.Cancel =
                    true; // just one of the tabs not closing is enough to abort the operation
                break;
            }
        }

        /// <summary>
        /// Event handler that is invoked when the
        /// <see cref="E:System.Windows.Forms.Form.Load" /> event is fired.  Instantiates
        /// <see cref="F:xyLOGIX.EasyTabs.TitleBarTabs._overlay" /> and clears out the
        /// window's
        /// caption.
        /// </summary>
        /// <param name="e">Arguments associated with the event.</param>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Overlay = TitleBarTabsOverlay.GetInstance(this);
            if (TabRenderer == null)
                return;
            Overlay.MouseMove += TabRenderer.OnOverlayMouseMove;
            Overlay.MouseUp += TabRenderer.OnOverlayMouseUp;
            Overlay.MouseDown += TabRenderer.OnOverlayMouseDown;
        }

        /// <summary>
        /// Override of the handler for the paint background event that is left
        /// blank so that code is never executed.
        /// </summary>
        /// <param name="e">Arguments associated with the event.</param>
        protected override void OnPaintBackground(PaintEventArgs e) { }

        /// <summary>
        /// Handler method that's called when the user clicks on an Aero Peek preview
        /// thumbnail.  Finds the tab associated with the thumbnail and
        /// focuses on it.
        /// </summary>
        /// <param name="sender">Object from which this event originated.</param>
        /// <param name="e">Arguments associated with this event.</param>
        /// <remarks>
        /// If this method is overriden, implementers must call the base class
        /// before any of their own logic.
        /// </remarks>
        protected virtual void OnPreviewTabbedThumbnailActivated(
            object sender,
            TabbedThumbnailEventArgs e
        )
        {
            using (var enumerator = Tabs
                                    .Where(
                                        tab => tab.Content.Handle ==
                                               e.WindowHandle
                                    )
                                    .GetEnumerator())
            {
                if (enumerator.MoveNext())
                {
                    var current = enumerator.Current;
                    SelectedTabIndex = Tabs.IndexOf(current);
                    TaskbarManager.Instance.TabbedThumbnail.SetActiveTab(
                        current.Content
                    );
                }
            }

            if (WindowState == FormWindowState.Minimized)
                User32.ShowWindow(Handle, 3);
            else
                Focus();
        }

        /// <summary>
        /// Handler method that's called when Aero Peek needs to display a thumbnail for a
        /// <see cref="T:xyLOGIX.EasyTabs.TitleBarTab" />; finds the preview bitmap
        /// generated in
        /// <see cref="E:xyLOGIX.EasyTabs.TitleBarTabs.TabDeselecting" /> and returns that.
        /// </summary>
        /// <param name="sender">Object from which this event originated.</param>
        /// <param name="e">Arguments associated with this event.</param>
        protected virtual void OnPreviewTabbedThumbnailBitmapRequested(
            object sender,
            TabbedThumbnailBitmapRequestedEventArgs e
        )
        {
            using (var enumerator = Tabs
                                    .Where(
                                        rdcWindow
                                            => rdcWindow.Content.Handle ==
                                               e.WindowHandle &&
                                               _previews.ContainsKey(
                                                   rdcWindow.Content
                                               )
                                    )
                                    .GetEnumerator())
            {
                if (!enumerator.MoveNext())
                    return;
                var current = enumerator.Current;
                TaskbarManager.Instance.TabbedThumbnail
                              .GetThumbnailPreview(current.Content)
                              .SetImage(_previews[current.Content]);
            }
        }

        /// <summary>
        /// Handler method that's called when the user clicks the close button in an Aero
        /// Peek preview thumbnail.  Finds the window associated with the thumbnail
        /// and calls <see cref="M:System.Windows.Forms.Form.Close" /> on it.
        /// </summary>
        /// <param name="sender">Object from which this event originated.</param>
        /// <param name="e">Arguments associated with this event.</param>
        /// <remarks>
        /// If this method is overriden, then overriders must call the base class
        /// prior to running their own logic.
        /// </remarks>
        protected virtual void OnPreviewTabbedThumbnailClosed(
            object sender,
            TabbedThumbnailEventArgs e
        )
        {
            using (var enumerator = Tabs
                                    .Where(
                                        tab => tab.Content.Handle ==
                                               e.WindowHandle
                                    )
                                    .GetEnumerator())
            {
                if (!enumerator.MoveNext())
                    return;
                CloseTab(enumerator.Current);
            }
        }

        /// <summary>
        /// Callback for the
        /// <see cref="E:xyLOGIX.EasyTabs.TitleBarTabs.SelectedTabIndexChanged" />
        /// event.
        /// Called when a <see cref="T:xyLOGIX.EasyTabs.TitleBarTab" /> gains focus.  Sets
        /// the
        /// active window in Aero Peek via a
        /// call to
        /// <see
        ///     cref="M:Microsoft.WindowsAPICodePack.Taskbar.TabbedThumbnailManager.SetActiveTab(System.Windows.Forms.Control)" />
        /// .
        /// </summary>
        /// <param name="e">Arguments associated with the event.</param>
        protected void OnSelectedTabIndexChanged(TitleBarTabEventArgs e)
        {
            if (SelectedTabIndex != -1 &&
                _previews.ContainsKey(SelectedTab.Content) && AeroPeekEnabled)
                TaskbarManager.Instance.TabbedThumbnail.SetActiveTab(
                    SelectedTab.Content
                );

            _previousSelectedTab = SelectedTab;

            SelectedTabIndexChanged?.Invoke(this, e);
        }

        /// <summary>
        /// Callback for the
        /// <see cref="E:xyLOGIX.EasyTabs.TitleBarTabs.SelectedTabIndexChanging" />
        /// event.
        /// </summary>
        /// <param name="e">Arguments associated with the event.</param>
        protected void OnSelectedTabIndexChanging(TitleBarTabCancelEventArgs e)
        {
            ResizeTabContents(e.Tab);
            if (SelectedTabIndexChanging == null)
                return;
            SelectedTabIndexChanging(this, e);
        }

        /// <summary>
        /// Overrides the <see cref="E:System.Windows.Forms.Control.SizeChanged" /> handler
        /// so that we can detect when the user has maximized or restored the window and
        /// adjust the size
        /// of the non-client area accordingly.
        /// </summary>
        /// <param name="e">Arguments associated with the event.</param>
        protected override void OnSizeChanged(EventArgs e)
        {
            if (!WindowState.Equals(_previousWindowState))
                SetFrameSize();

            _previousWindowState = WindowState;
            base.OnSizeChanged(e);
        }

        /// <summary>
        /// Callback for the <see cref="E:xyLOGIX.EasyTabs.TitleBarTabs.TabDeselected" />
        /// event.
        /// </summary>
        /// <param name="e">Arguments associated with the event.</param>
        protected void OnTabDeselected(TitleBarTabEventArgs e)
            => TabDeselected?.Invoke(this, e);

        /// <summary>
        /// Callback for the <see cref="E:xyLOGIX.EasyTabs.TitleBarTabs.TabDeselecting" />
        /// event.
        /// Called when a <see cref="T:xyLOGIX.EasyTabs.TitleBarTab" /> is in the process
        /// of losing
        /// focus.  Grabs an image of
        /// the tab's content to be used when Aero Peek is activated.
        /// </summary>
        /// <param name="e">Arguments associated with the event.</param>
        protected void OnTabDeselecting(TitleBarTabCancelEventArgs e)
        {
            if (_previousSelectedTab != null && AeroPeekEnabled)
                UpdateTabThumbnail(_previousSelectedTab);

            TabDeselecting?.Invoke(this, e);
        }

        /// <summary>
        /// When the window's state (maximized, minimized, or restored) changes, this sets
        /// the size of the non-client area at the top of the window properly so
        /// that the tabs can be displayed.
        /// </summary>
        protected void SetFrameSize()
        {
            if (TabRenderer == null || WindowState == FormWindowState.Minimized)
                return;
            var num =
                WindowState == FormWindowState.Maximized ||
                TabRenderer.RendersEntireTitleBar
                    ? TabRenderer.TabHeight - TabRenderer.TopPadding -
                      SystemInformation.CaptionHeight
                    : TabRenderer.TabHeight - SystemInformation.CaptionHeight;
            if (!OperatingSystem.IsWindows10 &&
                WindowState == FormWindowState.Maximized)
                ++num;
            Padding = new Padding(
                Padding.Left, num > 0 ? num : 0, Padding.Right, Padding.Bottom
            );
            if (!OperatingSystem.IsWindows10)
            {
                var margins = new MARGINS
                {
                    cxLeftWidth = 1,
                    cxRightWidth = 1,
                    cyBottomHeight = 1,
                    cyTopHeight = num > 0 ? num : 0
                };
                Dwmapi.DwmExtendFrameIntoClientArea(Handle, ref margins);
            }

            _nonClientAreaHeight =
                SystemInformation.CaptionHeight + (num > 0 ? num : 0);
            if (!AeroPeekEnabled)
                return;
            foreach (var tabbedThumbnail in Tabs.Select(
                                                    tab => TaskbarManager
                                                        .Instance
                                                        .TabbedThumbnail
                                                        .GetThumbnailPreview(
                                                            tab.Content
                                                        )
                                                )
                                                .Where(
                                                    preview => preview != null
                                                ))
            {
                var padding = Padding;
                double left = padding.Left;
                padding = Padding;
                double y = padding.Top - 1;
                var nullable = new Vector(left, y);
                tabbedThumbnail.PeekOffset = nullable;
            }
        }

        /// <summary>Generate a new thumbnail image for <paramref name="tab" />.</summary>
        /// <param name="tab">Tab that we need to generate a thumbnail for.</param>
        protected void UpdateTabThumbnail(TitleBarTab tab)
        {
            var thumbnailPreview =
                TaskbarManager.Instance.TabbedThumbnail.GetThumbnailPreview(
                    tab.Content
                );
            if (thumbnailPreview == null)
                return;
            var image = tab.GetImage();
            thumbnailPreview.SetImage(image);
            if (_previews.ContainsKey(tab.Content) &&
                _previews[tab.Content] != null)
                _previews[tab.Content]
                    .Dispose();
            _previews[tab.Content] = image;
        }

        /// <summary>
        /// Overrides the message processor for the window so that we can respond
        /// to windows events to render and manipulate the tabs properly.
        /// </summary>
        /// <param name="m">Message received by the pump.</param>
        protected override void WndProc(ref Message m)
        {
            var flag = true;
            var msg = (WM)m.Msg;
            if (msg != (WM)6)
            {
                if (msg != (WM)132)
                {
                    if (msg == (WM)161 && m.WParam.ToInt32() == 8 &&
                        AeroPeekEnabled && SelectedTab != null)
                        UpdateTabThumbnail(SelectedTab);
                }
                else
                {
                    base.WndProc(ref m);
                    var hitTest = (HT)m.Result.ToInt32();
                    if (hitTest != (HT)20 && hitTest != (HT)8 &&
                        hitTest != (HT)9 && hitTest != (HT)5 &&
                        hitTest != (HT)3)
                        m.Result = new IntPtr((int)HitTest(m));
                    flag = false;
                }
            }
            else if ((m.WParam.ToInt64() & ushort.MaxValue) != 0L)
            {
                SetFrameSize();
                ResizeTabContents();
                m.Result = IntPtr.Zero;
            }

            if (!flag)
                return;
            base.WndProc(ref m);
        }

        /// <summary>
        /// Called to implement logic that is common to all the constructor(s) of this
        /// object.
        /// </summary>
        private void CommonConstruct()
        {
            InitializeComponent();
            SetWindowThemeAttributes((WTNCA)3);
            _tabs.CollectionModified += OnTabsCollectionModified;
            SetStyle(
                ControlStyles.ResizeRedraw |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer, true
            );
            Tooltip = new ToolTip { AutoPopDelay = 5000, AutomaticDelay = 500 };
            ShowTooltips = true;
        }

        /// <summary>
        /// Event handler that is called when a tab's
        /// <see cref="P:System.Windows.Forms.Form.Text" /> property is changed, which
        /// re-renders the tab text and updates the title of the
        /// Aero Peek preview.
        /// </summary>
        /// <param name="sender">
        /// Object from which this event originated (the
        /// <see cref="P:xyLOGIX.EasyTabs.TitleBarTab.Content" /> object in this case).
        /// </param>
        /// <param name="e">Arguments associated with the event.</param>
        private void Content_TextChanged(object sender, EventArgs e)
        {
            if (AeroPeekEnabled)
            {
                var thumbnailPreview =
                    TaskbarManager.Instance.TabbedThumbnail.GetThumbnailPreview(
                        (Control)sender
                    );
                if (thumbnailPreview != null)
                    thumbnailPreview.Title = (sender as Form).Text;
            }

            if (Overlay == null)
                return;
            Overlay.Render(true);
        }

        private HT HitTest(Message m)
        {
            var lparam = (int)m.LParam;
            return HitTest(
                new Point(lparam & ushort.MaxValue, lparam >> 16), m.HWnd
            );
        }

        /// <summary>
        /// Called when a <see cref="F:Win32Interop.Enums.WM.WM_NCHITTEST" />
        /// message is received to see where in the non-client area the user clicked.
        /// </summary>
        /// <param name="point">Screen location that we are to test.</param>
        /// <param name="windowHandle">
        /// Handle to the window for which we are performing the
        /// test.
        /// </param>
        /// <returns>
        /// One of the <see cref="T:Win32Interop.Enums.HT" /> values, depending on
        /// where the user clicked.
        /// </returns>
        private HT HitTest(Point point, IntPtr windowHandle)
        {
            User32.GetWindowRect(windowHandle, out var rect);
            var area = new Rectangle(
                rect.left, rect.top, rect.right - rect.left,
                rect.bottom - rect.top
            );

            var row = 1;
            var column = 1;
            var onResizeBorder = false;

            // Determine if we are on the top or bottom border
            if (point.Y >= area.Top && point.Y < area.Top +
                SystemInformation.VerticalResizeBorderThickness +
                _nonClientAreaHeight - 2)
            {
                onResizeBorder = point.Y < area.Top +
                    SystemInformation.VerticalResizeBorderThickness;
                row = 0;
            }
            else if (point.Y < area.Bottom && point.Y > area.Bottom -
                     SystemInformation.VerticalResizeBorderThickness)
            {
                row = 2;
            }

            // Determine if we are on the left border or the right border
            if (point.X >= area.Left && point.X < area.Left +
                SystemInformation.HorizontalResizeBorderThickness)
                column = 0;
            else if (point.X < area.Right && point.X >= area.Right -
                     SystemInformation.HorizontalResizeBorderThickness)
                column = 2;

            HT[,] hitTests =
            {
                {
                    onResizeBorder ? HT.HTTOPLEFT : HT.HTLEFT,
                    onResizeBorder ? HT.HTTOP : HT.HTCAPTION,
                    onResizeBorder ? HT.HTTOPRIGHT : HT.HTRIGHT
                },
                { HT.HTLEFT, HT.HTNOWHERE, HT.HTRIGHT },
                { HT.HTBOTTOMLEFT, HT.HTBOTTOM, HT.HTBOTTOMRIGHT }
            };

            return hitTests[row, column];
        }

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            SuspendLayout();
            AutoScaleDimensions = new SizeF(6f, 13f);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(284, 262);
            Name = "titleBarTabs";
            WindowState = FormWindowState.Maximized;
            ResumeLayout(false);
        }

        /// <summary>
        /// Callback that is invoked whenever anything is added or removed from
        /// <see cref="P:xyLOGIX.EasyTabs.TitleBarTabs.Tabs" /> so that we can trigger a
        /// redraw of
        /// the tabs.
        /// </summary>
        /// <param name="sender">Object for which this event was raised.</param>
        /// <param name="e">Arguments associated with the event.</param>
        private void OnTabsCollectionModified(
            object sender,
            ListModificationEventArgs e
        )
        {
            SetFrameSize();
            if (e.Modification == ListModification.ItemAdded ||
                e.Modification == ListModification.RangeAdded)
                for (var index = 0; index < e.Count; ++index)
                {
                    var tab = Tabs[index + e.StartIndex];
                    tab.Content.TextChanged += Content_TextChanged;
                    tab.Closing += TitleBarTabs_Closing;
                    if (AeroPeekEnabled)
                        TaskbarManager.Instance.TabbedThumbnail.SetActiveTab(
                            CreateThumbnailPreview(tab)
                        );
                }

            if (Overlay == null)
                return;
            Overlay.Render(true);
        }

        /// <summary>
        /// Calls
        /// <see
        ///     cref="M:Win32Interop.Methods.Uxtheme.SetWindowThemeAttribute(System.IntPtr,Win32Interop.Enums.WINDOWTHEMEATTRIBUTETYPE,Win32Interop.Structs.WTA_OPTIONS@,System.UInt32)" />
        /// to set various attributes on the window.
        /// </summary>
        /// <param name="attributes">Attributes to set on the window.</param>
        private void SetWindowThemeAttributes(WTNCA attributes)
        {
            var options = new WTA_OPTIONS
            {
                dwFlags = attributes, dwMask = WTNCA.VALIDBITS
            };

            // The SetWindowThemeAttribute API call takes care of everything
            Uxtheme.SetWindowThemeAttribute(
                Handle, WINDOWTHEMEATTRIBUTETYPE.WTA_NONCLIENT, ref options,
                (uint)Marshal.SizeOf(typeof(WTA_OPTIONS))
            );
        }

        /// <summary>
        /// Event handler that is called when a tab's
        /// <see cref="E:xyLOGIX.EasyTabs.TitleBarTab.Closing" /> event is fired, which
        /// removes the
        /// tab from <see cref="P:xyLOGIX.EasyTabs.TitleBarTabs.Tabs" /> and
        /// re-renders <see cref="F:xyLOGIX.EasyTabs.TitleBarTabs._overlay" />.
        /// </summary>
        /// <param name="sender">
        /// Object from which this event originated (the
        /// <see cref="T:xyLOGIX.EasyTabs.TitleBarTab" /> in this case).
        /// </param>
        /// <param name="e">Arguments associated with the event.</param>
        private void TitleBarTabs_Closing(object sender, CancelEventArgs e)
        {
            if (e.Cancel)
                return;
            var closingTab = (TitleBarTab)sender;
            CloseTab(closingTab);
            if (!closingTab.Content.IsDisposed && AeroPeekEnabled)
                TaskbarManager.Instance.TabbedThumbnail.RemoveThumbnailPreview(
                    closingTab.Content
                );
            if (Overlay == null)
                return;
            Overlay.Render(true);
        }
    }
}