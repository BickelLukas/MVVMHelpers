using System.Collections.ObjectModel;
using MVVMHelpers.Collections;
using MVVMHelpers.ViewModels;

namespace Examples.ViewModels
{
    public class CollectionExampleViewModel : ViewModelBase
    {
        private string _filterString = "";
        public ObservableRangeCollection<string> Items { get; set; }

        public FilteredObservableCollection<string> FilteredItems { get; set; }

        public string FilterString
        {
            get => _filterString;
            set => Set(ref _filterString, value);
        }

        public CollectionExampleViewModel()
        {
            Items = new ObservableRangeCollection<string>(new[]
            {
                "Test 1",
                "Test 2",
                "Test 3",
                "asdf",
                "Foo",
                "Bar",
                "This is a long item",
            });

            FilteredItems = new FilteredObservableCollection<string>(Items, s => s.Contains(FilterString)).Observes(() => FilterString);
        }
    }
}
