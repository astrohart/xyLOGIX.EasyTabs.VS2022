using PostSharp.Patterns.Diagnostics;
using System.Diagnostics;
using Core.Extensions;
using Core.Logging;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Win32Interop.Enums;

namespace xyLOGIX.EasyTabs
{
    /// <summary>
    /// Provides the base functionality for any <c>TabRenderer</c>, taking
    /// care of actually rendering and detecting whether the cursor is over a tab.  Any
    /// custom tab renderer needs to inherit from this class, just as
    /// <see cref="T:xyLOGIX.EasyTabs.ChromeTabRenderer" /> does.
    /// </summary>
    public abstract class TabRendererBase
    {
        /// <summary>
        /// Flag indicating whether the <b>Add</b> button is to be shown.
        /// </summary>
        /// <remarks>The default value of this flag is <see langword="true" />.</remarks>
        private bool _addButtonShown = true;

        /// <summary>
        /// A <see cref="T:System.Drawing.Color" /> value that is to be used for the text
        /// of the tabs.
        /// </summary>
        /// <remarks>
        /// The default value of this field is
        /// <see cref="F:System.Drawing.Color.White" />.
        /// </remarks>
        private Color _foreColor = Color.White;

        /// <summary>Flag indicating whether a tab is being repositioned.</summary>
        /// <remarks>
        /// This flag is used by the
        /// <see cref="P:xyLOGIX.EasyTabs.TabRendererBase.IsTabRepositioning" /> property
        /// to detect whether its value has been updated.
        /// </remarks>
        protected bool _isTabRepositioning;

        /// <summary>
        /// A <see cref="T:System.Drawing.Rectangle" /> value that demarcates the maximum
        /// area on the screen that a given tabs, as a set, may occupy, excluding the
        /// <b>Add</b> button.
        /// </summary>
        /// <remarks>
        /// This flag is used by the
        /// <see cref="P:xyLOGIX.EasyTabs.TabRendererBase.MaxTabWellArea" /> property to
        /// tell when the value of the property has been updated.
        /// </remarks>
        private Rectangle _maxTabWellWellArea;

        /// <summary>
        /// Count of tabs that were present when we last rendered.
        /// </summary>
        /// <remarks>
        /// Used to determine whether we need to redraw the tabs.
        /// <para />
        /// This field is used by the
        /// <see cref="P:xyLOGIX.EasyTabs.TabRendererBase.PreviousTabCount" /> property to
        /// determine when its value has been altered.
        /// </remarks>
        private int _previousTabCount;

        /// <summary>
        /// Flag indicating whether rendering has been suspended while we perform some
        /// operation.
        /// </summary>
        /// <remarks>
        /// The field is used by the
        /// <see cref="P:xyLOGIX.EasyTabs.TabRendererBase.RenderingSuspended" /> property
        /// in order to determine whether its value has been altered.
        /// </remarks>
        protected bool _suspendRendering;

        /// <summary>
        /// A <see cref="T:System.Drawing.Color" /> value that is to be used for the
        /// background color of each of the tabs.
        /// </summary>
        private Color _tabBackColor;

        /// <summary>
        /// Value indicating the horizontal offset within the tab where the user clicked to
        /// start a <c>Drag</c> operation.
        /// </summary>
        /// <remarks>
        /// The default value of this field is <c>-1</c>, for
        /// <c>not applicable</c>.
        /// <para />
        /// This field is used by the
        /// <see cref="P:xyLOGIX.EasyTabs.TabRendererBase.TabClickOffset" /> property to
        /// determine whether its value has been altered.
        /// </remarks>
        private int _tabClickOffset = -1;

        /// <summary>
        /// The width, in pixels, of the <c>Content Area</c> that we should use
        /// for each tab.
        /// </summary>
        protected int _tabContentWidth;

        /// <summary>Flag indicating whether a tab was being repositioned.</summary>
        protected bool _wasTabRepositioning;

        /// <summary>
        /// Constructs a new instance of <see cref="T:xyLOGIX.EasyTabs.TabRendererBase" />
        /// and returns a reference to it.
        /// </summary>
        /// <param name="parent">
        /// Reference to an instance of
        /// <see cref="T:xyLOGIX.EasyTabs.TitleBarTabs" /> that represents the parent
        /// (containing the tabs) window that this renderer is responsible for drawing.
        /// </param>
        /// <remarks>
        /// The argument of the <paramref name="parent" /> parameter must be a
        /// valid object reference.
        /// <para />
        /// Otherwise, this constructor throws
        /// <see cref="T:System.ArgumentNullException" />.
        /// </remarks>
        /// <exception cref="T:System.ArgumentNullException">
        /// Thrown if the required
        /// parameter, <paramref name="parent" />, is passed a <see langword="null" />
        /// value.
        /// </exception>
        protected TabRendererBase(TitleBarTabs parent)
        {
            Parent = parent ?? throw new ArgumentNullException(nameof(parent));

            InitializeTabWell(parent);
        }

        /// <summary>
        /// Gets or sets a <see cref="T:System.Drawing.Image" /> that is to be
        /// used as the background of the content area for the tab when the tab is active;
        /// its width also determines how wide the default content area for the tab is.
        /// </summary>
        public abstract Image ActiveCenterImage { [DebuggerStepThrough] get; [DebuggerStepThrough] set; }

        /// <summary>
        /// Gets or sets a <see cref="T:System.Drawing.Image" /> that is to be
        /// displayed the left side of an active tab.
        /// </summary>
        public abstract Image ActiveLeftSideImage { [DebuggerStepThrough] get; [DebuggerStepThrough] set; }

        /// <summary>
        /// Gets or sets a <see cref="T:System.Drawing.Image" /> that is to be
        /// displayed on the right side of an active tab.
        /// </summary>
        public abstract Image ActiveRightSideImage { [DebuggerStepThrough] get; [DebuggerStepThrough] set; }

        /// <summary>
        /// Gets or sets a <see cref="T:System.Drawing.Bitmap" /> that is to be
        /// displayed when the user hovers over the <b>Add</b> button.
        /// </summary>
        public abstract Bitmap AddButtonHoverImage { [DebuggerStepThrough] get; [DebuggerStepThrough] set; }

        /// <summary>
        /// Gets or sets a <see cref="T:System.Drawing.Bitmap" /> that is to be displayed
        /// for the <c>Add</c> button when the user is not hovering the mouse over it.
        /// it.
        /// </summary>
        public abstract Bitmap AddButtonImage { [DebuggerStepThrough] get; [DebuggerStepThrough] set; }

        /// <summary>
        /// Gets the amount of space, in pixels, that we should put to the left of
        /// the add tab button when rendering the content area of the tab.
        /// </summary>
        /// <remarks>Child classes must override this property and specify its value.</remarks>
        public abstract int AddButtonMarginLeft { [DebuggerStepThrough] get; }

        /// <summary>
        /// Gets the amount of space, in pixels, that we should leave to the right
        /// of the add tab button when rendering the content area of the tab.
        /// </summary>
        /// <remarks>Child classes must override this property and specify its value.</remarks>
        public abstract int AddButtonMarginRight { [DebuggerStepThrough] get; }

        /// <summary>
        /// Gets the amount of space, in pixels, that we should leave between the
        /// top of the content area and the top of the add tab button.
        /// </summary>
        /// <remarks>Child classes must override this property and specify its value.</remarks>
        public abstract int AddButtonMarginTop { [DebuggerStepThrough] get; }

        /// <summary>
        /// Gets or sets a <see cref="T:System.Drawing.Rectangle" /> value that
        /// demarcates the area on the screen where the <b>Add</b>, or <b>+</b> button is
        /// located.
        /// </summary>
        public Rectangle AddButtonRectangle { [DebuggerStepThrough] get; [DebuggerStepThrough] private set; }

        /// <summary>
        /// Gets or sets a <see cref="T:System.Drawing.Image" /> that is to be
        /// used for the background, if any, that should be displayed in the non-client
        /// area behind the actual tabs.
        /// </summary>
        public abstract Image BackgroundImage { [DebuggerStepThrough] get; [DebuggerStepThrough] set; }

        /// <summary>
        /// Gets the <see cref="T:System.Drawing.Font" /> that is to be used to render the
        /// caption text of the tab(s).
        /// </summary>
        /// <remarks>
        /// The default value of this property is
        /// <see cref="T:System.Drawing.SystemFonts.CaptionFont" />.
        /// <para />
        /// Child classes may override this property to specify their own caption font.
        /// </remarks>
        public abstract Font CaptionFont { [DebuggerStepThrough] get; [DebuggerStepThrough] set; }

        /// <summary>
        /// Amount of space we should put to the left of the caption when
        /// rendering the content area of the tab.
        /// </summary>
        public abstract int CaptionMarginLeft { [DebuggerStepThrough] get; [DebuggerStepThrough] set; }

        /// <summary>
        /// Amount of space that we should leave to the right of the caption when
        /// rendering the content area of the tab.
        /// </summary>
        public abstract int CaptionMarginRight { [DebuggerStepThrough] get; [DebuggerStepThrough] set; }

        /// <summary>
        /// Amount of space that we should leave between the top of the content
        /// area and the top of the caption text.
        /// </summary>
        public abstract int CaptionMarginTop { [DebuggerStepThrough] get; [DebuggerStepThrough] set; }

        /// <summary>
        /// Gets the amount of space, in pixels, that we should put to the left of
        /// the close button when rendering the content area of the tab.
        /// </summary>
        /// <remarks>Child classes must override this property and specify its value.</remarks>
        public abstract int CloseButtonMarginLeft { [DebuggerStepThrough] get; }

        /// <summary>
        /// Amount of space that we should leave to the right of the close button
        /// when rendering the content area of the tab.
        /// </summary>
        public abstract int CloseButtonMarginRight { [DebuggerStepThrough] get; [DebuggerStepThrough] set; }

        /// <summary>
        /// Amount of space that we should leave between the top of the content
        /// area and the top of the close button.
        /// </summary>
        public abstract int CloseButtonMarginTop { [DebuggerStepThrough] get; [DebuggerStepThrough] set; }

        /// <summary>
        /// Gets a <see cref="T:System.Drawing.Point" /> that represents the mouse
        /// coordinates where the user first clicked and held the mouse in order to begin
        /// the operation of dragging a <c>Tab</c>.
        /// </summary>
        /// <remarks>
        /// The default value of this property is
        /// <see cref="F:System.Drawing.Point.Empty" />.
        /// </remarks>
        public Point DragStart { [DebuggerStepThrough] get; [DebuggerStepThrough] protected set; } = Point.Empty;

        /// <summary>
        /// Gets or sets a <see cref="T:System.Drawing.Color" /> value that is to be used
        /// for the text of the tabs.
        /// </summary>
        /// <remarks>
        /// The default value of this property is
        /// <see cref="F:System.Drawing.Color.White" /> for the <c>Dark Theme</c>.
        /// </remarks>
        public Color ForeColor
        {
            get => _foreColor;
            [DebuggerStepThrough] set
            {
                var changed = value != _foreColor;
                _foreColor = value;
                if (changed) OnForeColorChanged();
            }
        }

        /// <summary>
        /// Amount of space we should put to the left of the tab icon when
        /// rendering the content area of the tab.
        /// </summary>
        public abstract int IconMarginLeft { [DebuggerStepThrough] get; [DebuggerStepThrough] set; }

        /// <summary>
        /// Amount of space that we should leave to the right of the icon when
        /// rendering the content area of the tab.
        /// </summary>
        public abstract int IconMarginRight { [DebuggerStepThrough] get; [DebuggerStepThrough] set; }

        /// <summary>
        /// Amount of space that we should leave between the top of the content
        /// area and the top of the icon.
        /// </summary>
        public abstract int IconMarginTop { [DebuggerStepThrough] get; [DebuggerStepThrough] set; }

        /// <summary>
        /// Gets or sets a <see cref="T:System.Drawing.Image" /> that is to be used to
        /// display the right side of an inactive tab.
        /// </summary>
        public abstract Image InactiveRightSideImage { [DebuggerStepThrough] get; [DebuggerStepThrough] set; }

        /// <summary>
        /// Gets or sets a <see cref="T:System.Drawing.Image" /> that is to be
        /// displayed to represent the background of the content area of a tab when that
        /// tab is inactive.
        /// </summary>
        /// <remarks>
        /// The width of this <see cref="T:System.Drawing.Image" /> is also used
        /// to determine the default width of the tab content area.
        /// </remarks>
        public abstract Image InactiveTabContentAreaImage { [DebuggerStepThrough] get; [DebuggerStepThrough] set; }

        /// <summary>
        /// Gets or sets a <see cref="T:System.Drawing.Image" /> that is to be used to
        /// display the left side of an inactive tab.
        /// </summary>
        public Image InactiveTabLeftSideImage { [DebuggerStepThrough] get; [DebuggerStepThrough] set; }

        /// <summary>Gets a value that indicates whether a tab is being repositioned.</summary>
        /// <remarks>
        /// If the value of this property is updated, then the
        /// <see cref="E:xyLOGIX.EasyTabs.TabRendererBase.TabRepositioningChanged" /> event
        /// is raised.
        /// </remarks>
        public bool IsTabRepositioning
        {
            get => _isTabRepositioning;
            [DebuggerStepThrough] set
            {
                var changed = _isTabRepositioning != value;
                _isTabRepositioning = value;
                if (changed) OnTabRepositioningChanged();
            }
        }

        /// <summary>
        /// Gets the <see cref="T:System.Drawing.Rectangle" /> value that demarcates the
        /// maximum area on the screen that a given tabs, as a set, may occupy, excluding
        /// the <b>Add</b> button.
        /// </summary>
        /// <remarks>
        /// If the value of this property is updated, then the
        /// <see cref="E:xyLOGIX.EasyTabs.TabRendererBase.MaxTabWellAreaChanged" /> event
        /// is raised.
        /// </remarks>
        public Rectangle MaxTabWellArea
        {
            get => _maxTabWellWellArea;
            protected set
            {
                var changed = _maxTabWellWellArea != value;
                _maxTabWellWellArea = value;
                if (changed) OnMaxTabWellAreaChanged();
            }
        }

        /// <summary>
        /// If the renderer overlaps the tabs (like Chrome), this is the width that the
        /// tabs should overlap by.  For renderers that do not overlap tabs (like
        /// Firefox), this should be left at 0.
        /// </summary>
        public virtual int OverlapWidth
            => 0;

        /// <summary>
        /// Gets a reference to an instance of
        /// <see cref="T:xyLOGIX.EasyTabs.TitleBarTabs" /> that represents the parent
        /// container that this renderer instance is associated with.
        /// </summary>
        public TitleBarTabs Parent { [DebuggerStepThrough] get; }

        /// <summary>
        /// Gets the count of tabs that were present when we last rendered.
        /// </summary>
        /// <remarks>Used to determine whether we need to redraw the tabs.</remarks>
        public int PreviousTabCount
        {
            get => _previousTabCount;
            protected set
            {
                var changed = value != _previousTabCount;
                _previousTabCount = value;
                if (changed) OnPreviousTabCountChanged();
            }
        }

        /// <summary>
        /// Gets a value indicating whether rendering has been suspended while we perform
        /// some operation.
        /// </summary>
        /// <remarks>
        /// If the value of this property is updated, then the
        /// <see cref="E:xyLOGIX.EasyTabs.TabRendererBase.RenderingSuspendedChanged" />
        /// event is raised.
        /// </remarks>
        public bool RenderingSuspended
        {
            get => _suspendRendering;
            protected set
            {
                var changed = value != _suspendRendering;
                _suspendRendering = value;
                if (changed) OnRenderingSuspendedChanged();
            }
        }

        /// <summary>
        /// Gets a value indicating whether the entire title bar is to be rendered.
        /// </summary>
        /// <remarks>
        /// Child classes must implement this property to affect the rendering for
        /// each concrete renderer type.
        /// </remarks>
        public abstract bool RendersEntireTitleBar { [DebuggerStepThrough] get; }

        /// <summary>
        /// Gets or sets a value indicating whether the <b>Add</b> button is to be
        /// shown.
        /// </summary>
        /// <remarks>The default value of this property is <see langword="true" />.</remarks>
        public bool ShowAddButton
        {
            get => _addButtonShown;
            [DebuggerStepThrough] set
            {
                var changed = _addButtonShown != value;
                _addButtonShown = value;
                if (changed) OnAddButtonShownChanged();
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="T:System.Drawing.Color" /> value that is to be used
        /// to paint the background of the tabs and tab well.
        /// </summary>
        public Color TabBackColor
        {
            get => _tabBackColor;
            [DebuggerStepThrough] set
            {
                var changed = value != _tabBackColor;
                _tabBackColor = value;
                if (changed) OnTabBackColorChanged();
            }
        }

        /// <summary>
        /// Gets a value that indicates the horizontal offset within the tab where the user
        /// clicked to start a <c>Drag</c> operation.
        /// </summary>
        /// <remarks>
        /// The default value of this property is <c>-1</c>, which means
        /// <c>not applicable</c>.
        /// </remarks>
        public int TabClickOffset
        {
            get => _tabClickOffset;
            protected set
            {
                var changed = value != _tabClickOffset;
                _tabClickOffset = value;
                if (changed) OnTabClickOffsetChanged();
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="T:System.Drawing.Image" /> that is to be displayed
        /// each tab to close that tab when the user is hovering the mouse over the tab's
        /// <b>Close</b> button.
        /// </summary>
        public abstract Image TabCloseButtonHoverImage { [DebuggerStepThrough] get; [DebuggerStepThrough] set; }

        /// <summary>
        /// Gets or sets the <see cref="T:System.Drawing.Image" /> that is to be
        /// displayed on each tab to represent its <b>Close</b> button.
        /// </summary>
        /// <remarks>
        /// Typically, the <b>Close</b> button is rendered as a <c>x</c> that the
        /// user can click to close the tab that it is located on.
        /// <para />
        /// This property allows clients of this class to customize that image.
        /// </remarks>
        public abstract Image TabCloseButtonImage { [DebuggerStepThrough] get; [DebuggerStepThrough] set; }

        /// <summary>Gets the width, in pixels, of the content area of the tabs.</summary>
        public int TabContentWidth
        {
            get => _tabContentWidth;
            protected set
            {
                var changed = value != _tabContentWidth;
                _tabContentWidth = value;
                if (changed) OnTabContentWidthChanged();
            }
        }

        /// <summary>
        /// Height of the tab content area; derived from the height of
        /// <see cref="F:xyLOGIX.EasyTabs.TabRendererBase._activeCenterImage" />.
        /// </summary>
        public virtual int TabHeight
            => ActiveCenterImage.Height;

        /// <summary>
        /// Horizontal distance that a tab must be dragged before it starts to be
        /// repositioned.
        /// </summary>
        public virtual int TabRepositionDragDistance { [DebuggerStepThrough] get; [DebuggerStepThrough] set; } = 10;

        /// <summary>
        /// Distance that a user must drag a tab outside the tab area before it
        /// shows up as "torn" from its parent window.
        /// </summary>
        public virtual int TabTearDragDistance { [DebuggerStepThrough] get; [DebuggerStepThrough] set; } = 10;

        /// <summary>
        /// Gets a value indicating how many pixels of padding should be above the tabs.
        /// </summary>
        /// <remarks>
        /// Child classes should override this property to specify their own
        /// values.
        /// </remarks>
        public abstract int TopPadding { [DebuggerStepThrough] get; }

        /// <summary>
        /// Occurs when the value of the
        /// <see cref="P:xyLOGIX.EasyTabs.TabRendererBase.ShowAddButton" /> property is
        /// updated.
        /// </summary>
        public event EventHandler AddButtonShownChanged;

        /// <summary>
        /// Occurs when the value of the
        /// <see cref="P:xyLOGIX.EasyTabs.TabRendererBase.ForeColor" /> property is
        /// updated.
        /// </summary>
        public event EventHandler ForeColorChanged;

        /// <summary>
        /// Occurs when the value of the
        /// <see cref="P:xyLOGIX.EasyTabs.TabRendererBase.MaxTabWellArea" /> property has
        /// been updated.
        /// </summary>
        public event EventHandler MaxTabWellAreaChanged;

        /// <summary>
        /// Occurs when the value of the
        /// <see cref="P:xyLOGIX.EasyTabs.TabRendererBase.PreviousTabCount" /> property is
        /// updated.
        /// </summary>
        public event EventHandler PreviousTabCountChanged;

        /// <summary>
        /// Occurs when the value of the
        /// <see cref="P:xyLOGIX.EasyTabs.TabRendererBase.RenderingSuspended" /> property
        /// is updated.
        /// </summary>
        public event EventHandler RenderingSuspendedChanged;

        /// <summary>
        /// Occurs when the value of the
        /// <see cref="P:xyLOGIX.EasyTabs.TabRendererBase.TabBackColor" /> property is
        /// updated.
        /// </summary>
        public event EventHandler TabBackColorChanged;

        /// <summary>
        /// Occurs when the value of the
        /// <see cref="P:xyLOGIX.EasyTabs.TabRendererBase.TabClickOffset" /> property has
        /// been updated.
        /// </summary>
        public event EventHandler TabClickOffsetChanged;

        /// <summary>
        /// Occurs when the value of the
        /// <see cref="P:xyLOGIX.EasyTabs.TabRendererBase.TabContentWidth" /> property has
        /// been updated.
        /// </summary>
        public event EventHandler TabContentWidthChanged;

        /// <summary>
        /// Occurs when the value of the
        /// <see cref="P:xyLOGIX.EasyTabs.TabRendererBase.IsTabRepositioning" /> property
        /// has been updated.
        /// </summary>
        public event EventHandler TabRepositioningChanged;

        /// <summary>
        /// Tests whether the <paramref name="cursor" /> is hovering over the add
        /// tab button.
        /// </summary>
        /// <param name="cursor">Current location of the cursor.</param>
        /// <returns>
        /// True if the <paramref name="cursor" /> is within
        /// <see cref="F:xyLOGIX.EasyTabs.TabRendererBase._addButtonArea" /> and is over a
        /// non-transparent pixel of
        /// <see cref="F:xyLOGIX.EasyTabs.TabRendererBase._addButtonHoverImage" />, false
        /// otherwise.
        /// </returns>
        public virtual bool IsOverAddButton(Point cursor)
            => !_wasTabRepositioning && IsOverNonTransparentArea(
                AddButtonRectangle, AddButtonHoverImage, cursor
            );

        /// <summary>
        /// Checks to see if the <paramref name="mousePointerCoords" /> is over the
        /// <see cref="P:xyLOGIX.EasyTabs.TitleBarTab.CloseButtonArea" /> of the given
        /// <paramref name="tab" />.
        /// </summary>
        /// <param name="tab">
        /// The tab whose
        /// <see cref="P:xyLOGIX.EasyTabs.TitleBarTab.CloseButtonArea" /> we are to check
        /// to see if
        /// it contains <paramref name="mousePointerCoords" />.
        /// </param>
        /// <param name="mousePointerCoords">Current position of the mousePointerCoords.</param>
        /// <returns>
        /// True if the <paramref name="tab" />'s
        /// <see cref="P:xyLOGIX.EasyTabs.TitleBarTab.CloseButtonArea" /> contains
        /// <paramref name="mousePointerCoords" />, false otherwise.
        /// </returns>
        public virtual bool IsOverCloseButton(
            TitleBarTab tab,
            Point mousePointerCoords
        )
            => tab.ShowCloseButton && !_wasTabRepositioning && new Rectangle(
                tab.Area.X + tab.CloseButtonArea.X,
                tab.Area.Y + tab.CloseButtonArea.Y, tab.CloseButtonArea.Width,
                tab.CloseButtonArea.Height
            ).Contains(mousePointerCoords);

        /// <summary>
        /// Determines whether the mouse mousePointerCoords is currently hovering over
        /// element(s) of the window chrome, such as the <b>Minimize</b>, <b>Maximize</b>,
        /// or <b>Close</b> boxes.
        /// </summary>
        /// <param name="mousePointerCoords">
        /// (Required.) A
        /// <see cref="T:System.Drawing.Point" /> value that gives the current coordinates
        /// of the mouse pointer.
        /// </param>
        /// <returns>
        /// <see langword="true" /> if the user is hovering the mouse pointer over
        /// the sizing box elements of the parent form; <see langword="false" /> otherwise.
        /// </returns>
        public abstract bool IsOverSizingBox(Point mousePointerCoords);

        /// <summary>
        /// Attempts to determine whether the user has clicked the left mouse button in the
        /// nonclient area of the form.
        /// </summary>
        /// <param name="message">
        /// (Required.) A
        /// <see cref="T:System.Windows.Forms.Message" /> value that indicates which
        /// <c>Windows Message</c> is currently being processed by the window procedure.
        /// </param>
        /// <param name="mousePointerCoords">
        /// (Required.) A
        /// <see cref="T:System.Drawing.Point" /> value that gives the current coordinates
        /// of the mouse pointer.
        /// </param>
        /// <remarks>Children of this class must provide an implementation for this method.</remarks>
        /// <returns>
        /// If successful, one of the <see cref="T:Win32Interop.Enums.HT" />
        /// enumeration values that indicates where the user has clicked the left mouse
        /// button; otherwise, the <see cref="F:HTCAPTION" /> value is returned by default.
        /// </returns>
        public abstract HT NonClientHitTest(
            Message message,
            Point mousePointerCoords
        );

        /// <summary>
        /// Called from the <see cref="F:xyLOGIX.EasyTabs.TabRendererBase._parentWindow" />
        /// to
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
            IList<TitleBarTab> tabs,
            Graphics graphicsContext,
            Point offset,
            Point cursor,
            bool forceRedraw = false
        )
        {
            if (_suspendRendering || tabs == null || tabs.Count == 0)
                return;
            var screen = Parent.PointToScreen(Parent.ClientRectangle.Location);
            _maxTabWellWellArea.Location = new Point(
                SystemInformation.BorderSize.Width + offset.X + screen.X,
                offset.Y + screen.Y
            );
            _maxTabWellWellArea.Width = GetMaxTabWellWidth(tabs, offset);
            _maxTabWellWellArea.Height = TabHeight;
            var num1 = Math.Min(
                ActiveCenterImage.Width,
                Convert.ToInt32(
                    Math.Floor(
                        Convert.ToDouble(MaxTabWellArea.Width / tabs.Count)
                    )
                )
            );
            var flag1 = (num1 != _tabContentWidth) | forceRedraw;
            if (flag1)
                _tabContentWidth = num1;
            var index1 = tabs.Count - 1;
            var tupleList = new List<Tuple<TitleBarTab, int, Rectangle>>();
            if (BackgroundImage != null)
                graphicsContext.DrawImage(
                    BackgroundImage, offset.X, offset.Y, Parent.Width, TabHeight
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
                if (IsTabRepositioning && TabClickOffset >= 0)
                {
                    rectangle.X = cursor.X - TabClickOffset;
                    ref var local2 = ref rectangle;
                    size = SystemInformation.BorderSize;
                    var num2 = Math.Max(size.Width + offset.X, rectangle.X);
                    local2.X = num2;
                    ref var local3 = ref rectangle;
                    size = SystemInformation.BorderSize;
                    var width2 = size.Width;
                    int num3;
                    if (Parent.WindowState != FormWindowState.Maximized)
                    {
                        num3 = Parent.ClientRectangle.Width;
                    }
                    else
                    {
                        var width3 = Parent.ClientRectangle.Width;
                        int num4;
                        if (!Parent.ControlBox)
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
                        if (!Parent.MinimizeBox)
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
                        if (!Parent.MaximizeBox)
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
                        Parent.Tabs.SuppressEvents();
                        Parent.Tabs.Remove(tab2);
                        Parent.Tabs.Insert(index3, tab2);
                        Parent.Tabs.ResumeEvents();
                    }
                }

                tupleList.Add(
                    new Tuple<TitleBarTab, int, Rectangle>(
                        tabs[index2], index2, rectangle
                    )
                );
            }

            foreach (var tab in tabs.Reverse())
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

            PreviousTabCount = tabs.Count;
            if (!ShowAddButton || IsTabRepositioning)
                return;
            AddButtonRectangle = new Rectangle(
                PreviousTabCount * (num1 + ActiveLeftSideImage.Width +
                    ActiveRightSideImage.Width - OverlapWidth) +
                ActiveRightSideImage.Width + AddButtonMarginLeft + offset.X,
                AddButtonMarginTop + offset.Y +
                (TabHeight - tabCenterImage.Height), AddButtonImage.Width,
                AddButtonImage.Height
            );
            var flag2 = IsOverAddButton(cursor);
            graphicsContext.DrawImage(
                flag2 ? AddButtonHoverImage : (Image)AddButtonImage,
                AddButtonRectangle, 0, 0,
                flag2 ? AddButtonHoverImage.Width : AddButtonImage.Width,
                flag2 ? AddButtonHoverImage.Height : AddButtonImage.Height,
                GraphicsUnit.Pixel
            );
        }

        /// <summary>
        /// Called when a torn tab is dragged into the
        /// <see cref="P:xyLOGIX.EasyTabs.TitleBarTabs.TabDropArea" /> of
        /// <see cref="F:xyLOGIX.EasyTabs.TabRendererBase._parentWindow" />.  Places the
        /// tab in the
        /// list and
        /// sets <see cref="P:xyLOGIX.EasyTabs.TabRendererBase.IsTabRepositioning" /> to
        /// true to
        /// simulate the user continuing to drag the tab around in the window.
        /// </summary>
        /// <param name="tab">Tab that was dragged into this window.</param>
        /// <param name="cursorLocation">Location of the user's cursor.</param>
        internal virtual void CombineTab(TitleBarTab tab, Point cursorLocation)
        {
            _suspendRendering = true;
            var index = Parent.Tabs.FindIndex(
                t => t.Area.Left <= cursorLocation.X &&
                     t.Area.Right >= cursorLocation.X
            );
            TabClickOffset = Parent.Tabs.Count <= 0
                ? 0
                : Parent.Tabs.First()
                        .Area.Width / 2;
            IsTabRepositioning = true;
            tab.Parent = Parent;
            if (index == -1)
            {
                Parent.Tabs.Add(tab);
                index = Parent.Tabs.Count - 1;
            }
            else
            {
                Parent.Tabs.Insert(index, tab);
            }

            _suspendRendering = false;
            Parent.SelectedTabIndex = index;
            Parent.ResizeTabContents();
        }

        /// <summary>
        /// Initialize the <see cref="P:xyLOGIX.EasyTabs.TabRendererBase.DragStart" />
        /// and <see cref="F:xyLOGIX.EasyTabs.TabRendererBase._tabClickOffset" /> fields in
        /// case
        /// the user starts dragging a tab.
        /// </summary>
        /// <param name="sender">Object from which this event originated.</param>
        /// <param name="e">Arguments associated with the event.</param>
        protected internal virtual void OnOverlayMouseDown(
            [NotLogged] object sender,
            [NotLogged] MouseEventArgs e
        )
        {
            _wasTabRepositioning = false;
            DragStart = e.Location;
            var point = Parent.Overlay.GetRelativeCursorPosition(e.Location);
            var x1 = point.X;
            point = Parent.SelectedTab.Area.Location;
            var x2 = point.X;
            TabClickOffset = x1 - x2;
        }

        /// <summary>
        /// If the user is dragging the mouse, see if they have passed the
        /// <see cref="P:xyLOGIX.EasyTabs.TabRendererBase.TabRepositionDragDistance" />
        /// threshold; and, if so, officially begin the tab drag operation.
        /// </summary>
        /// <param name="sender">Object from which this event originated.</param>
        /// <param name="e">Arguments associated with the event.</param>
        protected internal virtual void OnOverlayMouseMove(
            [NotLogged] object sender,
            [NotLogged] MouseEventArgs e
        )
        {
            if (!DragStart.IsEmpty || IsTabRepositioning)
                return;
            var x1 = e.X;
            var x2 = DragStart.X;
            if (Math.Abs(x1 - x2) <= TabRepositionDragDistance)
            {
                var y1 = e.Y;
                var y2 = DragStart.Y;
                if (Math.Abs(y1 - y2) <= TabRepositionDragDistance)
                    return;
            }

            IsTabRepositioning = true;
        }

        /// <summary>
        /// End the drag operation by resetting the
        /// <see cref="P:xyLOGIX.EasyTabs.TabRendererBase.DragStart" /> and
        /// <see cref="F:xyLOGIX.EasyTabs.TabRendererBase._tabClickOffset" /> fields and
        /// setting
        /// <see cref="P:xyLOGIX.EasyTabs.TabRendererBase.IsTabRepositioning" /> to false.
        /// </summary>
        /// <param name="sender">Object from which this event originated.</param>
        /// <param name="e">Arguments associated with the event.</param>
        protected internal virtual void OnOverlayMouseUp(
            [NotLogged] object sender,
            [NotLogged] MouseEventArgs e
        )
        {
            DragStart = Point.Empty;
            TabClickOffset = -1;
            _wasTabRepositioning = IsTabRepositioning;
            IsTabRepositioning = false;
            if (!_wasTabRepositioning)
                return;
            Parent.Overlay.Render(true);
        }

        /// <summary>
        /// Gets the maximum width to utilize for the <c>Tab Well</c>.  This area is the
        /// entire area of the form's nonclient area that is available for displaying tabs,
        /// minus window chrome elements, such as the <b>Minimize</b>, <b>Maximize</b>, and
        /// <b>Close</b> boxes etc.
        /// </summary>
        /// <param name="tabs">
        /// (Required.) Reference to an instance of a collection of
        /// instances of <see cref="T:xyLOGIX.EasyTabs.TitleBarTab" /> that represents the
        /// collection of tabs currently present in the <c>Tab Well</c>.
        /// </param>
        /// <param name="offset">(Required.) A horizontal offset for the tabs.</param>
        /// <returns>
        /// Integer specifying the maximum available width for the <c>Tab Well</c>
        /// .
        /// </returns>
        protected virtual int GetMaxTabWellWidth(
            IList<TitleBarTab> tabs,
            Point offset
        )
        {
            var result = 0;

            try
            {
                if (tabs == null) return result;
                if (AddButtonImage == null) return result;
                if (AddButtonMarginLeft < 0) return result;
                if (AddButtonMarginRight < 0) return result;
                if (OverlapWidth < 0) return result;
                if (Parent == null) return result;
                if (Parent.IsDisposed) return result;

                result = Parent.ClientRectangle.Width - offset.X -
                         (ShowAddButton
                             ? AddButtonImage.Width + AddButtonMarginLeft +
                               AddButtonMarginRight
                             : 0) - tabs.Count * OverlapWidth -
                         (Parent.ControlBox
                             ? SystemInformation.CaptionButtonSize.Width
                             : 0) - (Parent.MinimizeBox
                             ? SystemInformation.CaptionButtonSize.Width
                             : 0) - (Parent.MaximizeBox
                             ? SystemInformation.CaptionButtonSize.Width
                             : 0);
            }
            catch (Exception ex)
            {
                // dump all the exception info to the log
                DebugUtils.LogException(ex);

                result = 0;
            }

            return result;
        }

        /// <summary>
        /// Gets the image to use for the center of the <paramref name="tab" />.
        /// </summary>
        /// <param name="tab">Tab that we are retrieving the image for.</param>
        /// <returns>The image for the center of <paramref name="tab" />.</returns>
        protected virtual Image GetTabCenterImage(TitleBarTab tab)
            => !tab.Active ? InactiveTabContentAreaImage : ActiveCenterImage;

        /// <summary>
        /// Gets the image to use for the left side of the <paramref name="tab" />.
        /// </summary>
        /// <param name="tab">Tab that we are retrieving the image for.</param>
        /// <returns>The image for the left side of <paramref name="tab" />.</returns>
        protected virtual Image GetTabLeftImage(TitleBarTab tab)
            => !tab.Active ? InactiveTabLeftSideImage : ActiveLeftSideImage;

        /// <summary>
        /// Gets the image to use for the right side of the <paramref name="tab" />.
        /// </summary>
        /// <param name="tab">Tab that we are retrieving the image for.</param>
        /// <returns>The image for the right side of <paramref name="tab" />.</returns>
        protected virtual Image GetTabRightImage(TitleBarTab tab)
            => !tab.Active ? InactiveRightSideImage : ActiveRightSideImage;

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
        /// <see cref="P:xyLOGIX.EasyTabs.TitleBarTab.Area" /> of the
        /// <paramref name="tab" /> and
        /// is over a non-transparent
        /// pixel of <see cref="P:xyLOGIX.EasyTabs.TitleBarTab.TabImage" />, false
        /// otherwise.
        /// </returns>
        protected virtual bool IsOverTab(TitleBarTab tab, Point cursor)
            => IsOverNonTransparentArea(tab.Area, tab.TabImage, cursor);

        /// <summary>
        /// Raises the
        /// <see cref="E:xyLOGIX.EasyTabs.TabRendererBase.AddButtonShownChanged" /> event.
        /// </summary>
        /// <remarks>
        /// This method is called when the value of the
        /// <see cref="P:xyLOGIX.EasyTabs.TabRendererBase.ShowAddButton" /> property is
        /// updated.
        /// </remarks>
        protected virtual void OnAddButtonShownChanged()
            => AddButtonShownChanged?.Invoke(this, EventArgs.Empty);

        /// <summary>
        /// Raises the <see cref="E:xyLOGIX.EasyTabs.TabRendererBase.ForeColorChanged" />
        /// event.
        /// </summary>
        /// <remarks>
        /// This method is called when the value of the
        /// <see cref="P:xyLOGIX.EasyTabs.TabRendererBase.ForeColor" /> property is
        /// updated.
        /// </remarks>
        protected virtual void OnForeColorChanged()
            => ForeColorChanged?.Invoke(this, EventArgs.Empty);

        /// <summary>
        /// Raises the
        /// <see cref="E:xyLOGIX.EasyTabs.TabRendererBase.MaxTabWellAreaChanged" /> event.
        /// </summary>
        /// <remarks>
        /// This method is called when the value of the
        /// <see cref="P:xyLOGIX.EasyTabs.TabRendererBase.MaxTabWellArea" /> property is
        /// updated.
        /// </remarks>
        protected virtual void OnMaxTabWellAreaChanged()
            => MaxTabWellAreaChanged?.Invoke(this, EventArgs.Empty);

        /// <summary>
        /// Raises the
        /// <see cref="E:xyLOGIX.EasyTabs.TabRendererBase.PreviousTabCountChanged" />
        /// event.
        /// </summary>
        /// <remarks>
        /// This method is called when the value of the
        /// <see cref="P:xyLOGIX.EasyTabs.TabRendererBase.PreviousTabCount" /> property is
        /// updated.
        /// </remarks>
        protected virtual void OnPreviousTabCountChanged()
            => PreviousTabCountChanged?.Invoke(this, EventArgs.Empty);

        /// <summary>
        /// Raises the
        /// <see cref="E:xyLOGIX.EasyTabs.TabRendererBase.RenderingSuspendedChanged" />
        /// event.
        /// </summary>
        /// <remarks>
        /// This method is called when the value of the
        /// <see cref="P:xyLOGIX.EasyTabs.TabRendererBase.RenderingSuspended" /> property
        /// is updated.
        /// </remarks>
        protected virtual void OnRenderingSuspendedChanged()
            => RenderingSuspendedChanged?.Invoke(this, EventArgs.Empty);

        /// <summary>
        /// Raises the
        /// <see cref="E:xyLOGIX.EasyTabs.TabRendererBase.TabBackColorChanged" />
        /// event.
        /// </summary>
        /// <remarks>
        /// This method is called when the value of the
        /// <see cref="P:xyLOGIX.EasyTabs.TabRendererBase.TabBackColor" /> property is
        /// updated.
        /// </remarks>
        protected virtual void OnTabBackColorChanged()
            => TabBackColorChanged?.Invoke(this, EventArgs.Empty);

        /// <summary>
        /// Raises the
        /// <see cref="E:xyLOGIX.EasyTabs.TabRendererBase.TabClickOffsetChanged" /> event.
        /// </summary>
        /// <remarks>
        /// This method is called when the value of the
        /// <see cref="P:xyLOGIX.EasyTabs.TabRendererBase.TabClickOffset" /> property is
        /// updated.
        /// </remarks>
        protected virtual void OnTabClickOffsetChanged()
            => TabClickOffsetChanged?.Invoke(this, EventArgs.Empty);

        /// <summary>
        /// Raises the
        /// <see cref="E:xyLOGIX.EasyTabs.TabRendererBase.TabContentWidthChanged" /> event.
        /// </summary>
        /// <remarks>
        /// This method is called when the value of the
        /// <see cref="P:xyLOGIX.EasyTabs.TabRendererBase.TabContentWidth" /> property has
        /// been updated.
        /// </remarks>
        protected virtual void OnTabContentWidthChanged()
            => TabContentWidthChanged?.Invoke(this, EventArgs.Empty);

        /// <summary>
        /// Raises the
        /// <see cref="E:xyLOGIX.EasyTabs.TabRendererBase.TabRepositioningChanged" />
        /// event.
        /// </summary>
        /// <remarks>
        /// Child classes that override this method must call the base class
        /// before beginning their own logic.
        /// </remarks>
        protected virtual void OnTabRepositioningChanged()
        {
            TabRepositioningChanged?.Invoke(this, EventArgs.Empty);

            if (_isTabRepositioning)
                return;

            // If the _isTabRepositioning flag is FALSE, then reset the value of the DragStart property
            DragStart = Point.Empty;
        }

        /// <summary>
        /// Internal method for rendering an individual <paramref name="tab" /> to
        /// the screen.
        /// </summary>
        /// <param name="graphicsContext">Graphics context to use when rendering the tab.</param>
        /// <param name="tab">Individual tab that we are to render.</param>
        /// <param name="index">
        /// Index of the current <paramref name="tab" /> in the
        /// collection of currently open tabs.
        /// </param>
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
                            ? TabCloseButtonHoverImage
                            : TabCloseButtonImage;
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
                        ? TabCloseButtonImage.Width + CloseButtonMarginRight +
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
        /// </summary>
        /// <param name="parent"></param>
        private void InitializeTabWell(TitleBarTabs parent)
        {
            Parent.Tabs.CollectionModified += Tabs_CollectionModified;
            if (parent.Overlay == null)
                return;
            Parent.Overlay.MouseMove += OnOverlayMouseMove;
            Parent.Overlay.MouseUp += OnOverlayMouseUp;
            Parent.Overlay.MouseDown += OnOverlayMouseDown;
        }

        /// <summary>
        /// When items are added to the tabs collection, we need to ensure that the
        /// <see cref="F:xyLOGIX.EasyTabs.TabRendererBase._parentWindow" />'s minimum width
        /// is set
        /// so that we can display at
        /// least each tab and its close buttons.
        /// </summary>
        /// <param name="sender">
        /// List of tabs in the
        /// <see cref="F:xyLOGIX.EasyTabs.TabRendererBase._parentWindow" />.
        /// </param>
        /// <param name="e">Arguments associated with the event.</param>
        private void Tabs_CollectionModified(
            [NotLogged] object sender,
            [NotLogged] ListModificationEventArgs e
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
            if (!Parent.ControlBox)
            {
                num2 = 0;
            }
            else
            {
                captionButtonSize = SystemInformation.CaptionButtonSize;
                num2 = captionButtonSize.Width;
            }

            int num3;
            if (!Parent.MinimizeBox)
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
            if (!Parent.MaximizeBox)
            {
                num5 = 0;
            }
            else
            {
                captionButtonSize = SystemInformation.CaptionButtonSize;
                num5 = captionButtonSize.Width;
            }

            var num6 = num4 - num5 + (ShowAddButton
                ? AddButtonImage.Width + AddButtonMarginLeft +
                  AddButtonMarginRight
                : 0);
            Parent.MinimumSize = new Size(num1 + num6, 0);
        }
    }
}