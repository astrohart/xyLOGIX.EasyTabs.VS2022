using System.ComponentModel;
using System.Windows.Forms;

namespace xyLOGIX.EasyTabs
{
    /// <summary>
    /// Event arguments class for a cancelable event that occurs on a
    /// collection of <see cref="T:xyLOGIX.EasyTabs.TitleBarTab" />s.
    /// </summary>
    public class TitleBarTabCancelEventArgs : CancelEventArgs
    {
        /// <summary>Action that is being performed.</summary>
        public TabControlAction Action { get; set; }

        /// <summary>
        /// The tab that the
        /// <see cref="P:xyLOGIX.EasyTabs.TitleBarTabCancelEventArgs.Action" /> is being
        /// performed
        /// on.
        /// </summary>
        public TitleBarTab Tab { get; set; }

        /// <summary>Index of the tab within the collection.</summary>
        public int TabIndex { get; set; }
    }
}