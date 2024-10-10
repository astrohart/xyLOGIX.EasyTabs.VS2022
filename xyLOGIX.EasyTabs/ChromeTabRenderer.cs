using Core.Logging;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Win32Interop.Enums;
using xyLOGIX.EasyTabs.Properties;

namespace xyLOGIX.EasyTabs
{
    /// <summary>
    /// Renderer that produces tabs that mimic the appearance of the Chrome
    /// browser.
    /// </summary>
    public class ChromeTabRenderer : TabRendererBase
    {
        /// <summary>
        /// Amount of space, in pixels, that we should put to the left of the add
        /// tab button when rendering the content area of the tab.
        /// </summary>
        private const int ChromeAddButtonMarginLeft = 2;

        /// <summary>
        /// Amount of space, in pixels, that we should leave to the right of the
        /// add tab button when rendering the content area of the tab.
        /// </summary>
        private const int ChromeAddButtonMarginRight = 45;

        /// <summary>
        /// Amount of space, in pixels, that we should leave between the top of
        /// the content area and the top of the add tab button.
        /// </summary>
        private const int ChromeAddButtonMarginTop = 3;

        /// <summary>
        /// Amount of space, in pixels, that we should put to the left of the
        /// close button when rendering the content area of the tab.
        /// </summary>
        private const int ChromeCloseButtonMarginLeft = 2;

        /// <summary>
        /// Reference to an instance of
        /// <see cref="T:xyLOGIX.EasyTabs.WindowsSizingBoxes" /> that controls the
        /// rendering of window chrome elements such as the <b>Minimize</b>,
        /// <b>Maximize</b>, and <b>Close</b> buttons etc.
        /// </summary>
        private readonly WindowsSizingBoxes _windowsSizingBoxes;

        /// <summary>
        /// Constructor that initializes the various resources that we use in
        /// rendering.
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
        public ChromeTabRenderer(TitleBarTabs parent) : base(parent)
            => _windowsSizingBoxes = new WindowsSizingBoxes(parent);

        /// <summary>
        /// Gets or sets a <see cref="T:System.Drawing.Image" /> that is to be
        /// used as the background of the content area for the tab when the tab is active;
        /// its width also determines how wide the default content area for the tab is.
        /// </summary>
        public override Image ActiveCenterImage { get; set; } =
            Resources.ChromeCenter;

        /// <summary>
        /// Gets or sets a <see cref="T:System.Drawing.Image" /> that is to be
        /// displayed the left side of an active tab.
        /// </summary>
        public override Image ActiveLeftSideImage { get; set; } =
            Resources.ChromeLeft;

        /// <summary>
        /// Gets or sets a <see cref="T:System.Drawing.Image" /> that is to be
        /// displayed on the right side of an active tab.
        /// </summary>
        public override Image ActiveRightSideImage { get; set; } =
            Resources.ChromeRight;

        /// <summary>
        /// Gets or sets a <see cref="T:System.Drawing.Bitmap" /> that is to be
        /// displayed when the user hovers over the <b>Add</b> button.
        /// </summary>
        public override Bitmap AddButtonHoverImage { get; set; } =
            new Bitmap(Resources.ChromeAddHover);

        /// <summary>
        /// Gets or sets a <see cref="T:System.Drawing.Bitmap" /> that is to be displayed
        /// for the <c>Add</c> button when the user is not hovering the mouse over it.
        /// it.
        /// </summary>
        public override Bitmap AddButtonImage { get; set; } =
            new Bitmap(Resources.ChromeAdd);

        /// <summary>
        /// Gets the amount of space, in pixels, that we should put to the left of
        /// the add tab button when rendering the content area of the tab.
        /// </summary>
        /// <remarks>Child classes must override this property and specify its value.</remarks>
        public override int AddButtonMarginLeft
            => ChromeAddButtonMarginLeft;

        /// <summary>
        /// Gets the amount of space, in pixels, that we should leave to the right
        /// of the add tab button when rendering the content area of the tab.
        /// </summary>
        /// <remarks>Child classes must override this property and specify its value.</remarks>
        public override int AddButtonMarginRight
            => ChromeAddButtonMarginRight;

        /// <summary>
        /// Gets the amount of space, in pixels, that we should leave between the
        /// top of the content area and the top of the add tab button.
        /// </summary>
        /// <remarks>Child classes must override this property and specify its value.</remarks>
        public override int AddButtonMarginTop
            => ChromeAddButtonMarginTop;

        /// <summary>
        /// Gets or sets a <see cref="T:System.Drawing.Image" /> that is to be
        /// used for the background, if any, that should be displayed in the non-client
        /// area behind the actual tabs.
        /// </summary>
        public override Image BackgroundImage { get; set; } =
            OperatingSystem.IsWindows10
                ? Resources.ChromeBackground
                : (Image)null;

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
        public override Font CaptionFont { get; set; } =
            SystemFonts.CaptionFont;

        /// <summary>
        /// Amount of space we should put to the left of the caption when
        /// rendering the content area of the tab.
        /// </summary>
        public override int CaptionMarginLeft { get; set; }

        /// <summary>
        /// Amount of space that we should leave to the right of the caption when
        /// rendering the content area of the tab.
        /// </summary>
        public override int CaptionMarginRight { get; set; }

        /// <summary>
        /// Amount of space that we should leave between the top of the content
        /// area and the top of the caption text.
        /// </summary>
        public override int CaptionMarginTop { get; set; } = 9;

        /// <summary>
        /// Gets the amount of space, in pixels, that we should put to the left of
        /// the close button when rendering the content area of the tab.
        /// </summary>
        /// <remarks>Child classes must override this property and specify its value.</remarks>
        public override int CloseButtonMarginLeft
            => ChromeCloseButtonMarginLeft;

        /// <summary>
        /// Amount of space that we should leave to the right of the close button
        /// when rendering the content area of the tab.
        /// </summary>
        public override int CloseButtonMarginRight { get; set; } = 4;

        /// <summary>
        /// Amount of space that we should leave between the top of the content
        /// area and the top of the close button.
        /// </summary>
        public override int CloseButtonMarginTop { get; set; } = 9;

        /// <summary>
        /// Amount of space we should put to the left of the tab icon when
        /// rendering the content area of the tab.
        /// </summary>
        public override int IconMarginLeft { get; set; } = 9;

        /// <summary>
        /// Amount of space that we should leave to the right of the icon when
        /// rendering the content area of the tab.
        /// </summary>
        public override int IconMarginRight { get; set; } = 5;

        /// <summary>
        /// Amount of space that we should leave between the top of the content
        /// area and the top of the icon.
        /// </summary>
        public override int IconMarginTop { get; set; } = 9;

        /// <summary>
        /// Gets or sets a <see cref="T:System.Drawing.Image" /> that is to be used to
        /// display the right side of an inactive tab.
        /// </summary>
        public override Image InactiveRightSideImage { get; set; } =
            Resources.ChromeInactiveRight;

        /// <summary>
        /// Gets or sets a <see cref="T:System.Drawing.Image" /> that is to be
        /// displayed to represent the background of the content area of a tab when that
        /// tab is inactive.
        /// </summary>
        /// <remarks>
        /// The width of this <see cref="T:System.Drawing.Image" /> is also used
        /// to determine the default width of the tab content area.
        /// </remarks>
        public override Image InactiveTabContentAreaImage { get; set; } =
            Resources.ChromeInactiveCenter;

        /// <summary>
        /// Since Chrome tabs overlap, we set this property to the amount that
        /// they overlap by.
        /// </summary>
        public override int OverlapWidth
            => 14;

        /// <summary>
        /// Gets a value indicating whether the entire title bar is to be rendered.
        /// </summary>
        /// <remarks>
        /// Child classes must implement this property to affect the rendering for
        /// each concrete renderer type.
        /// </remarks>
        public override bool RendersEntireTitleBar
            => OperatingSystem.IsWindows10;

        /// <summary>
        /// Gets or sets the <see cref="T:System.Drawing.Image" /> that is to be displayed
        /// each tab to close that tab when the user is hovering the mouse over the tab's
        /// <b>Close</b> button.
        /// </summary>
        public override Image TabCloseButtonHoverImage { get; set; } =
            Resources.ChromeCloseHover;

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
        public override Image TabCloseButtonImage { get; set; } =
            Resources.ChromeClose;

        /// <summary>
        /// Height of the tab content area; derived from the height of
        /// <see cref="F:xyLOGIX.EasyTabs.TabRendererBase._activeCenterImage" />.
        /// </summary>
        public override int TabHeight
            => Parent.WindowState != FormWindowState.Maximized
                ? base.TabHeight + TopPadding
                : base.TabHeight;

        /// <summary>
        /// Gets a value indicating how many pixels of padding should be above the tabs.
        /// </summary>
        /// <remarks>
        /// Child classes should override this property to specify their own
        /// values.
        /// </remarks>
        public override int TopPadding
            => Parent.WindowState != FormWindowState.Maximized ? 8 : 0;

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
        public override bool IsOverSizingBox(Point mousePointerCoords)
            => _windowsSizingBoxes.Contains(mousePointerCoords);

        /// <summary>
        /// Attempts to determine, on what part of the nonclient area, the
        /// <paramref name="mousePointerCoords" /> is located, if at all.
        /// </summary>
        /// <param name="message">
        /// (Required.) One of the <see cref="T:System.Windows.Forms.Message" /> values
        /// that identifies the Windows message that is being handled.
        /// </param>
        /// <param name="mousePointerCoords">
        /// (Required.) A <see cref="T:System.Drawing.Point" /> value
        /// that gives the current mouse pointer location.
        /// </param>
        /// <returns>One of the <see cref="T:Win32Interop.Enums.HT" /> enumeration values.</returns>
        public override HT NonClientHitTest(
            Message message,
            Point mousePointerCoords
        )
        {
            var result = HT.HTCAPTION;

            try
            {
                if (_windowsSizingBoxes == null) return result;
                if (Point.Empty.Equals(mousePointerCoords)) return result;

                result =
                    _windowsSizingBoxes.NonClientHitTest(mousePointerCoords);
                if (HT.HTNOWHERE.Equals(result)) result = HT.HTCAPTION;
            }
            catch (Exception ex)
            {
                // dump all the exception info to the log
                DebugUtils.LogException(ex);

                result = HT.HTCAPTION;
            }

            return result;
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
        public override void Render(
            IList<TitleBarTab> tabs,
            Graphics graphicsContext,
            Point offset,
            Point cursor,
            bool forceRedraw = false
        )
        {
            base.Render(tabs, graphicsContext, offset, cursor, forceRedraw);
            if (!OperatingSystem.IsWindows10)
                return;
            _windowsSizingBoxes.Render(graphicsContext, cursor);
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
        protected override int GetMaxTabWellWidth(
            IList<TitleBarTab> tabs,
            Point offset
        )
            => Parent.ClientRectangle.Width - offset.X -
               (ShowAddButton
                   ? AddButtonImage.Width + AddButtonMarginLeft +
                     AddButtonMarginRight
                   : 0) - tabs.Count * OverlapWidth - _windowsSizingBoxes.Width;

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
        protected override void Render(
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
            if (!OperatingSystem.IsWindows10 && !tab.Active &&
                index == Parent.Tabs.Count - 1)
                tabRightImage = Resources.ChromeInactiveRightNoDivider;
            base.Render(
                graphicsContext, tab, index, area, cursor, tabLeftImage,
                tabCenterImage, tabRightImage
            );
        }
    }
}