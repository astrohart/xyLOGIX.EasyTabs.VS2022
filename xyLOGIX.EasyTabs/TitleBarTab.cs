using Microsoft.WindowsAPICodePack.Taskbar;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace xyLOGIX.EasyTabs
{
    /// <summary>
    /// Wraps a <see cref="T:System.Windows.Forms.Form" /> instance (
    /// <see cref="F:xyLOGIX.EasyTabs.TitleBarTab._content" />), that represents the content
    /// that should be displayed within a tab instance.
    /// </summary>
    public class TitleBarTab
    {
        /// <summary>Flag indicating whether this tab is active.</summary>
        protected bool _active;

        /// <summary>Content that should be displayed within the tab.</summary>
        protected Form _content;

        /// <summary>Parent window that contains this tab.</summary>
        protected TitleBarTabs _parent;

        /// <summary>Default constructor that initializes the various properties.</summary>
        /// <param name="parent">Parent window that contains this tab.</param>
        public TitleBarTab(TitleBarTabs parent)
        {
            ShowCloseButton = true;
            Parent = parent;
        }

        /// <summary>Flag indicating whether or not this tab is active.</summary>
        public bool Active
        {
            get => _active;
            internal set
            {
                _active = value;
                TabImage = null;
                Content.Visible = value;
            }
        }

        /// <summary>The area in which the tab is rendered in the client window.</summary>
        internal Rectangle Area { get; set; }

        /// <summary>
        /// The caption that's displayed in the tab's title (simply uses the
        /// <see cref="P:System.Windows.Forms.Form.Text" /> of
        /// <see cref="P:xyLOGIX.EasyTabs.TitleBarTab.Content" />).
        /// </summary>
        public string Caption
        {
            get => Content.Text;
            set => Content.Text = value;
        }

        /// <summary>The area of the close button for this tab in the client window.</summary>
        internal Rectangle CloseButtonArea { get; set; }

        /// <summary>The content that should be displayed for this tab.</summary>
        public Form Content
        {
            get => _content;
            set
            {
                if (_content != null)
                {
                    _content.FormClosing -= Content_Closing;
                    _content.TextChanged -= Content_TextChanged;
                }

                _content = value;
                Content.FormBorderStyle = FormBorderStyle.None;
                Content.TopLevel = false;
                Content.Parent = Parent;
                Content.FormClosing += Content_Closing;
                Content.TextChanged += Content_TextChanged;
            }
        }

        /// <summary>
        /// The icon that's displayed in the tab's title (simply uses the
        /// <see cref="P:System.Windows.Forms.Form.Icon" /> of
        /// <see cref="P:xyLOGIX.EasyTabs.TitleBarTab.Content" />).
        /// </summary>
        public Icon Icon
        {
            get => Content.Icon;
            set => Content.Icon = value;
        }

        /// <summary>Parent window that contains this tab.</summary>
        public TitleBarTabs Parent
        {
            get => _parent;
            internal set
            {
                _parent = value;
                if (_content == null)
                    return;
                _content.Parent = _parent;
            }
        }

        /// <summary>
        /// Flag indicating whether or not we should display the close button for
        /// this tab.
        /// </summary>
        public bool ShowCloseButton { get; set; }

        /// <summary>Pre-rendered image of the tab's background.</summary>
        internal Bitmap TabImage { get; set; }

        /// <summary>
        /// Event that is fired when <see cref="P:xyLOGIX.EasyTabs.TitleBarTab.Content" />
        /// 's <see cref="E:System.Windows.Forms.Form.Closing" /> event is fired.
        /// </summary>
        public event CancelEventHandler Closing;

        /// <summary>
        /// Event that is fired when <see cref="P:xyLOGIX.EasyTabs.TitleBarTab.Content" />
        /// 's <see cref="E:System.Windows.Forms.Control.TextChanged" /> event is fired.
        /// </summary>
        public event EventHandler TextChanged;

        /// <summary>
        /// Unsubscribes the tab from any event handlers that may have been
        /// attached to its <see cref="E:xyLOGIX.EasyTabs.TitleBarTab.Closing" /> or
        /// <see cref="E:xyLOGIX.EasyTabs.TitleBarTab.TextChanged" /> events.
        /// </summary>
        public void ClearSubscriptions()
        {
            Closing = null;
            TextChanged = null;
        }

        /// <summary>
        /// Called from <see cref="T:xyLOGIX.EasyTabs.TornTabForm" /> when we need to generate a
        /// thumbnail for a tab when it is torn out of its parent window.  We simply call
        /// <see
        ///     cref="M:System.Drawing.Graphics.CopyFromScreen(System.Drawing.Point,System.Drawing.Point,System.Drawing.Size)" />
        /// to copy the screen contents to a
        /// <see cref="T:System.Drawing.Bitmap" />.
        /// </summary>
        /// <returns>An image of the tab's contents.</returns>
        public virtual Bitmap GetImage()
            => TabbedThumbnailScreenCapture.GrabWindowBitmap(
                Content.Handle, Content.Size
            );

        /// <summary>
        /// Event handler that is invoked when
        /// <see cref="P:xyLOGIX.EasyTabs.TitleBarTab.Content" />'s
        /// <see cref="E:System.Windows.Forms.Form.Closing" /> event is fired, which in
        /// turn fires this class'
        /// <see cref="E:xyLOGIX.EasyTabs.TitleBarTab.Closing" /> event.
        /// </summary>
        /// <param name="sender">
        /// Object from which this event originated (
        /// <see cref="P:xyLOGIX.EasyTabs.TitleBarTab.Content" /> in this case).
        /// </param>
        /// <param name="e">Arguments associated with the event.</param>
        protected void Content_Closing(object sender, CancelEventArgs e)
        {
            if (Closing == null)
                return;
            Closing(this, e);
        }

        /// <summary>
        /// Event handler that is invoked when
        /// <see cref="P:xyLOGIX.EasyTabs.TitleBarTab.Content" />'s
        /// <see cref="E:System.Windows.Forms.Control.TextChanged" /> event is fired, which
        /// in turn fires this class'
        /// <see cref="E:xyLOGIX.EasyTabs.TitleBarTab.TextChanged" /> event.
        /// </summary>
        /// <param name="sender">
        /// Object from which this event originated (
        /// <see cref="P:xyLOGIX.EasyTabs.TitleBarTab.Content" /> in this case).
        /// </param>
        /// <param name="e">Arguments associated with the event.</param>
        private void Content_TextChanged(object sender, EventArgs e)
        {
            if (TextChanged == null)
                return;
            TextChanged(this, e);
        }
    }
}