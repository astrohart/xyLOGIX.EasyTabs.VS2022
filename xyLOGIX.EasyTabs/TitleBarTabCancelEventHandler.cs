﻿using System.Windows.Forms;

namespace xyLOGIX.EasyTabs
{
    /// <summary>
    /// Event delegate for
    /// <see cref="E:xyLOGIX.EasyTabs.TitleBarTabs.TabDeselecting" /> and
    /// <see cref="E:xyLOGIX.EasyTabs.TitleBarTabs.TabSelecting" /> that allows
    /// subscribers to
    /// cancel the
    /// event and keep it from proceeding.
    /// </summary>
    /// <param name="sender">Object for which this event was raised.</param>
    /// <param name="e">Data associated with the event.</param>
    public delegate void TitleBarTabCancelEventHandler<TContent>(
        object sender,
        TitleBarTabCancelEventArgs<TContent> e
    ) where TContent : Form;
}