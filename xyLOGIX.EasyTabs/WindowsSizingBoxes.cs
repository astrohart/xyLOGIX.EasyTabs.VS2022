using Core.Logging;
using Svg;
using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using Win32Interop.Enums;
using xyLOGIX.EasyTabs.Properties;

namespace xyLOGIX.EasyTabs
{
    /// <summary>
    /// Controls the rendering of the window chrome elements, such as the
    /// <b>Minimize</b>, <b>Maximize</b>, and <b>Close</b> boxes.
    /// </summary>
    public class WindowsSizingBoxes
    {
        /// <summary>
        /// A <see cref="T:System.Drawing.Rectangle" /> value that demarcates the area
        /// within which the <b>Close</b> box is to be rendered.
        /// </summary>
        protected Rectangle _closeButtonArea = new Rectangle(90, 0, 45, 29);

        /// <summary>
        /// A <see cref="T:System.Drawing.Color" /> that is to be used for the highlight
        /// color of the <b>Close</b> box.
        /// </summary>
        /// <remarks>
        /// The highlight color is painted when the use hovers the mouse pointer
        /// over the <b>Close</b> box or clicks the <b>Close</b> box.
        /// </remarks>
        private Color _closeButtonHighlightColor = Color.FromArgb(232, 17, 35);

        protected Rectangle _maximizeRestoreButtonArea =
            new Rectangle(45, 0, 45, 29);

        protected Rectangle _minimizeButtonArea = new Rectangle(0, 0, 45, 29);

        protected Brush _minimizeMaximizeButtonHighlight =
            new SolidBrush(Color.FromArgb(27, Color.Black));

        protected TitleBarTabs _parentWindow;

        public WindowsSizingBoxes(TitleBarTabs parentWindow)
            => _parentWindow = parentWindow;

        /// <summary>
        /// Gets or sets the <see cref="T:System.Drawing.Color" /> value that is to be used
        /// for the highlight color of the <b>Close</b> box.
        /// </summary>
        /// <remarks>
        /// The highlight color is painted when the use hovers the mouse pointer over the
        /// <b>Close</b> box or clicks the <b>Close</b> box.
        /// <para />
        /// This property raises the
        /// <see
        ///     cref="E:xyLOGIX.EasyTabs.WindowsSizingBoxes.CloseButtonHighlightColorChanged" />
        /// event when its value is updated.
        /// </remarks>
        public Color CloseButtonHighlightColor
        {
            get => _closeButtonHighlightColor;
            set
            {
                var changed = _closeButtonHighlightColor != value;
                _closeButtonHighlightColor = value;
                if (changed) OnCloseButtonHighlightColorChanged();
            }
        }

        public int Width
            => _minimizeButtonArea.Width + _maximizeRestoreButtonArea.Width +
               _closeButtonArea.Width;

        /// <summary>
        /// Occurs when the value of the
        /// <see cref="P:xyLOGIX.EasyTabs.WindowsSizingBoxes.CloseButtonHighlightColor" />
        /// property is updated.
        /// </summary>
        public event EventHandler CloseButtonHighlightColorChanged;

        public bool Contains(Point cursor)
            => _minimizeButtonArea.Contains(cursor) ||
               _maximizeRestoreButtonArea.Contains(cursor) ||
               _closeButtonArea.Contains(cursor);

        public HT NonClientHitTest(Point cursor)
        {
            if (_minimizeButtonArea.Contains(cursor))
                return HT.HTMINBUTTON;
            if (_maximizeRestoreButtonArea.Contains(cursor))
                return HT.HTMAXBUTTON;
            if (_closeButtonArea.Contains(cursor)) return HT.HTCLOSE;

            return HT.HTNOWHERE;
        }

        public void Render(Graphics graphicsContext, Point mousePointerCoords)
        {
            var right = _parentWindow.ClientRectangle.Width;
            var closeButtonHighlighted = false;

            _minimizeButtonArea.X = right - 135;
            _maximizeRestoreButtonArea.X = right - 90;
            _closeButtonArea.X = right - 45;

            if (_minimizeButtonArea.Contains(mousePointerCoords))
                graphicsContext.FillRectangle(
                    _minimizeMaximizeButtonHighlight, _minimizeButtonArea
                );
            else if (_maximizeRestoreButtonArea.Contains(mousePointerCoords))
                graphicsContext.FillRectangle(
                    _minimizeMaximizeButtonHighlight, _maximizeRestoreButtonArea
                );
            else if (_closeButtonArea.Contains(mousePointerCoords))
                using (var brush = new SolidBrush(_closeButtonHighlightColor))
                {
                    graphicsContext.FillRectangle(brush, _closeButtonArea);
                    closeButtonHighlighted = true;
                }

            using (var image = closeButtonHighlighted
                       ? LoadSvg(
                           Encoding.UTF8.GetString(Resources.CloseHighlight),
                           10, 10
                       )
                       : LoadSvg(
                           Encoding.UTF8.GetString(Resources.Close), 10, 10
                       ))
            {
                graphicsContext.DrawImage(
                    image, _closeButtonArea.X + 17, _closeButtonArea.Y + 9
                );
            }

            using (var image = GetMaximizeOrRestoreBoxImage())
            {
                if (image != null)
                    graphicsContext.DrawImage(
                        image, _maximizeRestoreButtonArea.X + 17,
                        _maximizeRestoreButtonArea.Y + 9
                    );
            }

            using (var image = LoadSvg(
                       Encoding.UTF8.GetString(Resources.Minimize), 10, 10
                   ))
            {
                graphicsContext.DrawImage(
                    image, _minimizeButtonArea.X + 17, _minimizeButtonArea.Y + 9
                );
            }
        }

        protected Image LoadSvg(string svgXml, int width, int height)
        {
            var xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(svgXml);

            return SvgDocument.Open(xmlDocument)
                              .Draw(width, height);
        }

        /// <summary>
        /// Raises the
        /// <see
        ///     cref="E:xyLOGIX.EasyTabs.WindowsSizingBoxes.CloseButtonHighlightColorChanged" />
        /// event.
        /// </summary>
        /// <remarks>
        /// This method is called when the value of the
        /// <see cref="P:xyLOGIX.EasyTabs.WindowsSizingBoxes.CloseButtonHighlightColor" />
        /// property is updated.
        /// </remarks>
        protected virtual void OnCloseButtonHighlightColorChanged()
            => CloseButtonHighlightColorChanged?.Invoke(this, EventArgs.Empty);

        /// <summary>
        /// Attempts to obtain a suitable <see cref="T:System.Drawing.Image" /> that is to
        /// be used for rendering either the <b>Restore</b> or the <b>Maximize</b> box,
        /// depending on whether the parent window is in the
        /// <see cref="F:System.Windows.Forms.FormWindowState.Maximized" />.
        /// </summary>
        /// <remarks>
        /// If the parent window is set to a <see langword="null" /> reference or
        /// is currently disposed, then this method returns a <see langword="null" />
        /// reference.
        /// </remarks>
        /// <returns>
        /// If successful, a reference to an instance of
        /// <see cref="T:System.Drawing.Image" /> that can be used for rendering;
        /// otherwise, a <see langword="null" /> reference is returned.
        /// </returns>
        private Image GetMaximizeOrRestoreBoxImage()
        {
            Image result = default;

            try
            {
                if (_parentWindow == null) return result;
                if (_parentWindow.IsDisposed) return result;

                result =
                    FormWindowState.Maximized.Equals(_parentWindow.WindowState)
                        ? LoadSvg(
                            Encoding.UTF8.GetString(Resources.Restore), 10, 10
                        )
                        : LoadSvg(
                            Encoding.UTF8.GetString(Resources.Maximize), 10, 10
                        );
            }
            catch (Exception ex)
            {
                // dump all the exception info to the log
                DebugUtils.LogException(ex);

                result = default;
            }

            return result;
        }
    }
}