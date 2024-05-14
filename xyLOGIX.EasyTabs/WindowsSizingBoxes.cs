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
    public class WindowsSizingBoxes
    {
        protected Rectangle _closeButtonArea = new Rectangle(90, 0, 45, 29);

        protected Brush _closeButtonHighlight =
            new SolidBrush(Color.FromArgb(232, 17, 35));

        protected Image _closeHighlightImage;
        protected Image _closeImage;
        protected Image _maximizeImage;

        protected Rectangle _maximizeRestoreButtonArea =
            new Rectangle(45, 0, 45, 29);

        protected Rectangle _minimizeButtonArea = new Rectangle(0, 0, 45, 29);
        protected Image _minimizeImage;

        protected Brush _minimizeMaximizeButtonHighlight =
            new SolidBrush(Color.FromArgb(27, Color.Black));

        protected TitleBarTabs _parentWindow;
        protected Image _restoreImage;

        public WindowsSizingBoxes(TitleBarTabs parentWindow)
        {
            _parentWindow = parentWindow;
            _minimizeImage = LoadSvg(
                Encoding.UTF8.GetString(Resources.Minimize), 10, 10
            );
            _restoreImage = LoadSvg(
                Encoding.UTF8.GetString(Resources.Restore), 10, 10
            );
            _maximizeImage = LoadSvg(
                Encoding.UTF8.GetString(Resources.Maximize), 10, 10
            );
            _closeImage = LoadSvg(
                Encoding.UTF8.GetString(Resources.Close), 10, 10
            );
            _closeHighlightImage = LoadSvg(
                Encoding.UTF8.GetString(Resources.CloseHighlight), 10, 10
            );
        }

        public int Width
            => _minimizeButtonArea.Width + _maximizeRestoreButtonArea.Width +
               _closeButtonArea.Width;

        public bool Contains(Point cursor)
            => _minimizeButtonArea.Contains(cursor) ||
               _maximizeRestoreButtonArea.Contains(cursor) ||
               _closeButtonArea.Contains(cursor);

        public HT NonClientHitTest(Point cursor)
        {
            if (_minimizeButtonArea.Contains(cursor))
                return (HT)8;
            if (_maximizeRestoreButtonArea.Contains(cursor))
                return (HT)9;
            return _closeButtonArea.Contains(cursor) ? (HT)20 : 0;
        }

        public void Render(Graphics graphicsContext, Point cursor)
        {
            var width = _parentWindow.ClientRectangle.Width;
            var flag = false;
            _minimizeButtonArea.X = width - 135;
            _maximizeRestoreButtonArea.X = width - 90;
            _closeButtonArea.X = width - 45;
            if (_minimizeButtonArea.Contains(cursor))
            {
                graphicsContext.FillRectangle(
                    _minimizeMaximizeButtonHighlight, _minimizeButtonArea
                );
            }
            else if (_maximizeRestoreButtonArea.Contains(cursor))
            {
                graphicsContext.FillRectangle(
                    _minimizeMaximizeButtonHighlight, _maximizeRestoreButtonArea
                );
            }
            else if (_closeButtonArea.Contains(cursor))
            {
                graphicsContext.FillRectangle(
                    _closeButtonHighlight, _closeButtonArea
                );
                flag = true;
            }

            graphicsContext.DrawImage(
                flag ? _closeHighlightImage : _closeImage,
                _closeButtonArea.X + 17, _closeButtonArea.Y + 9
            );
            graphicsContext.DrawImage(
                _parentWindow.WindowState == FormWindowState.Maximized
                    ? _restoreImage
                    : _maximizeImage, _maximizeRestoreButtonArea.X + 17,
                _maximizeRestoreButtonArea.Y + 9
            );
            graphicsContext.DrawImage(
                _minimizeImage, _minimizeButtonArea.X + 17,
                _minimizeButtonArea.Y + 9
            );
        }

        /// <summary>
        /// Called to parse the provided <paramref name="svgXml" /> and, if successful,
        /// render it as a <see cref="T:System.Drawing.Image" /> of the specified
        /// <paramref name="width" /> and <paramref name="height" />, in pixels.
        /// </summary>
        /// <param name="svgXml">
        /// (Required.) A <see cref="T:System.String" /> containing
        /// the XML that is to be parsed.
        /// </param>
        /// <param name="width">
        /// (Required.) An <see cref="T:System.Int32" /> that is
        /// greater than zero, indicating the number of pixels of width that the resulting
        /// <see cref="T:System.Drawing.Image" /> is to have.
        /// </param>
        /// <param name="height">
        /// (Required.) An <see cref="T:System.Int32" /> that is
        /// greater than zero, indicating the number of pixels of height that the resulting
        /// <see cref="T:System.Drawing.Image" /> is to have.
        /// </param>
        /// <remarks>
        /// If a blank value is passed for the <paramref name="svgXml" /> parameter, or if
        /// the XML it contains is not parsable, then a <see langword="null" /> reference
        /// is returned.
        /// <para />
        /// If either or both of <paramref name="width" /> and <paramref name="height" />
        /// are set to zero or a negative quantity, then this method returns a
        /// <see langword="null" /> reference.
        /// <para />
        /// If a <see cref="T:System.Exception" /> is caught during the execution of this
        /// method, a <see langword="null" /> reference is returned.
        /// </remarks>
        /// <returns>
        /// If successful, a <see cref="T:System.Drawing.Image" /> containing the
        /// rendered content; otherwise, a <see langword="null" /> reference is returned.
        /// </returns>
        protected Image LoadSvg(string svgXml, int width, int height)
        {
            Image result = default;

            try
            {
                if (string.IsNullOrWhiteSpace(svgXml)) return result;
                if (width <= 0 || height <= 0) return result;

                var xmlDocument = new XmlDocument();
                xmlDocument.LoadXml(svgXml);

                var svgDocument = SvgDocument.Open(xmlDocument);
                if (svgDocument == null) return result;

                result = svgDocument.Draw(width, height);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR: {ex.Message}");

                result = default;
            }

            return result;
        }
    }
}