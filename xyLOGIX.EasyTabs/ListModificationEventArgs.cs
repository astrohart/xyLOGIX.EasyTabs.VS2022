using System;

namespace xyLOGIX.EasyTabs
{
    /// <summary>
    /// Provides data for the
    /// <see cref="E:xyLOGIX.EasyTabs.ListWithEvents`1.CollectionModified" /> events.
    /// </summary>
    [Serializable]
    public class ListModificationEventArgs : ListRangeEventArgs
    {
        /// <summary>Modification being made to the list.</summary>
        private readonly ListModification _modification;

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:xyLOGIX.EasyTabs.ListModificationEventArgs" /> class.
        /// </summary>
        /// <param name="modification">Modification being made to the list.</param>
        /// <param name="startIndex">Index from which the modifications start.</param>
        /// <param name="count">Number of modifications being made.</param>
        public ListModificationEventArgs(
            ListModification modification,
            int startIndex,
            int count
        ) : base(startIndex, count)
            => _modification = modification;

        /// <summary>Gets the type of list modification.</summary>
        public ListModification Modification
            => _modification;
    }
}