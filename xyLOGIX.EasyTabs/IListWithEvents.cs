using System.Diagnostics;
using System;
using System.Collections.Generic;

namespace xyLOGIX.EasyTabs
{
    /// <summary>
    /// Defines the publicly-exposed events, methods and properties of an object that
    /// stores a <c>List</c> of <c>T</c> but with events.
    /// </summary>
    /// <typeparam name="T">
    /// (Required.) Data type of each of the element(s) of the
    /// collection.
    /// </typeparam>
    public interface IListWithEvents<T> : IList<T>
    {
        /// <summary>Gets whether the events are currently being suppressed.</summary>
        bool EventsSuppressed { [DebuggerStepThrough] get; }

        /// <summary>Occurs whenever the list is cleared.</summary>
        event EventHandler Cleared;

        /// <summary>Occurs whenever the list's content is modified.</summary>
        event EventHandler<ListModificationEventArgs> CollectionModified;

        /// <summary>
        /// Occurs when the value of the
        /// <see cref="P:xyLOGIX.EasyTabs.ListWithEvents`1.EventsSuppressed" /> property is
        /// updated.
        /// </summary>
        event EventHandler EventsSuppressedChanged;

        /// <summary>Occurs whenever a new item is added to the list.</summary>
        event EventHandler<ListItemEventArgs> ItemAdded;

        /// <summary>Occurs whenever an item is modified.</summary>
        event EventHandler<ListItemEventArgs> ItemModified;

        /// <summary>Occurs whenever an  item is removed from the list.</summary>
        event EventHandler ItemRemoved;

        /// <summary>Occurs whenever a range of items is added to the list.</summary>
        event EventHandler<ListRangeEventArgs> RangeAdded;

        /// <summary>Occurs whenever a range of items is removed from the list.</summary>
        event EventHandler RangeRemoved;

        /// <summary>
        /// Overloads
        /// <see
        ///     cref="M:System.Collections.Generic.List`1.AddRange(System.Collections.Generic.IEnumerable{`0})" />
        /// .
        /// </summary>
        /// <remarks>This operation is thread-safe.</remarks>
        void AddRange(IEnumerable<T> collection);

        /// <summary>
        /// Overloads
        /// <see
        ///     cref="M:System.Collections.Generic.List`1.InsertRange(System.Int32,System.Collections.Generic.IEnumerable{`0})" />
        /// .
        /// </summary>
        /// <remarks>This operation is thread-safe.</remarks>
        void InsertRange(int index, IEnumerable<T> collection);

        /// <summary>
        /// Overloads
        /// <see cref="M:System.Collections.Generic.List`1.RemoveAll(System.Predicate{`0})" />
        /// .
        /// </summary>
        /// <remarks>This operation is thread-safe.</remarks>
        int RemoveAll(Predicate<T> match);

        /// <summary>
        /// Overloads
        /// <see
        ///     cref="M:System.Collections.Generic.List`1.RemoveRange(System.Int32,System.Int32)" />
        /// .
        /// </summary>
        /// <remarks>This operation is thread-safe.</remarks>
        void RemoveRange(int index, int count);

        /// <summary>Removes the specified list of entries from the collection.</summary>
        /// <param name="collection">Collection to be removed from the list.</param>
        /// <remarks>
        /// This operation employs
        /// <see cref="M:xyLOGIX.EasyTabs.ListWithEvents`1.Remove(`0)" />
        /// method for removing each individual item which is thread-safe.  However,
        /// overall
        /// operation isn't atomic, and hence does not guarantee thread-safety.
        /// </remarks>
        void RemoveRange(IEnumerable<T> collection);

        /// <summary>
        /// Resumes raising events after
        /// <see cref="M:xyLOGIX.EasyTabs.ListWithEvents`1.SuppressEvents" /> call.
        /// </summary>
        void ResumeEvents();

        /// <summary>
        /// Stops raising events until
        /// <see cref="M:xyLOGIX.EasyTabs.ListWithEvents`1.ResumeEvents" /> is called.
        /// </summary>
        void SuppressEvents();

        /// <summary>
        /// Removes the extra capacity of the collection after, e.g., items have been
        /// removed or added.
        /// </summary>
        void TrimExcess();
    }
}