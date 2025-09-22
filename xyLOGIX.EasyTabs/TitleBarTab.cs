using PostSharp.Patterns.Diagnostics;
using System.Diagnostics;
using Microsoft.WindowsAPICodePack.Taskbar;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace xyLOGIX.EasyTabs
{
    /// <summary>
    /// Wraps a <see cref="T:System.Windows.Forms.Form" /> instance (
    /// <see cref="F:xyLOGIX.EasyTabs.TitleBarTab._content" />), that represents the
    /// content
    /// that should be displayed within a <c>Tab</c> instance.
    /// </summary>
    public class TitleBarTab
    {
        /// <summary>Flag indicating whether this <c>Tab</c> is active.</summary>
        protected bool _active;

        /// <summary>Content that should be displayed within the <c>Tab</c>.</summary>
        protected Form _content;

        /// <summary>Parent window that contains this <c>Tab</c>.</summary>
        protected TitleBarTabs _parent;

        /// <summary>Default constructor that initializes the various properties.</summary>
        /// <param name="parent">Parent window that contains this <c>Tab</c>.</param>
        /// <exception cref="T:System.ArgumentNullException">
        /// Thrown if the required
        /// parameter, <paramref name="parent" />, is passed a <see langword="null" />
        /// value.
        /// </exception>
        public TitleBarTab(TitleBarTabs parent)
        {
            ShowCloseButton = true;
            Parent = parent ?? throw new ArgumentNullException(nameof(parent));
        }

        /// <summary>Flag indicating whether this <c>Tab</c> is active.</summary>
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

        /// <summary>The area in which the <c>Tab</c> is rendered in the client window.</summary>
        internal Rectangle Area { [DebuggerStepThrough] get; [DebuggerStepThrough] set; }

        /// <summary>
        /// The caption that's displayed in the <c>Tab</c>'s title (simply uses the
        /// <see cref="P:System.Windows.Forms.Form.Text" /> of
        /// <see cref="P:xyLOGIX.EasyTabs.TitleBarTab.Content" />).
        /// </summary>
        public string Caption
        {
            get => Content.Text;
            set => Content.Text = value;
        }

        /// <summary>The area of the close button for this <c>Tab</c> in the client window.</summary>
        internal Rectangle CloseButtonArea { [DebuggerStepThrough] get; [DebuggerStepThrough] set; }

        /// <summary>The content that should be displayed for this <c>Tab</c>.</summary>
        public Form Content
        {
            get => _content;
            [DebuggerStepThrough] set
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
        /// The icon that's displayed in the <c>Tab</c>'s title (simply uses the
        /// <see cref="P:System.Windows.Forms.Form.Icon" /> of
        /// <see cref="P:xyLOGIX.EasyTabs.TitleBarTab.Content" />).
        /// </summary>
        public Icon Icon
        {
            get => Content.Icon;
            set => Content.Icon = value;
        }

        /// <summary>
        /// Gets a value indicating whether the content of the <c>Tab</c> has been
        /// disposed.
        /// </summary>
        public bool IsDisposed
            => _content == null || _content.IsDisposed;

        /// <summary>Parent window that contains this <c>Tab</c>.</summary>
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
        /// Flag indicating whether we should display the close button for
        /// this <c>Tab</c>.
        /// </summary>
        public bool ShowCloseButton { [DebuggerStepThrough] get; [DebuggerStepThrough] set; }

        /// <summary>Pre-rendered image of the <c>Tab</c>'s background.</summary>
        internal Bitmap TabImage { [DebuggerStepThrough] get; [DebuggerStepThrough] set; }

        /// <summary>
        /// Gets a unique identifier that refers to this
        /// <see cref="T:xyLOGIX.EasyTabs.TitleBarTab" /> instance.
        /// </summary>
        public Guid TitleBarTabId { [DebuggerStepThrough] get; } = Guid.NewGuid();

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
        /// Unsubscribes the <c>Tab</c> from any event handlers that may have been
        /// attached to its <see cref="E:xyLOGIX.EasyTabs.TitleBarTab.Closing" /> or
        /// <see cref="E:xyLOGIX.EasyTabs.TitleBarTab.TextChanged" /> events.
        /// </summary>
        public void ClearSubscriptions()
        {
            Closing = null;
            TextChanged = null;
        }

        /// <summary>
        /// Closes this <see cref="T:xyLOGIX.EasyTabs.TitleBarTab" /> by telling its
        /// <see cref="P:xyLOGIX.EasyTabs.TitleBarTab.Content" /> to close.
        /// </summary>
        public void Close()
        {
            if (Content == null) return;
            if (Content.IsDisposed) return;

            Content.Close();
        }

        /// <summary>
        /// Called from <see cref="T:xyLOGIX.EasyTabs.TornTabForm" /> when we need to
        /// generate a
        /// thumbnail for a <c>Tab</c> when it is torn out of its parent window.  We simply
        /// call
        /// <see
        ///     cref="M:System.Drawing.Graphics.CopyFromScreen(System.Drawing.Point,System.Drawing.Point,System.Drawing.Size)" />
        /// to copy the screen contents to a
        /// <see cref="T:System.Drawing.Bitmap" />.
        /// </summary>
        /// <returns>An image of the <c>Tab</c>'s contents.</returns>
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
        protected void Content_Closing([NotLogged] object sender, [NotLogged] CancelEventArgs e)
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
        private void Content_TextChanged([NotLogged] object sender, [NotLogged] EventArgs e)
        {
            if (TextChanged == null)
                return;
            TextChanged(this, e);
        }
    }
}