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
    /// <b>Minimize</b>, <b>Maximize</b>, and <b>Close</b> button(s).
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
        /// color of the <b>Close</b> button.
        /// </summary>
        /// <remarks>
        /// The highlight color is painted when the use hovers the mouse pointer
        /// over the <b>Close</b> box or clicks the <b>Close</b> button.
        /// </remarks>
        private Color _closeButtonHighlightColor = Color.FromArgb(232, 17, 35);

        /// <summary>
        /// A <see cref="T:System.Drawing.Rectangle" /> value specifying the bounds of the
        /// <b>Maximize/Restore</b> button.
        /// </summary>
        protected Rectangle _maximizeRestoreButtonArea =
            new Rectangle(45, 0, 45, 29);

        /// <summary>
        /// A <see cref="T:System.Drawing.Rectangle" /> value specifying the bounds of the
        /// <b>Minimize</b> button.
        /// </summary>
        protected Rectangle _minimizeButtonArea = new Rectangle(0, 0, 45, 29);

        /// <summary>
        /// A <see cref="T:System.Drawing.Color" /> value that describes the color to be
        /// used when the mouse pointer hovers over, or clicks, the <b>Minimize</b> or
        /// <b>Maximize</b> button.
        /// </summary>
        private Color _minimizeMaximizeButtonHighlightColor =
            Color.FromArgb(27, Color.Black);

        /// <summary>
        /// Reference to an instance of <see cref="T:xyLOGIX.EasyTabs.TitleBarTabs" /> that
        /// refers to the parent window of the overlay form.
        /// </summary>
        protected TitleBarTabs _parentWindow;

        /// <summary>
        /// Constructs a new instance of
        /// <see cref="T:xyLOGIX.EasyTabs.WindowsSizingBoxes" /> and returns a reference to
        /// it.
        /// </summary>
        /// <param name="parentWindow">
        /// (Required.) Reference to an instance of
        /// <see cref="T:xyLOGIX.EasyTabs.TitleBarTabs" /> that refers to the parent window
        /// of the overlay form.
        /// </param>
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

        /// <summary>
        /// Gets or sets a <see cref="T:System.Drawing.Color" /> value that describes the
        /// color to be used when the mouse pointer hovers over, or clicks, the
        /// <b>Minimize</b> or <b>Maximize</b> button.
        /// </summary>
        /// <remarks>
        /// This property raises the
        /// <see
        ///     cref="E:xyLOGIX.EasyTabs.WindowsSizingBoxes.MinimizeMaximizeButtonHighlightColorChanged" />
        /// event when its value is updated.
        /// </remarks>
        public Color MinimizeMaximizeButtonHighlightColor
        {
            get => _minimizeMaximizeButtonHighlightColor;
            set
            {
                var changed = _minimizeMaximizeButtonHighlightColor != value;
                _minimizeMaximizeButtonHighlightColor = value;
                if (changed) OnMinimizeMaximizeButtonHighlightColorChanged();
            }
        }

        /// <summary>
        /// Gets the total width, in pixels, of the area containing the <b>Minimize</b>,
        /// <b>Maximize/Restore</b>, and <b>Close</b> button(s).
        /// </summary>
        public int Width
            => _minimizeButtonArea.Width + _maximizeRestoreButtonArea.Width +
               _closeButtonArea.Width;

        /// <summary>
        /// Occurs when the value of the
        /// <see cref="P:xyLOGIX.EasyTabs.WindowsSizingBoxes.CloseButtonHighlightColor" />
        /// property is updated.
        /// </summary>
        public event EventHandler CloseButtonHighlightColorChanged;

        /// <summary>
        /// Occurs when the value of the
        /// <see
        ///     cref="P:xyLOGIX.EasyTabs.WindowsSizingBoxes.MinimizeMaximizeButtonHighlightColor" />
        /// property is updated.
        /// </summary>
        public event EventHandler MinimizeMaximizeButtonHighlightColorChanged;

        /// <summary>
        /// Determines whether the area of the <b>Minimize</b>, <b>Maximize</b>, and
        /// <b>Close</b> button(s) contains the specified
        /// <paramref name="mousePointerCoords" />.
        /// </summary>
        /// <param name="mousePointerCoords">
        /// (Required.) A <see cref="T:System.Drawing.Point" /> that contains the current
        /// mouse pointer coordinates.
        /// </param>
        /// <returns>
        /// <see langword="true" /> if the area of the <b>Minimize</b>,
        /// <b>Maximize</b>, and <b>Close</b> button(s) contains the specified
        /// <paramref name="mousePointerCoords" />; <see langword="false" /> otherwise.
        /// </returns>
        public bool Contains(Point mousePointerCoords)
        {
            var result = false;

            try
            {
                if (mousePointerCoords.IsEmpty) return result;
                if (_minimizeButtonArea.IsEmpty) return result;
                if (_maximizeRestoreButtonArea.IsEmpty) return result;
                if (_closeButtonArea.IsEmpty) return result;

                result = _minimizeButtonArea.Contains(mousePointerCoords) ||
                         _maximizeRestoreButtonArea.Contains(
                             mousePointerCoords
                         ) || _closeButtonArea.Contains(mousePointerCoords);
            }
            catch (Exception ex)
            {
                // dump all the exception info to the log
                DebugUtils.LogException(ex);

                result = false;
            }

            return result;
        }

        /// <summary>
        /// Determines whether the specified <paramref name="mousePointerCoords" /> are
        /// within the bounds of the <b>Minimize</b>, <b>Maximize/Restore</b>, or
        /// <b>Close</b> button(s) and returns the corresponding hit-test code(s), if
        /// applicable.
        /// </summary>
        /// <param name="mousePointerCoords">
        /// (Required.) A <see cref="T:System.Drawing.Point" /> that contains the current
        /// mouse pointer coordinates.
        /// </param>
        /// <returns>
        /// One of the <see cref="T:Win32Interop.Enums.HT" /> enumeration value(s)
        /// that describes which key region of the nonclient area of the parent from
        /// contains the specified <paramref name="mousePointerCoords" />, or the
        /// <see cref="F:Win32Interop.Enums.HT.HTNOWHERE" /> value if this cannot be
        /// determined.
        /// </returns>
        public HT NonClientHitTest(Point mousePointerCoords)
        {
            var result = HT.HTNOWHERE;

            try
            {
                if (mousePointerCoords.IsEmpty) return result;
                if (!Contains(mousePointerCoords)) return result;

                if (!_minimizeButtonArea.IsEmpty &&
                    _minimizeButtonArea.Contains(mousePointerCoords))
                    return HT.HTMINBUTTON;
                if (_maximizeRestoreButtonArea.Contains(mousePointerCoords))
                    return HT.HTMAXBUTTON;
                if (_closeButtonArea.Contains(mousePointerCoords))
                    return HT.HTCLOSE;
            }
            catch (Exception ex)
            {
                // dump all the exception info to the log
                DebugUtils.LogException(ex);

                result = HT.HTNOWHERE;
            }

            return result;
        }

        /// <summary>
        /// Call this method to render the <b>Minimize</b>, <b>Maximize</b>, and
        /// <b>Close</b> button(s) on the parent form.
        /// </summary>
        /// <param name="g">
        /// (Required.) Reference to an instance of
        /// <see cref="T:System.Drawing.Graphics" /> that describes the drawing surface.
        /// </param>
        /// <param name="mousePointerCoords">
        /// (Required.) A <see cref="T:System.Drawing.Point" /> that contains the current
        /// mouse pointer coordinates.
        /// </param>
        /// <remarks>
        /// This method takes no action if the <paramref name="g" /> parameter is
        /// set to a <see langword="null" /> reference, if the
        /// <paramref name="mousePointerCoords" /> is set to
        /// <see cref="F:System.Drawing.Point.Empty" />, or if the parent window is in the
        /// process of being closed or disposed.
        /// </remarks>
        public void Render(Graphics g, Point mousePointerCoords)
        {
            try
            {
                if (g == null) return;
                if (_closeButtonArea.IsEmpty) return;
                if (_maximizeRestoreButtonArea.IsEmpty) return;
                if (_minimizeButtonArea.IsEmpty) return;
                if (_parentWindow == null) return;
                if (_parentWindow.IsClosing) return;
                if (_parentWindow.IsDisposed) return;
                if (_parentWindow.ClientRectangle.IsEmpty) return;

                // Get the coordinates of the right edge of the
                // parent window using the width of its Client
                // Rectangle as a reference.  Then, use this value
                // to set the X coordinates of the Minimize, Maximize/Restore,
                // and Close button(s), respectively.
                var right = _parentWindow.ClientRectangle.Width;
                if (right <= 0) return;

                var closeButtonHighlighted = false;

                _minimizeButtonArea.X = right - 135;
                _maximizeRestoreButtonArea.X = right - 90;
                _closeButtonArea.X = right - 45;

                // Draw/paint the Minimize, Maximize/Restore, and Close button(s),
                // respectively.
                if (_minimizeButtonArea.Contains(mousePointerCoords))
                    using (var brush = new SolidBrush(
                               _minimizeMaximizeButtonHighlightColor
                           ))
                    {
                        g.FillRectangle(brush, _minimizeButtonArea);
                    }
                else if (_maximizeRestoreButtonArea.Contains(
                             mousePointerCoords
                         ))
                    using (var brush = new SolidBrush(
                               _minimizeMaximizeButtonHighlightColor
                           ))
                    {
                        g.FillRectangle(brush, _maximizeRestoreButtonArea);
                    }
                else if (_closeButtonArea.Contains(mousePointerCoords))
                    using (var brush =
                           new SolidBrush(_closeButtonHighlightColor))
                    {
                        g.FillRectangle(brush, _closeButtonArea);
                        closeButtonHighlighted = true;
                    }

                using (var image = closeButtonHighlighted
                           ? LoadSvg(
                               Encoding.UTF8.GetString(
                                   Resources.CloseHighlight
                               ), 10, 10
                           )
                           : LoadSvg(
                               Encoding.UTF8.GetString(Resources.Close), 10, 10
                           ))
                {
                    g.DrawImage(
                        image, _closeButtonArea.X + 17, _closeButtonArea.Y + 9
                    );
                }

                using (var image = GetMaximizeOrRestoreBoxImage())
                {
                    if (image != null)
                        g.DrawImage(
                            image, _maximizeRestoreButtonArea.X + 17,
                            _maximizeRestoreButtonArea.Y + 9
                        );
                }

                using (var image = LoadSvg(
                           Encoding.UTF8.GetString(Resources.Minimize), 10, 10
                       ))
                {
                    g.DrawImage(
                        image, _minimizeButtonArea.X + 17,
                        _minimizeButtonArea.Y + 9
                    );
                }
            }
            catch (Exception ex)
            {
                // dump all the exception info to the log
                DebugUtils.LogException(ex);
            }
        }

        /// <summary>
        /// Attempts to parse the provided <paramref name="svgXml" />, and, if successful,
        /// returns a <see cref="T:System.Drawing.Image" /> that has been loaded from it.
        /// </summary>
        /// <param name="svgXml">
        /// (Required.) A <see cref="T:System.String" /> that contains
        /// fully-formed XML from which an SVG image can be loaded.
        /// </param>
        /// <param name="width">
        /// (Required.) A positive integer specifying the width of the
        /// resulting <see cref="T:System.Drawing.Image" />.
        /// </param>
        /// <param name="height">
        /// (Required.) A positive integer specifying the height of
        /// the resulting <see cref="T:System.Drawing.Image" />.
        /// </param>
        /// <returns>
        /// If successful, a reference to an instance of
        /// <see cref="T:System.Drawing.Image" /> describing the loaded image; otherwise, a
        /// <see langword="null" /> reference is returned.
        /// </returns>
        protected Image LoadSvg(string svgXml, int width, int height)
        {
            Image result = default;

            try
            {
                if (string.IsNullOrWhiteSpace(svgXml)) return result;
                if (width <= 0 || height <= 0)
                    return
                        result; // can't have width or height equal to or less than zero

                var xmlDocument = new XmlDocument();
                xmlDocument.LoadXml(svgXml);

                var svgDocument = SvgDocument.Open(xmlDocument);
                if (svgDocument == null)
                    return result; // failed to open SVG document

                result = svgDocument.Draw(width, height);
            }
            catch (Exception ex)
            {
                // dump all the exception info to the log
                DebugUtils.LogException(ex);

                result = default;
            }

            return result;
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
        /// Raises the
        /// <see
        ///     cref="E:xyLOGIX.EasyTabs.WindowsSizingBoxes.MinimizeMaximizeButtonHighlightColorChanged" />
        /// event.
        /// </summary>
        /// <remarks>
        /// This method is called when the value of the
        /// <see
        ///     cref="P:xyLOGIX.EasyTabs.WindowsSizingBoxes.MinimizeMaximizeButtonHighlightColor" />
        /// property is updated.
        /// </remarks>
        protected virtual void OnMinimizeMaximizeButtonHighlightColorChanged()
            => MinimizeMaximizeButtonHighlightColorChanged?.Invoke(
                this, EventArgs.Empty
            );

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