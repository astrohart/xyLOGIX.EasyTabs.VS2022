using System.Windows.Forms;

namespace xyLOGIX.EasyTabs
{
    /// <summary>
    /// Event delegate for <see cref="E:xyLOGIX.EasyTabs.TitleBarTabs.SelectedTabIndexChanged" />
    /// and <see cref="E:xyLOGIX.EasyTabs.TitleBarTabs.TabDeselected" />.
    /// </summary>
    /// <param name="sender">Object for which this event was raised.</param>
    /// <param name="e">Data associated with the event.</param>
    public delegate void TitleBarTabEventHandler(
        object sender,
        TitleBarTabEventArgs e
    ) where TContent : Form;
}