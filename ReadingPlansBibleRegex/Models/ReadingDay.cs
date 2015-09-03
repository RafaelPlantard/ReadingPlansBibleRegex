using Microsoft.Practices.Prism.Mvvm;
using System.Collections.ObjectModel;

namespace ReadingPlansBibleRegex.Models
{
    public class ReadingDay : BindableBase
    {
        private ObservableCollection<ReadingItem> _readingItems;

        public ObservableCollection<ReadingItem> ReadingItems
        {
            get { return _readingItems; }
            set { SetProperty(ref _readingItems, value); }
        }

        private bool _isComplete;

        public bool IsComplete
        {
            get { return _isComplete; }
            set { SetProperty(ref _isComplete, value); }
        }

    }
}