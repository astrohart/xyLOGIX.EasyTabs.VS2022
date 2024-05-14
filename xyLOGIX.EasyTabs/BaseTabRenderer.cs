using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Win32Interop.Enums;

namespace xyLOGIX.EasyTabs
{
    /// <summary>
    /// Provides the base functionality for any tab renderer, taking care of actually
    /// rendering and detecting whether the cursor is over a tab.  Any custom
    /// tab renderer needs to inherit from this class, just as
    /// <see cref="T:xyLOGIX.EasyTabs.ChromeTabRenderer" /> does.
    /// </summary>
    public abstract class BaseTabRenderer
    {
        /// <summary>
        /// Background of the content area for the tab when the tab is active; its width
        /// also determines how wide the default content area for the tab
        /// is.
        /// </summary>
        protected Image _activeCenterImage;

        /// <summary>Image to display on the left side of an active tab.</summary>
        protected Image _activeLeftSideImage;

        /// <summary>Image to display on the right side of an active tab.</summary>
        protected Image _activeRightSideImage;

        /// <summary>Area on the screen where the add button is located.</summary>
        protected Rectangle _addButtonArea;

        /// <summary>Image to display when the user hovers over the add button.</summary>
        protected Bitmap _addButtonHoverImage;

        /// <summary>
        /// Image to display for the add button when the user is not hovering over
        /// it.
        /// </summary>
        protected Bitmap _addButtonImage;

        /// <summary>
        /// The background, if any, that should be displayed in the non-client
        /// area behind the actual tabs.
        /// </summary>
        protected Image _background;

        /// <summary>
        /// The hover-over image that should be displayed on each tab to close
        /// that tab.
        /// </summary>
        protected Image _closeButtonHoverImage;

        /// <summary>The image that should be displayed on each tab to close that tab.</summary>
        protected Image _closeButtonImage;

        /// <summary>
        /// When the user is dragging a tab, this represents the point where the
        /// user first clicked to start the drag operation.
        /// </summary>
        protected Point? _dragStart;

        /// <summary>
        /// Background of the content area for the tab when the tab is inactive; its width
        /// also determines how wide the default content area for the tab
        /// is.
        /// </summary>
        protected Image _inactiveCenterImage;

        /// <summary>Image to display on the left side of an inactive tab.</summary>
        protected Image _inactiveLeftSideImage;

        /// <summary>Image to display on the right side of an inactive tab.</summary>
        protected Image _inactiveRightSideImage;

        /// <summary>Flag indicating whether a tab is being repositioned.</summary>
        protected bool _isTabRepositioning;

        private bool? _isWindows10;

        /// <summary>Maximum area on the screen that tabs may take up for this application.</summary>
        protected Rectangle _maxTabArea;

        /// <summary>The parent window that this renderer instance belongs to.</summary>
        protected TitleBarTabs _parentWindow;

        /// <summary>
        /// The number of tabs that were present when we last rendered; used to
        /// determine whether we need to redraw tab instances.
        /// </summary>
        protected int _previousTabCount;

        /// <summary>
        /// Flag indicating whether rendering has been suspended while we
        /// perform some operation.
        /// </summary>
        protected bool _suspendRendering;

        /// <summary>
        /// When the user is dragging a tab, this represents the horizontal offset
        /// within the tab where the user clicked to start the drag operation.
        /// </summary>
        protected int? _tabClickOffset;

        /// <summary>The width of the content area that we should use for each tab.</summary>
        protected int _tabContentWidth;

        /// <summary>Flag indicating whether a tab was being repositioned.</summary>
        protected bool _wasTabRepositioning;

        protected Color ForeColor = Color.White;

        /// <summary>
        /// Default constructor that initializes the
        /// <see cref="F:xyLOGIX.EasyTabs.BaseTabRenderer._parentWindow" /> and
        /// <see cref="P:xyLOGIX.EasyTabs.BaseTabRenderer.ShowAddButton" /> properties.
        /// </summary>
        /// <param name="parentWindow">
        /// The parent window that this renderer instance
        /// belongs to.
        /// </param>
        protected BaseTabRenderer(TitleBarTabs parentWindow)
        {
            _parentWindow = parentWindow;
            ShowAddButton = true;
            TabRepositionDragDistance = 10;
            TabTearDragDistance = 10;
            parentWindow.Tabs.CollectionModified += Tabs_CollectionModified;
            if (parentWindow._overlay == null)
                return;
            parentWindow._overlay.MouseMove += OnOverlayMouseMove;
            parentWindow._overlay.MouseUp += OnOverlayMouseUp;
            parentWindow._overlay.MouseDown += OnOverlayMouseDown;
        }

        /// <summary>
        /// Amount of space that we should put to the left of the add tab button
        /// when rendering the content area of the tab.
        /// </summary>
        public virtual int AddButtonMarginLeft { get; set; }

        /// <summary>
        /// Amount of space that we should leave to the right of the add tab
        /// button when rendering the content area of the tab.
        /// </summary>
        public virtual int AddButtonMarginRight { get; set; }

        /// <summary>
        /// Amount of space that we should leave between the top of the content
        /// area and the top of the add tab button.
        /// </summary>
        public virtual int AddButtonMarginTop { get; set; }

        public virtual Font CaptionFont
            => SystemFonts.CaptionFont;

        /// <summary>
        /// Amount of space we should put to the left of the caption when
        /// rendering the content area of the tab.
        /// </summary>
        public virtual int CaptionMarginLeft { get; set; }

        /// <summary>
        /// Amount of space that we should leave to the right of the caption when
        /// rendering the content area of the tab.
        /// </summary>
        public virtual int CaptionMarginRight { get; set; }

        /// <summary>
        /// Amount of space that we should leave between the top of the content
        /// area and the top of the caption text.
        /// </summary>
        public virtual int CaptionMarginTop { get; set; }

        /// <summary>
        /// Amount of space that we should put to the left of the close button
        /// when rendering the content area of the tab.
        /// </summary>
        public virtual int CloseButtonMarginLeft { get; set; }

        /// <summary>
        /// Amount of space that we should leave to the right of the close button
        /// when rendering the content area of the tab.
        /// </summary>
        public virtual int CloseButtonMarginRight { get; set; }

        /// <summary>
        /// Amount of space that we should leave between the top of the content
        /// area and the top of the close button.
        /// </summary>
        public virtual int CloseButtonMarginTop { get; set; }

        /// <summary>
        /// Amount of space we should put to the left of the tab icon when
        /// rendering the content area of the tab.
        /// </summary>
        public virtual int IconMarginLeft { get; set; }

        /// <summary>
        /// Amount of space that we should leave to the right of the icon when
        /// rendering the content area of the tab.
        /// </summary>
        public virtual int IconMarginRight { get; set; }

        /// <summary>
        /// Amount of space that we should leave between the top of the content
        /// area and the top of the icon.
        /// </summary>
        public virtual int IconMarginTop { get; set; }

        /// <summary>Flag indicating whether a tab is being repositioned.</summary>
        public bool IsTabRepositioning
        {
            get => _isTabRepositioning;
            internal set
            {
                _isTabRepositioning = value;
                if (_isTabRepositioning)
                    return;
                _dragStart = new Point?();
            }
        }

        public bool IsWindows10
        {
            get
            {
                if (!_isWindows10.HasValue)
                    _isWindows10 = ((string)Registry
                                            .LocalMachine.OpenSubKey(
                                                "SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion"
                                            )
                                            .GetValue("ProductName"))
                        .StartsWith("Windows 10");
                return _isWindows10.Value;
            }
        }

        /// <summary>Maximum area that the tabs can occupy.  Excludes the add button.</summary>
        public Rectangle MaxTabArea
            => _maxTabArea;

        /// <summary>
        /// If the renderer overlaps the tabs (like Chrome), this is the width that the
        /// tabs should overlap by.  For renderers that do not overlap tabs (like
        /// Firefox), this should be left at 0.
        /// </summary>
        public virtual int OverlapWidth
            => 0;

        public virtual bool RendersEntireTitleBar
            => false;

        /// <summary>Flag indicating whether we should display the add button.</summary>
        public virtual bool ShowAddButton { get; set; }

        /// <summary>Width of the content area of the tabs.</summary>
        public int TabContentWidth
            => _tabContentWidth;

        /// <summary>
        /// Height of the tab content area; derived from the height of
        /// <see cref="F:xyLOGIX.EasyTabs.BaseTabRenderer._activeCenterImage" />.
        /// </summary>
        public virtual int TabHeight
            => _activeCenterImage.Height;

        /// <summary>
        /// Horizontal distance that a tab must be dragged before it starts to be
        /// repositioned.
        /// </summary>
        public virtual int TabRepositionDragDistance { get; set; }

        /// <summary>
        /// Distance that a user must drag a tab outside the tab area before it
        /// shows up as "torn" from its parent window.
        /// </summary>
        public virtual int TabTearDragDistance { get; set; }

        public virtual int TopPadding
            => 0;

        /// <summary>
        /// Tests whether the <paramref name="cursor" /> is hovering over the add
        /// tab button.
        /// </summary>
        /// <param name="cursor">Current location of the cursor.</param>
        /// <returns>
        /// True if the <paramref name="cursor" /> is within
        /// <see cref="F:xyLOGIX.EasyTabs.BaseTabRenderer._addButtonArea" /> and is over a
        /// non-transparent pixel of
        /// <see cref="F:xyLOGIX.EasyTabs.BaseTabRenderer._addButtonHoverImage" />, false
        /// otherwise.
        /// </returns>
        public virtual bool IsOverAddButton(Point cursor)
            => !_wasTabRepositioning && IsOverNonTransparentArea(
                _addButtonArea, _addButtonHoverImage, cursor
            );

        /// <summary>
        /// Checks to see if the <paramref name="cursor" /> is over the
        /// <see cref="P:xyLOGIX.EasyTabs.TitleBarTab.CloseButtonArea" /> of the given
        /// <paramref name="tab" />.
        /// </summary>
        /// <param name="tab">
        /// The tab whose
        /// <see cref="P:xyLOGIX.EasyTabs.TitleBarTab.CloseButtonArea" /> we are to check to see if
        /// it contains <paramref name="cursor" />.
        /// </param>
        /// <param name="cursor">Current position of the cursor.</param>
        /// <returns>
        /// True if the <paramref name="tab" />'s
        /// <see cref="P:xyLOGIX.EasyTabs.TitleBarTab.CloseButtonArea" /> contains
        /// <paramref name="cursor" />, false otherwise.
        /// </returns>
        public virtual bool IsOverCloseButton(TitleBarTab tab, Point cursor)
            => tab.ShowCloseButton && !_wasTabRepositioning && new Rectangle(
                tab.Area.X + tab.CloseButtonArea.X,
                tab.Area.Y + tab.CloseButtonArea.Y, tab.CloseButtonArea.Width,
                tab.CloseButtonArea.Height
            ).Contains(cursor);

        public virtual bool IsOverSizingBox(Point cursor)
            => false;

        public virtual HT NonClientHitTest(Message message, Point cursor)
            => (HT)2;

        /// <summary>
        /// Called from the <see cref="F:xyLOGIX.EasyTabs.BaseTabRenderer._parentWindow" /> to
        /// determine which, if any, of the <paramref name="tabs" /> the
        /// <paramref name="cursor" /> is
        /// over.
        /// </summary>
        /// <param name="tabs">The list of tabs that we should check.</param>
        /// <param name="cursor">The relative position of the cursor within the window.</param>
        /// <returns>
        /// The tab within <paramref name="tabs" /> that the
        /// <paramref name="cursor" /> is over; if none, then null is returned.
        /// </returns>
        public virtual TitleBarTab OverTab(
            IEnumerable<TitleBarTab> tabs,
            Point cursor
        )
        {
            TitleBarTab titleBarTab = null;
            foreach (var tab in tabs.Where(tab => tab.TabImage != null))
            {
                if (tab.Active && IsOverTab(tab, cursor))
                {
                    titleBarTab = tab;
                    break;
                }

                if (IsOverTab(tab, cursor))
                    titleBarTab = tab;
            }

            return titleBarTab;
        }

        /// <summary>
        /// Renders the list of <paramref name="tabs" /> to the screen using the
        /// given <paramref name="graphicsContext" />.
        /// </summary>
        /// <param name="tabs">List of tabs that we are to render.</param>
        /// <param name="graphicsContext">
        /// Graphics context that we should use while
        /// rendering.
        /// </param>
        /// <param name="cursor">Current location of the cursor on the screen.</param>
        /// <param name="forceRedraw">
        /// Flag indicating whether the redraw should be
        /// forced.
        /// </param>
        /// <param name="offset">
        /// Offset within <paramref name="graphicsContext" /> that the
        /// tabs should be rendered.
        /// </param>
        public virtual void Render(
            List<TitleBarTab> tabs,
            Graphics graphicsContext,
            Point offset,
            Point cursor,
            bool forceRedraw = false
        )
        {
            if (_suspendRendering || tabs == null || tabs.Count == 0)
                return;
            var screen =
                _parentWindow.PointToScreen(
                    _parentWindow.ClientRectangle.Location
                );
            _maxTabArea.Location = new Point(
                SystemInformation.BorderSize.Width + offset.X + screen.X,
                offset.Y + screen.Y
            );
            _maxTabArea.Width = GetMaxTabAreaWidth(tabs, offset);
            _maxTabArea.Height = TabHeight;
            var num1 = Math.Min(
                _activeCenterImage.Width,
                Convert.ToInt32(
                    Math.Floor(Convert.ToDouble(_maxTabArea.Width / tabs.Count))
                )
            );
            var flag1 = (num1 != _tabContentWidth) | forceRedraw;
            if (flag1)
                _tabContentWidth = num1;
            var index1 = tabs.Count - 1;
            var tupleList = new List<Tuple<TitleBarTab, int, Rectangle>>();
            if (_background != null)
                graphicsContext.DrawImage(
                    _background, offset.X, offset.Y, _parentWindow.Width,
                    TabHeight
                );
            var index2 = tabs.FindIndex(t => t.Active);
            Image tabCenterImage = null;
            Size size;
            if (index2 != -1)
            {
                var tab1 = tabs[index2];
                var tabLeftImage = GetTabLeftImage(tab1);
                var tabRightImage = GetTabRightImage(tab1);
                tabCenterImage = GetTabCenterImage(tab1);
                var rectangle = Rectangle.Empty;
                ref var local1 = ref rectangle;
                size = SystemInformation.BorderSize;
                var x1 = size.Width + offset.X + index2 *
                    (num1 + tabLeftImage.Width + tabRightImage.Width -
                     OverlapWidth);
                var y = offset.Y + (TabHeight - tabCenterImage.Height);
                var width1 = num1 + tabLeftImage.Width + tabRightImage.Width;
                var height = tabCenterImage.Height;
                local1 = new Rectangle(x1, y, width1, height);
                if (IsTabRepositioning && _tabClickOffset.HasValue)
                {
                    rectangle.X = cursor.X - _tabClickOffset.Value;
                    ref var local2 = ref rectangle;
                    size = SystemInformation.BorderSize;
                    var num2 = Math.Max(size.Width + offset.X, rectangle.X);
                    local2.X = num2;
                    ref var local3 = ref rectangle;
                    size = SystemInformation.BorderSize;
                    var width2 = size.Width;
                    int num3;
                    if (_parentWindow.WindowState != FormWindowState.Maximized)
                    {
                        num3 = _parentWindow.ClientRectangle.Width;
                    }
                    else
                    {
                        var width3 = _parentWindow.ClientRectangle.Width;
                        int num4;
                        if (!_parentWindow.ControlBox)
                        {
                            num4 = 0;
                        }
                        else
                        {
                            size = SystemInformation.CaptionButtonSize;
                            num4 = size.Width;
                        }

                        var num5 = width3 - num4;
                        int num6;
                        if (!_parentWindow.MinimizeBox)
                        {
                            num6 = 0;
                        }
                        else
                        {
                            size = SystemInformation.CaptionButtonSize;
                            num6 = size.Width;
                        }

                        var num7 = num5 - num6;
                        int num8;
                        if (!_parentWindow.MaximizeBox)
                        {
                            num8 = 0;
                        }
                        else
                        {
                            size = SystemInformation.CaptionButtonSize;
                            num8 = size.Width;
                        }

                        num3 = num7 - num8;
                    }

                    var num9 = Math.Min(
                        width2 + num3 - rectangle.Width, rectangle.X
                    );
                    local3.X = num9;
                    var index3 = 0;
                    var x2 = rectangle.X;
                    size = SystemInformation.BorderSize;
                    var width4 = size.Width;
                    if (x2 - width4 - offset.X - TabRepositionDragDistance > 0)
                    {
                        var x3 = rectangle.X;
                        size = SystemInformation.BorderSize;
                        var width5 = size.Width;
                        index3 = Math.Min(
                            Convert.ToInt32(
                                Math.Round(
                                    Convert.ToDouble(
                                        x3 - width5 - offset.X -
                                        TabRepositionDragDistance
                                    ) / Convert.ToDouble(
                                        rectangle.Width - OverlapWidth
                                    )
                                )
                            ), tabs.Count - 1
                        );
                    }

                    if (index3 != index2)
                    {
                        var tab2 = tabs[index2];
                        _parentWindow.Tabs.SuppressEvents();
                        _parentWindow.Tabs.Remove(tab2);
                        _parentWindow.Tabs.Insert(index3, tab2);
                        _parentWindow.Tabs.ResumeEvents();
                    }
                }

                tupleList.Add(
                    new Tuple<TitleBarTab, int, Rectangle>(
                        tabs[index2], index2, rectangle
                    )
                );
            }

            foreach (var tab in tabs.Reverse<TitleBarTab>())
            {
                var tabLeftImage = GetTabLeftImage(tab);
                tabCenterImage = GetTabCenterImage(tab);
                var tabRightImage = GetTabRightImage(tab);
                var area = Rectangle.Empty;
                ref var local = ref area;
                size = SystemInformation.BorderSize;
                var x = size.Width + offset.X + index1 * (num1 +
                    tabLeftImage.Width + tabRightImage.Width - OverlapWidth);
                var y = offset.Y + (TabHeight - tabCenterImage.Height);
                var width = num1 + tabLeftImage.Width + tabRightImage.Width;
                var height = tabCenterImage.Height;
                local = new Rectangle(x, y, width, height);
                if (flag1)
                    tab.TabImage = null;
                if (!tab.Active)
                    Render(
                        graphicsContext, tab, index1, area, cursor,
                        tabLeftImage, tabCenterImage, tabRightImage
                    );
                --index1;
            }

            foreach (var tuple in tupleList)
            {
                var tabLeftImage = GetTabLeftImage(tuple.Item1);
                tabCenterImage = GetTabCenterImage(tuple.Item1);
                var tabRightImage = GetTabRightImage(tuple.Item1);
                Render(
                    graphicsContext, tuple.Item1, tuple.Item2, tuple.Item3,
                    cursor, tabLeftImage, tabCenterImage, tabRightImage
                );
            }

            _previousTabCount = tabs.Count;
            if (!ShowAddButton || IsTabRepositioning)
                return;
            _addButtonArea = new Rectangle(
                _previousTabCount * (num1 + _activeLeftSideImage.Width +
                    _activeRightSideImage.Width - OverlapWidth) +
                _activeRightSideImage.Width + AddButtonMarginLeft + offset.X,
                AddButtonMarginTop + offset.Y +
                (TabHeight - tabCenterImage.Height), _addButtonImage.Width,
                _addButtonImage.Height
            );
            var flag2 = IsOverAddButton(cursor);
            graphicsContext.DrawImage(
                flag2 ? _addButtonHoverImage : (Image)_addButtonImage,
                _addButtonArea, 0, 0,
                flag2 ? _addButtonHoverImage.Width : _addButtonImage.Width,
                flag2 ? _addButtonHoverImage.Height : _addButtonImage.Height,
                GraphicsUnit.Pixel
            );
        }

        /// <summary>
        /// Called when a torn tab is dragged into the
        /// <see cref="P:xyLOGIX.EasyTabs.TitleBarTabs.TabDropArea" /> of
        /// <see cref="F:xyLOGIX.EasyTabs.BaseTabRenderer._parentWindow" />.  Places the tab in the
        /// list and
        /// sets <see cref="P:xyLOGIX.EasyTabs.BaseTabRenderer.IsTabRepositioning" /> to true to
        /// simulate the user continuing to drag the tab around in the window.
        /// </summary>
        /// <param name="tab">Tab that was dragged into this window.</param>
        /// <param name="cursorLocation">Location of the user's cursor.</param>
        internal virtual void CombineTab(TitleBarTab tab, Point cursorLocation)
        {
            _suspendRendering = true;
            var index = _parentWindow.Tabs.FindIndex(
                t => t.Area.Left <= cursorLocation.X &&
                     t.Area.Right >= cursorLocation.X
            );
            _tabClickOffset = _parentWindow.Tabs.Count <= 0
                ? 0
                : _parentWindow.Tabs.First()
                               .Area.Width / 2;
            IsTabRepositioning = true;
            tab.Parent = _parentWindow;
            if (index == -1)
            {
                _parentWindow.Tabs.Add(tab);
                index = _parentWindow.Tabs.Count - 1;
            }
            else
            {
                _parentWindow.Tabs.Insert(index, tab);
            }

            _suspendRendering = false;
            _parentWindow.SelectedTabIndex = index;
            _parentWindow.ResizeTabContents();
        }

        /// <summary>
        /// Initialize the <see cref="F:xyLOGIX.EasyTabs.BaseTabRenderer._dragStart" />
        /// and <see cref="F:xyLOGIX.EasyTabs.BaseTabRenderer._tabClickOffset" /> fields in case
        /// the user starts dragging a tab.
        /// </summary>
        /// <param name="sender">Object from which this event originated.</param>
        /// <param name="e">Arguments associated with the event.</param>
        protected internal virtual void OnOverlayMouseDown(
            object sender,
            MouseEventArgs e
        )
        {
            _wasTabRepositioning = false;
            _dragStart = e.Location;
            var point =
                _parentWindow._overlay.GetRelativeCursorPosition(e.Location);
            var x1 = point.X;
            point = _parentWindow.SelectedTab.Area.Location;
            var x2 = point.X;
            _tabClickOffset = x1 - x2;
        }

        /// <summary>
        /// If the user is dragging the mouse, see if they have passed the
        /// <see cref="P:xyLOGIX.EasyTabs.BaseTabRenderer.TabRepositionDragDistance" /> threshold
        /// and, if so, officially begin the
        /// tab drag operation.
        /// </summary>
        /// <param name="sender">Object from which this event originated.</param>
        /// <param name="e">Arguments associated with the event.</param>
        protected internal virtual void OnOverlayMouseMove(
            object sender,
            MouseEventArgs e
        )
        {
            if (!_dragStart.HasValue || IsTabRepositioning)
                return;
            var x1 = e.X;
            var point = _dragStart.Value;
            var x2 = point.X;
            if (Math.Abs(x1 - x2) <= TabRepositionDragDistance)
            {
                var y1 = e.Y;
                point = _dragStart.Value;
                var y2 = point.Y;
                if (Math.Abs(y1 - y2) <= TabRepositionDragDistance)
                    return;
            }

            IsTabRepositioning = true;
        }

        /// <summary>
        /// End the drag operation by resetting the
        /// <see cref="F:xyLOGIX.EasyTabs.BaseTabRenderer._dragStart" /> and
        /// <see cref="F:xyLOGIX.EasyTabs.BaseTabRenderer._tabClickOffset" /> fields and setting
        /// <see cref="P:xyLOGIX.EasyTabs.BaseTabRenderer.IsTabRepositioning" /> to false.
        /// </summary>
        /// <param name="sender">Object from which this event originated.</param>
        /// <param name="e">Arguments associated with the event.</param>
        protected internal virtual void OnOverlayMouseUp(
            object sender,
            MouseEventArgs e
        )
        {
            _dragStart = new Point?();
            _tabClickOffset = new int?();
            _wasTabRepositioning = IsTabRepositioning;
            IsTabRepositioning = false;
            if (!_wasTabRepositioning)
                return;
            _parentWindow._overlay.Render(true);
        }

        protected virtual int GetMaxTabAreaWidth(
            List<TitleBarTab> tabs,
            Point offset
        )
            => _parentWindow.ClientRectangle.Width - offset.X -
               (ShowAddButton
                   ? _addButtonImage.Width + AddButtonMarginLeft +
                     AddButtonMarginRight
                   : 0) - tabs.Count * OverlapWidth -
               (_parentWindow.ControlBox
                   ? SystemInformation.CaptionButtonSize.Width
                   : 0) - (_parentWindow.MinimizeBox
                   ? SystemInformation.CaptionButtonSize.Width
                   : 0) - (_parentWindow.MaximizeBox
                   ? SystemInformation.CaptionButtonSize.Width
                   : 0);

        /// <summary>
        /// Gets the image to use for the center of the <paramref name="tab" />.
        /// </summary>
        /// <param name="tab">Tab that we are retrieving the image for.</param>
        /// <returns>The image for the center of <paramref name="tab" />.</returns>
        protected virtual Image GetTabCenterImage(TitleBarTab tab)
            => !tab.Active ? _inactiveCenterImage : _activeCenterImage;

        /// <summary>
        /// Gets the image to use for the left side of the <paramref name="tab" />.
        /// </summary>
        /// <param name="tab">Tab that we are retrieving the image for.</param>
        /// <returns>The image for the left side of <paramref name="tab" />.</returns>
        protected virtual Image GetTabLeftImage(TitleBarTab tab)
            => !tab.Active ? _inactiveLeftSideImage : _activeLeftSideImage;

        /// <summary>
        /// Gets the image to use for the right side of the <paramref name="tab" />.
        /// </summary>
        /// <param name="tab">Tab that we are retrieving the image for.</param>
        /// <returns>The image for the right side of <paramref name="tab" />.</returns>
        protected virtual Image GetTabRightImage(TitleBarTab tab)
            => !tab.Active ? _inactiveRightSideImage : _activeRightSideImage;

        /// <summary>
        /// Helper method to detect whether the <paramref name="cursor" /> is within the
        /// given <paramref name="area" /> and, if it is, whether it is over a
        /// non-transparent pixel in the given <paramref name="image" />.
        /// </summary>
        /// <param name="area">
        /// Screen area that we should check to see if the
        /// <paramref name="cursor" /> is within.
        /// </param>
        /// <param name="image">
        /// Image contained within <paramref name="area" /> that we should check to see if
        /// the <paramref name="cursor" /> is over a non-transparent
        /// pixel.
        /// </param>
        /// <param name="cursor">Current location of the cursor.</param>
        /// <returns>
        /// True if the <paramref name="cursor" /> is within the given
        /// <paramref name="area" /> and is over a non-transparent pixel in the
        /// <paramref name="image" />.
        /// </returns>
        protected bool IsOverNonTransparentArea(
            Rectangle area,
            Bitmap image,
            Point cursor
        )
        {
            if (!area.Contains(cursor))
                return false;
            var x1 = cursor.X;
            var location = area.Location;
            var x2 = location.X;
            var x3 = x1 - x2;
            var y1 = cursor.Y;
            location = area.Location;
            var y2 = location.Y;
            var y3 = y1 - y2;
            var point = new Point(x3, y3);
            return image.GetPixel(point.X, point.Y)
                        .A > 0;
        }

        /// <summary>
        /// Tests whether the <paramref name="cursor" /> is hovering over the
        /// given <paramref name="tab" />.
        /// </summary>
        /// <param name="tab">Tab that we are to see if the cursor is hovering over.</param>
        /// <param name="cursor">Current location of the cursor.</param>
        /// <returns>
        /// True if the <paramref name="cursor" /> is within the
        /// <see cref="P:xyLOGIX.EasyTabs.TitleBarTab.Area" /> of the <paramref name="tab" /> and
        /// is over a non-transparent
        /// pixel of <see cref="P:xyLOGIX.EasyTabs.TitleBarTab.TabImage" />, false otherwise.
        /// </returns>
        protected virtual bool IsOverTab(TitleBarTab tab, Point cursor)
            => IsOverNonTransparentArea(tab.Area, tab.TabImage, cursor);

        /// <summary>
        /// Internal method for rendering an individual <paramref name="tab" /> to
        /// the screen.
        /// </summary>
        /// <param name="graphicsContext">Graphics context to use when rendering the tab.</param>
        /// <param name="tab">Individual tab that we are to render.</param>
        /// <param name="area">Area of the screen that the tab should be rendered to.</param>
        /// <param name="cursor">Current position of the cursor.</param>
        /// <param name="tabLeftImage">Image to use for the left side of the tab.</param>
        /// <param name="tabCenterImage">Image to use for the center of the tab.</param>
        /// <param name="tabRightImage">Image to use for the right side of the tab.</param>
        protected virtual void Render(
            Graphics graphicsContext,
            TitleBarTab tab,
            int index,
            Rectangle area,
            Point cursor,
            Image tabLeftImage,
            Image tabCenterImage,
            Image tabRightImage
        )
        {
            if (_suspendRendering)
                return;
            if (tab.TabImage == null)
            {
                tab.TabImage = new Bitmap(
                    area.Width <= 0 ? 1 : area.Width,
                    tabCenterImage.Height <= 0 ? 1 : tabCenterImage.Height
                );
                using (var graphics = Graphics.FromImage(tab.TabImage))
                {
                    graphics.DrawImage(
                        tabLeftImage,
                        new Rectangle(
                            0, 0, tabLeftImage.Width, tabLeftImage.Height
                        ), 0, 0, tabLeftImage.Width, tabLeftImage.Height,
                        GraphicsUnit.Pixel
                    );
                    graphics.DrawImage(
                        tabCenterImage,
                        new Rectangle(
                            tabLeftImage.Width, 0, _tabContentWidth,
                            tabCenterImage.Height
                        ), 0, 0, _tabContentWidth, tabCenterImage.Height,
                        GraphicsUnit.Pixel
                    );
                    graphics.DrawImage(
                        tabRightImage,
                        new Rectangle(
                            tabLeftImage.Width + _tabContentWidth, 0,
                            tabRightImage.Width, tabRightImage.Height
                        ), 0, 0, tabRightImage.Width, tabRightImage.Height,
                        GraphicsUnit.Pixel
                    );
                    if (tab.ShowCloseButton)
                    {
                        var image = IsOverCloseButton(tab, cursor)
                            ? _closeButtonHoverImage
                            : _closeButtonImage;
                        tab.CloseButtonArea = new Rectangle(
                            area.Width - tabRightImage.Width -
                            CloseButtonMarginRight - image.Width,
                            CloseButtonMarginTop, image.Width, image.Height
                        );
                        graphics.DrawImage(
                            image, tab.CloseButtonArea, 0, 0, image.Width,
                            image.Height, GraphicsUnit.Pixel
                        );
                    }
                }

                tab.Area = area;
            }

            graphicsContext.DrawImage(
                tab.TabImage, area, 0, 0, tab.TabImage.Width,
                tab.TabImage.Height, GraphicsUnit.Pixel
            );
            if (tab.Content.ShowIcon && _tabContentWidth > 16 + IconMarginLeft +
                (tab.ShowCloseButton
                    ? CloseButtonMarginLeft + tab.CloseButtonArea.Width +
                      CloseButtonMarginRight
                    : 0))
                graphicsContext.DrawIcon(
                    new Icon(tab.Content.Icon, 16, 16),
                    new Rectangle(
                        area.X + OverlapWidth + IconMarginLeft,
                        IconMarginTop + area.Y, 16, 16
                    )
                );
            if (_tabContentWidth <=
                (tab.Content.ShowIcon
                    ? 16 + IconMarginLeft + IconMarginRight
                    : 0) + CaptionMarginLeft + CaptionMarginRight +
                (tab.ShowCloseButton
                    ? CloseButtonMarginLeft + tab.CloseButtonArea.Width +
                      CloseButtonMarginRight
                    : 0))
                return;
            graphicsContext.DrawString(
                tab.Caption, CaptionFont, new SolidBrush(ForeColor),
                new Rectangle(
                    area.X + OverlapWidth + CaptionMarginLeft +
                    (tab.Content.ShowIcon
                        ? IconMarginLeft + 16 + IconMarginRight
                        : 0), CaptionMarginTop + area.Y,
                    _tabContentWidth -
                    (tab.Content.ShowIcon
                        ? IconMarginLeft + 16 + IconMarginRight
                        : 0) - (tab.ShowCloseButton
                        ? _closeButtonImage.Width + CloseButtonMarginRight +
                          CloseButtonMarginLeft
                        : 0), tab.TabImage.Height
                ),
                new StringFormat(StringFormatFlags.NoWrap)
                {
                    Trimming = StringTrimming.EllipsisCharacter
                }
            );
        }

        /// <summary>
        /// When items are added to the tabs collection, we need to ensure that the
        /// <see cref="F:xyLOGIX.EasyTabs.BaseTabRenderer._parentWindow" />'s minimum width is set
        /// so that we can display at
        /// least each tab and its close buttons.
        /// </summary>
        /// <param name="sender">
        /// List of tabs in the
        /// <see cref="F:xyLOGIX.EasyTabs.BaseTabRenderer._parentWindow" />.
        /// </param>
        /// <param name="e">Arguments associated with the event.</param>
        private void Tabs_CollectionModified(
            object sender,
            ListModificationEventArgs e
        )
        {
            var source = (ListWithEvents<TitleBarTab>)sender;
            if (source.Count == 0)
                return;
            var num1 = source.Sum(
                tab => GetTabLeftImage(tab)
                           .Width + GetTabRightImage(tab)
                           .Width +
                       (tab.ShowCloseButton
                           ? tab.CloseButtonArea.Width + CloseButtonMarginLeft
                           : 0)
            ) + OverlapWidth;
            Size captionButtonSize;
            int num2;
            if (!_parentWindow.ControlBox)
            {
                num2 = 0;
            }
            else
            {
                captionButtonSize = SystemInformation.CaptionButtonSize;
                num2 = captionButtonSize.Width;
            }

            int num3;
            if (!_parentWindow.MinimizeBox)
            {
                num3 = 0;
            }
            else
            {
                captionButtonSize = SystemInformation.CaptionButtonSize;
                num3 = captionButtonSize.Width;
            }

            var num4 = num2 - num3;
            int num5;
            if (!_parentWindow.MaximizeBox)
            {
                num5 = 0;
            }
            else
            {
                captionButtonSize = SystemInformation.CaptionButtonSize;
                num5 = captionButtonSize.Width;
            }

            var num6 = num4 - num5 + (ShowAddButton
                ? _addButtonImage.Width + AddButtonMarginLeft +
                  AddButtonMarginRight
                : 0);
            _parentWindow.MinimumSize = new Size(num1 + num6, 0);
        }
    }
}