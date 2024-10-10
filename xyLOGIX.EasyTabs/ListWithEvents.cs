using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace xyLOGIX.EasyTabs
{
    /// <summary>Represents a strongly typed list of objects with events.</summary>
    /// <typeparam name="T">The type of elements in the list.</typeparam>
    [DebuggerDisplay("Count = {Count}"), Serializable]
    public class ListWithEvents<T> : List<T>, IListWithEvents<T>
    {
        /// <summary>Synchronization root for thread safety.</summary>
        public readonly object SyncRoot = new object();

        /// <summary>
        /// Flag indicating whether events are being suppressed during an
        /// operation.
        /// </summary>
        private bool _suppressEvents;

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:xyLOGIX.EasyTabs.ListWithEvents`1" /> class that is empty and has
        /// the
        /// default initial capacity.
        /// </summary>
        public ListWithEvents() { }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:xyLOGIX.EasyTabs.ListWithEvents`1" />
        /// class that contains elements copied from the specified collection and has
        /// sufficient capacity to accommodate the number of elements copied.
        /// </summary>
        /// <param name="collection">
        /// The collection whose elements are copied to the new
        /// list.
        /// </param>
        /// <exception cref="T:System.ArgumentNullException">The collection is null.</exception>
        public ListWithEvents(IEnumerable<T> collection) : base(collection) { }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:xyLOGIX.EasyTabs.ListWithEvents`1" /> class that is empty and has
        /// the
        /// specified initial capacity.
        /// </summary>
        /// <param name="capacity">
        /// The number of elements that the new list can initially
        /// store.
        /// </param>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        /// The capacity is less
        /// than 0.
        /// </exception>
        public ListWithEvents(int capacity) : base(capacity) { }

        /// <summary>Gets whether the events are currently being suppressed.</summary>
        public bool EventsSuppressed
        {
            get => _suppressEvents;
            private set
            {
                var changed = value != _suppressEvents;
                _suppressEvents = value;
                if (changed && !_suppressEvents) OnEventsSuppressedChanged();
            }
        }

        /// <summary>
        /// Overloads
        /// <see cref="P:System.Collections.Generic.List`1.Item(System.Int32)" />.
        /// </summary>
        public new virtual T this[int index]
        {
            get => base[index];
            [DebuggerStepThrough] set
            {
                lock (SyncRoot)
                {
                    var flag = false;
                    if (base[index] != null)
                        flag = base[index]
                            .Equals(value);
                    else if (base[index] == null && value == null)
                        flag = true;
                    if (flag)
                        return;
                    base[index] = value;
                    OnItemModified(new ListItemEventArgs(index));
                }
            }
        }

        /// <summary>Occurs whenever the list is cleared.</summary>
        public event EventHandler Cleared;

        /// <summary>Occurs whenever the list's content is modified.</summary>
        public event EventHandler<ListModificationEventArgs> CollectionModified;

        /// <summary>
        /// Occurs when the value of the
        /// <see cref="P:xyLOGIX.EasyTabs.ListWithEvents`1.EventsSuppressed" /> property is
        /// updated.
        /// </summary>
        public event EventHandler EventsSuppressedChanged;

        /// <summary>Occurs whenever a new item is added to the list.</summary>
        public event EventHandler<ListItemEventArgs> ItemAdded;

        /// <summary>Occurs whenever an item is modified.</summary>
        public event EventHandler<ListItemEventArgs> ItemModified;

        /// <summary>Occurs whenever an  item is removed from the list.</summary>
        public event EventHandler ItemRemoved;

        /// <summary>Occurs whenever a range of items is added to the list.</summary>
        public event EventHandler<ListRangeEventArgs> RangeAdded;

        /// <summary>Occurs whenever a range of items is removed from the list.</summary>
        public event EventHandler RangeRemoved;

        /// <summary>Overloads <see cref="M:System.Collections.Generic.List`1.Add(`0)" />.</summary>
        /// <remarks>This operation is thread-safe.</remarks>
        public new virtual void Add(T item)
        {
            int itemIndex;
            lock (SyncRoot)
            {
                base.Add(item);
                itemIndex = Count - 1;
            }

            OnItemAdded(new ListItemEventArgs(itemIndex));
        }

        /// <summary>
        /// Overloads
        /// <see
        ///     cref="M:System.Collections.Generic.List`1.AddRange(System.Collections.Generic.IEnumerable{`0})" />
        /// .
        /// </summary>
        /// <remarks>This operation is thread-safe.</remarks>
        public new virtual void AddRange(IEnumerable<T> collection)
        {
            lock (SyncRoot)
            {
                InsertRange(Count, collection);
            }
        }

        /// <summary>Overloads <see cref="M:System.Collections.Generic.List`1.Clear" />.</summary>
        /// <remarks>This operation is thread-safe.</remarks>
        public new virtual void Clear()
        {
            lock (SyncRoot)
            {
                base.Clear();
            }

            OnCleared(EventArgs.Empty);
        }

        /// <summary>
        /// Overloads
        /// <see cref="M:System.Collections.Generic.List`1.Insert(System.Int32,`0)" />.
        /// </summary>
        /// <remarks>This operation is thread-safe.</remarks>
        public new virtual void Insert(int index, T item)
        {
            lock (SyncRoot)
            {
                base.Insert(index, item);
            }

            OnItemAdded(new ListItemEventArgs(index));
        }

        /// <summary>
        /// Overloads
        /// <see
        ///     cref="M:System.Collections.Generic.List`1.InsertRange(System.Int32,System.Collections.Generic.IEnumerable{`0})" />
        /// .
        /// </summary>
        /// <remarks>This operation is thread-safe.</remarks>
        public new virtual void InsertRange(
            int index,
            IEnumerable<T> collection
        )
        {
            int count;
            lock (SyncRoot)
            {
                base.InsertRange(index, collection);
                count = Count - index;
            }

            OnRangeAdded(new ListRangeEventArgs(index, count));
        }

        /// <summary>
        /// Overloads
        /// <see cref="M:System.Collections.Generic.List`1.Remove(`0)" />.
        /// </summary>
        /// <remarks>This operation is thread-safe.</remarks>
        public new virtual bool Remove(T item)
        {
            bool flag;
            lock (SyncRoot)
            {
                flag = base.Remove(item);
            }

            if (flag)
                OnItemRemoved(EventArgs.Empty);
            return flag;
        }

        /// <summary>
        /// Overloads
        /// <see cref="M:System.Collections.Generic.List`1.RemoveAll(System.Predicate{`0})" />
        /// .
        /// </summary>
        /// <remarks>This operation is thread-safe.</remarks>
        public new virtual int RemoveAll(Predicate<T> match)
        {
            int num;
            lock (SyncRoot)
            {
                num = base.RemoveAll(match);
            }

            if (num > 0)
                OnRangeRemoved(EventArgs.Empty);
            return num;
        }

        /// <summary>
        /// Overloads
        /// <see cref="M:System.Collections.Generic.List`1.RemoveAt(System.Int32)" />.
        /// </summary>
        /// <remarks>This operation is thread-safe.</remarks>
        public new virtual void RemoveAt(int index)
        {
            lock (SyncRoot)
            {
                base.RemoveAt(index);
            }

            OnItemRemoved(EventArgs.Empty);
        }

        /// <summary>
        /// Overloads
        /// <see
        ///     cref="M:System.Collections.Generic.List`1.RemoveRange(System.Int32,System.Int32)" />
        /// .
        /// </summary>
        /// <remarks>This operation is thread-safe.</remarks>
        public new virtual void RemoveRange(int index, int count)
        {
            int count1;
            int count2;
            lock (SyncRoot)
            {
                count1 = Count;
                base.RemoveRange(index, count);
                count2 = Count;
            }

            if (count1 == count2)
                return;
            OnRangeRemoved(EventArgs.Empty);
        }

        /// <summary>Removes the specified list of entries from the collection.</summary>
        /// <param name="collection">Collection to be removed from the list.</param>
        /// <remarks>
        /// This operation employs
        /// <see cref="M:xyLOGIX.EasyTabs.ListWithEvents`1.Remove(`0)" />
        /// method for removing each individual item which is thread-safe.  However,
        /// overall
        /// operation isn't atomic, and hence does not guarantee thread-safety.
        /// </remarks>
        public virtual void RemoveRange(IEnumerable<T> collection)
        {
            if (collection == null) return;
            if (!collection.Any()) return;

            foreach (var item in collection.ToArray())
                Remove(item);
        }

        /// <summary>
        /// Resumes raising events after
        /// <see cref="M:xyLOGIX.EasyTabs.ListWithEvents`1.SuppressEvents" /> call.
        /// </summary>
        public void ResumeEvents()
            => SetEventsSuppressed(false);

        /// <summary>
        /// Stops raising events until
        /// <see cref="M:xyLOGIX.EasyTabs.ListWithEvents`1.ResumeEvents" /> is called.
        /// </summary>
        public void SuppressEvents()
            => SetEventsSuppressed();

        /// <summary>
        /// Raises <see cref="E:xyLOGIX.EasyTabs.ListWithEvents`1.CollectionModified" />
        /// and <see cref="E:xyLOGIX.EasyTabs.ListWithEvents`1.Cleared" /> events.
        /// </summary>
        /// <param name="e">
        /// An <see cref="T:System.EventArgs" /> that contains the event
        /// data.
        /// </param>
        protected virtual void OnCleared(EventArgs e)
        {
            if (_suppressEvents)
                return;
            Cleared?.Invoke(this, e);

            OnCollectionModified(
                new ListModificationEventArgs(ListModification.Cleared, -1, -1)
            );
        }

        /// <summary>
        /// Raises <see cref="E:xyLOGIX.EasyTabs.ListWithEvents`1.CollectionModified" />
        /// events.
        /// </summary>
        /// <param name="e">
        /// An <see cref="T:xyLOGIX.EasyTabs.ListModificationEventArgs" /> that
        /// contains the event data.
        /// </param>
        protected virtual void OnCollectionModified(ListModificationEventArgs e)
        {
            if (_suppressEvents || CollectionModified == null)
                return;
            CollectionModified(this, e);
        }

        /// <summary>
        /// Raises the
        /// <see cref="E:xyLOGIX.EasyTabs.ListWithEvents`1.EventsSuppressedChanged" />
        /// event.
        /// </summary>
        protected virtual void OnEventsSuppressedChanged()
            => EventsSuppressedChanged?.Invoke(this, EventArgs.Empty);

        /// <summary>
        /// Raises <see cref="E:xyLOGIX.EasyTabs.ListWithEvents`1.CollectionModified" />
        /// and <see cref="E:xyLOGIX.EasyTabs.ListWithEvents`1.ItemAdded" /> events.
        /// </summary>
        /// <param name="e">
        /// An <see cref="T:xyLOGIX.EasyTabs.ListItemEventArgs" /> that contains
        /// the event data.
        /// </param>
        protected virtual void OnItemAdded(ListItemEventArgs e)
        {
            if (_suppressEvents)
                return;
            ItemAdded?.Invoke(this, e);
            OnCollectionModified(
                new ListModificationEventArgs(
                    ListModification.ItemAdded, e.ItemIndex, 1
                )
            );
        }

        /// <summary>
        /// Raises <see cref="E:xyLOGIX.EasyTabs.ListWithEvents`1.CollectionModified" />
        /// and <see cref="E:xyLOGIX.EasyTabs.ListWithEvents`1.ItemModified" /> events.
        /// </summary>
        /// <param name="e">
        /// An <see cref="T:xyLOGIX.EasyTabs.ListItemEventArgs" /> that contains
        /// the event data.
        /// </param>
        protected virtual void OnItemModified(ListItemEventArgs e)
        {
            if (_suppressEvents)
                return;
            ItemModified?.Invoke(this, e);
            OnCollectionModified(
                new ListModificationEventArgs(
                    ListModification.ItemModified, e.ItemIndex, 1
                )
            );
        }

        /// <summary>
        /// Raises <see cref="E:xyLOGIX.EasyTabs.ListWithEvents`1.CollectionModified" />
        /// and <see cref="E:xyLOGIX.EasyTabs.ListWithEvents`1.ItemRemoved" /> events.
        /// </summary>
        /// <param name="e">
        /// An <see cref="T:System.EventArgs" /> that contains the event
        /// data.
        /// </param>
        protected virtual void OnItemRemoved(EventArgs e)
        {
            if (_suppressEvents)
                return;
            ItemRemoved?.Invoke(this, e);
            OnCollectionModified(
                new ListModificationEventArgs(
                    ListModification.ItemRemoved, -1, 1
                )
            );
        }

        /// <summary>
        /// Raises <see cref="E:xyLOGIX.EasyTabs.ListWithEvents`1.CollectionModified" />
        /// and <see cref="E:xyLOGIX.EasyTabs.ListWithEvents`1.RangeAdded" /> events.
        /// </summary>
        /// <param name="e">
        /// An <see cref="T:xyLOGIX.EasyTabs.ListRangeEventArgs" /> that contains
        /// the event data.
        /// </param>
        protected virtual void OnRangeAdded(ListRangeEventArgs e)
        {
            if (_suppressEvents)
                return;
            RangeAdded?.Invoke(this, e);
            OnCollectionModified(
                new ListModificationEventArgs(
                    ListModification.RangeAdded, e.StartIndex, e.Count
                )
            );
        }

        /// <summary>
        /// Raises <see cref="E:xyLOGIX.EasyTabs.ListWithEvents`1.CollectionModified" />
        /// and <see cref="E:xyLOGIX.EasyTabs.ListWithEvents`1.RangeRemoved" /> events.
        /// </summary>
        /// <param name="e">
        /// An <see cref="T:System.EventArgs" /> that contains the event
        /// data.
        /// </param>
        protected virtual void OnRangeRemoved(EventArgs e)
        {
            if (_suppressEvents)
                return;
            RangeRemoved?.Invoke(this, e);
            OnCollectionModified(
                new ListModificationEventArgs(
                    ListModification.RangeRemoved, -1, -1
                )
            );
        }

        /// <summary>
        /// Updates the value of the
        /// <see cref="P:xyLOGIX.EasyTabs.ListWithEvents`1.EventsSuppressed" /> property to
        /// match
        /// the specified <paramref name="eventsSuppressed" /> setting.s
        /// </summary>
        /// <param name="eventsSuppressed">
        /// (Optional.) A <see cref="T:System.Boolean" />
        /// value that is to be the new setting of the
        /// <see cref="P:xyLOGIX.EasyTabs.ListWithEvents`1.EventsSuppressed" /> property.
        /// <para />
        /// The default value of this parameter is <see langword="true" />.
        /// </param>
        protected void SetEventsSuppressed(bool eventsSuppressed = true)
            => EventsSuppressed = eventsSuppressed;
    }
}