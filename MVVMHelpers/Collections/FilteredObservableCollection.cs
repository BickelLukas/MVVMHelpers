using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;

namespace MVVMHelpers.Collections
{
    /// <inheritdoc />
    /// <summary>
    /// Creates an Observable Collection that automatically updates when the base collection updates
    /// </summary>
    /// <typeparam name="T">Item type</typeparam>
    public class FilteredObservableCollection<T> : ObservableRangeCollection<T>
    {
        private readonly ObservableCollection<T> _baseCollection;
        private Func<T, bool> _filter;

        /// <summary>
        /// Sets the Filter used to decide if items are part of the filtered Collection
        /// </summary>
        public Func<T, bool> Filter
        {
            set
            {
                _filter = value;
                ResetCollection();
            }
        }

        /// <summary>
        /// Call this when the filter has changed and you want to refilter your Collection
        /// </summary>
        public void FilterChanged()
        {
            ResetCollection();
        }

        /// <inheritdoc />
        /// <summary>
        /// Instantiates a new FilteredObservableCollection
        /// </summary>
        /// <param name="baseCollection">The Collection used as a base</param>
        /// <param name="filter">The filter used to filter the items</param>
        public FilteredObservableCollection(ObservableCollection<T> baseCollection, Func<T, bool> filter = null)
        {
            _baseCollection = baseCollection;
            _filter = filter;
            ResetCollection();

            baseCollection.CollectionChanged += BaseCollectionChanged;
        }

        private void ResetCollection()
        {
            ReplaceRange(_filter != null ? _baseCollection.Where(_filter) : _baseCollection);
        }

        private void BaseCollectionChanged(object sender, NotifyCollectionChangedEventArgs args)
        {
            switch (args.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    if (args.NewItems?.Count > 0)
                        AddRange(_filter != null ? args.NewItems.Cast<T>().Where(_filter) : args.NewItems.Cast<T>());
                    break;
                case NotifyCollectionChangedAction.Remove:
                    RemoveRange(args.OldItems.Cast<T>());
                    break;
                default:
                    ResetCollection();
                    break;
            }
        }
    }
}
