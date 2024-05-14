using System;
using System.Drawing;
using System.Windows.Forms;
using Win32Interop.Enums;
using Win32Interop.Methods;
using Win32Interop.Structs;

namespace xyLOGIX.EasyTabs
{
    /// <summary>
    /// Form that actually displays the thumbnail content for
    /// <see cref="T:xyLOGIX.EasyTabs.TornTabForm" />.
    /// </summary>
    internal class LayeredWindow : Form
    {
        /// <summary>Default constructor.</summary>
        public LayeredWindow()
        {
            ShowInTaskbar = false;
            FormBorderStyle = FormBorderStyle.None;
        }

        /// <summary>
        /// Makes sure that the window is created with an
        /// <see cref="F:Win32Interop.Enums.WS_EX.WS_EX_LAYERED" /> flag set so that it can
        /// be alpha-blended properly with the desktop
        /// contents underneath it.
        /// </summary>
        protected override CreateParams CreateParams
        {
            get
            {
                var createParams = base.CreateParams;
                createParams.ExStyle |= 524288;
                return createParams;
            }
        }

        /// <summary>
        /// Renders the tab thumbnail (<paramref name="image" />) using the given
        /// dimensions and coordinates and blends it properly with the underlying desktop
        /// elements.
        /// </summary>
        /// <param name="image">Thumbnail to display.</param>
        /// <param name="opacity">
        /// Opacity that <paramref name="image" /> should be
        /// displayed with.
        /// </param>
        /// <param name="width">Width of <paramref name="image" />.</param>
        /// <param name="height">Height of <paramref name="image" />.</param>
        /// <param name="position">
        /// Screen position that <paramref name="image" /> should be
        /// displayed at.
        /// </param>
        public void UpdateWindow(
            Bitmap image,
            byte opacity,
            int width,
            int height,
            POINT position
        )
        {
            var windowDc = User32.GetWindowDC(Handle);
            var compatibleDc = Gdi32.CreateCompatibleDC(windowDc);
            var hbitmap = image.GetHbitmap(Color.FromArgb(0));
            var num = Gdi32.SelectObject(compatibleDc, hbitmap);
            var size = new SIZE { cx = 0, cy = 0 };
            var point = new POINT { x = 0, y = 0 };
            if (width == -1 || height == -1)
            {
                size.cx = image.Width;
                size.cy = image.Height;
            }
            else
            {
                size.cx = Math.Min(image.Width, width);
                size.cy = Math.Min(image.Height, height);
            }

            var blendfunction = new BLENDFUNCTION
            {
                BlendOp = Convert.ToByte(0),
                SourceConstantAlpha = opacity,
                AlphaFormat = Convert.ToByte(1),
                BlendFlags = 0
            };
            User32.UpdateLayeredWindow(
                Handle, windowDc, ref position, ref size, compatibleDc,
                ref point, 0U, ref blendfunction, (ULW)2
            );
            Gdi32.SelectObject(compatibleDc, num);
            Gdi32.DeleteObject(hbitmap);
            Gdi32.DeleteDC(compatibleDc);
            User32.ReleaseDC(Handle, windowDc);
        }
    }
}