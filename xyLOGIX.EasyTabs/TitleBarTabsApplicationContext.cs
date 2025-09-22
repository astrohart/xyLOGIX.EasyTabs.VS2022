using System.Collections.Generic;
using System.Windows.Forms;

namespace xyLOGIX.EasyTabs
{
    /// <summary>
    /// Application context to use when starting a
    /// <see cref="T:xyLOGIX.EasyTabs.TitleBarTabs" /> application via
    /// <see
    ///     cref="M:System.Windows.Forms.Application.Run(System.Windows.Forms.ApplicationContext)" />
    /// .  Used to
    /// track open windows so that the entire application doesn't quit when the
    /// first-opened window is closed.
    /// </summary>
    public class TitleBarTabsApplicationContext : ApplicationContext
    {
        /// <summary>List of all opened windows.</summary>
        protected List<TitleBarTabs> _openWindows = new List<TitleBarTabs>();

        /// <summary>List of all opened windows.</summary>
        public List<TitleBarTabs> OpenWindows
            => _openWindows;

        /// <summary>
        /// Adds <paramref name="window" /> to
        /// <see cref="F:xyLOGIX.EasyTabs.TitleBarTabsApplicationContext._openWindows" /> and
        /// attaches event handlers to its
        /// <see cref="E:System.Windows.Forms.Form.FormClosed" /> event to keep track
        /// of it.
        /// </summary>
        /// <param name="window">Window that we're opening.</param>
        public void OpenWindow(TitleBarTabs window)
        {
            if (_openWindows.Contains(window))
                return;
            window.ApplicationContext = this;
            _openWindows.Add(window);
            window.FormClosed += OnWindowFormClosed;
        }

        /// <summary>
        /// Constructor; takes the initial window to display and, if it's not
        /// closing, opens it and shows it.
        /// </summary>
        /// <param name="initialFormInstance">Initial window to display.</param>
        public void Start(TitleBarTabs initialFormInstance)
        {
            if (initialFormInstance.IsClosing)
            {
                ExitThread();
            }
            else
            {
                OpenWindow(initialFormInstance);
                initialFormInstance.Show();
            }
        }

        /// <summary>
        /// Handler method that's called when an item in
        /// <see cref="F:xyLOGIX.EasyTabs.TitleBarTabsApplicationContext._openWindows" /> has its
        /// <see cref="E:System.Windows.Forms.Form.FormClosed" /> event invoked.  Removes
        /// the window
        /// from <see cref="F:xyLOGIX.EasyTabs.TitleBarTabsApplicationContext._openWindows" /> and,
        /// if there are no more windows open, calls
        /// <see cref="M:System.Windows.Forms.ApplicationContext.ExitThread" />.
        /// </summary>
        /// <param name="sender">Object from which this event originated.</param>
        /// <param name="e">Arguments associated with the event.</param>
        protected void OnWindowFormClosed([NotLogged] object sender, FormClosed[NotLogged] EventArgs e)
        {
            if (_openWindows == null) return;

            if (_openWindows.Count > 0 && _openWindows.Contains((TitleBarTabs)sender))
                _openWindows.Remove((TitleBarTabs)sender);
            
            if (_openWindows.Count > 0)
                return;
            
            ExitThread();
        }
    }
}