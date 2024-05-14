﻿using System.Windows.Forms;

namespace xyLOGIX.EasyTabs
{
    /// <summary>
    /// Event delegate for <see cref="E:xyLOGIX.EasyTabs.TitleBarTabs.TabSelected" />
    /// and <see cref="E:xyLOGIX.EasyTabs.TitleBarTabs.TabDeselected" />.
    /// </summary>
    /// <param name="sender">Object for which this event was raised.</param>
    /// <param name="e">Data associated with the event.</param>
    public delegate void TitleBarTabEventHandler<TContent>(
        object sender,
        TitleBarTabEventArgs<TContent> e
    ) where TContent : Form;
}