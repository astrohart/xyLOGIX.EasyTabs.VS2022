using xyLOGIX.EasyTabs.Properties;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Win32Interop.Enums;

namespace xyLOGIX.EasyTabs
{
    /// <summary>
    /// Renderer that produces tabs that mimic the appearance of the Chrome
    /// browser.
    /// </summary>
    public class ChromeTabRenderer : TabRendererBase
    {
        private readonly Font _captionFont;
        private readonly WindowsSizingBoxes _windowsSizingBoxes;

        /// <summary>
        /// Constructor that initializes the various resources that we use in
        /// rendering.
        /// </summary>
        /// <param name="parentWindow">Parent window that this renderer belongs to.</param>
        public ChromeTabRenderer(TitleBarTabs parentWindow) : base(parentWindow)
        {
            _activeLeftSideImage = Resources.ChromeLeft;
            _activeRightSideImage = Resources.ChromeRight;
            _activeCenterImage = Resources.ChromeCenter;
            _inactiveLeftSideImage = Resources.ChromeInactiveLeft;
            _inactiveRightSideImage = Resources.ChromeInactiveRight;
            _inactiveCenterImage = Resources.ChromeInactiveCenter;
            _closeButtonImage = Resources.ChromeClose;
            _closeButtonHoverImage = Resources.ChromeCloseHover;
            _background =
                IsWindows10 ? Resources.ChromeBackground : (Image)null;
            _addButtonImage = new Bitmap(Resources.ChromeAdd);
            _addButtonHoverImage = new Bitmap(Resources.ChromeAddHover);
            CloseButtonMarginTop = 9;
            CloseButtonMarginLeft = 2;
            CloseButtonMarginRight = 4;
            AddButtonMarginTop = 3;
            AddButtonMarginLeft = 2;
            CaptionMarginTop = 9;
            IconMarginLeft = 9;
            IconMarginTop = 9;
            IconMarginRight = 5;
            AddButtonMarginRight = 45;
            _windowsSizingBoxes = new WindowsSizingBoxes(parentWindow);
            _captionFont = new Font("Segoe UI", 9f);
            if (_captionFont.Name == "Segoe UI")
                return;
            _captionFont = new Font(SystemFonts.CaptionFont.Name, 9f);
        }

        public override Font CaptionFont
            => _captionFont;

        /// <summary>
        /// Since Chrome tabs overlap, we set this property to the amount that
        /// they overlap by.
        /// </summary>
        public override int OverlapWidth
            => 14;

        public override bool RendersEntireTitleBar
            => IsWindows10;

        public override int TabHeight
            => _parentWindow.WindowState != FormWindowState.Maximized
                ? base.TabHeight + TopPadding
                : base.TabHeight;

        public override int TopPadding
            => _parentWindow.WindowState != FormWindowState.Maximized ? 8 : 0;

        public override bool IsOverSizingBox(Point cursor)
            => _windowsSizingBoxes.Contains(cursor);

        public override HT NonClientHitTest(Message message, Point cursor)
        {
            var result = _windowsSizingBoxes.NonClientHitTest(cursor);
            if (result == HT.HTNOWHERE)
                result = HT.HTCAPTION;
            return result;
        }

        public override void Render(
            List<TitleBarTab> tabs,
            Graphics graphicsContext,
            Point offset,
            Point cursor,
            bool forceRedraw = false
        )
        {
            base.Render(tabs, graphicsContext, offset, cursor, forceRedraw);
            if (!IsWindows10)
                return;
            _windowsSizingBoxes.Render(graphicsContext, cursor);
        }

        protected override int GetMaxTabAreaWidth(
            List<TitleBarTab> tabs,
            Point offset
        )
            => _parentWindow.ClientRectangle.Width - offset.X -
               (ShowAddButton
                   ? _addButtonImage.Width + AddButtonMarginLeft +
                     AddButtonMarginRight
                   : 0) - tabs.Count * OverlapWidth - _windowsSizingBoxes.Width;

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
            if (!IsWindows10 && !tab.Active &&
                index == _parentWindow.Tabs.Count - 1)
                tabRightImage = Resources.ChromeInactiveRightNoDivider;
            base.Render(
                graphicsContext, tab, index, area, cursor, tabLeftImage,
                tabCenterImage, tabRightImage
            );
        }
    }
}