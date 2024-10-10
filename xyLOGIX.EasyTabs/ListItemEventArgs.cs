using System;

namespace xyLOGIX.EasyTabs
{
    /// <summary>
    /// Provides data for the
    /// <see cref="E:xyLOGIX.EasyTabs.ListWithEvents`1.ItemAdded" /> events.
    /// </summary>
    [Serializable]
    public class ListItemEventArgs : EventArgs
    {
        /// <summary>Index of the item being changed.</summary>
        private readonly int _itemIndex;

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:xyLOGIX.EasyTabs.ListItemEventArgs" /> class.
        /// </summary>
        /// <param name="itemIndex">Index of the item being changed.</param>
        public ListItemEventArgs(int itemIndex)
            => _itemIndex = itemIndex;

        /// <summary>Gets the index of the item changed.</summary>
        public int ItemIndex
            => _itemIndex;
    }
}