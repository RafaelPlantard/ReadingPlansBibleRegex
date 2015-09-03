using Microsoft.Practices.Prism.Mvvm;
using System.Collections.ObjectModel;

namespace ReadingPlansBibleRegex.Models
{
    public class ReadingPlan : BindableBase
    {
        private int _version;

        public int Version
        {
            get { return _version; }
            set { SetProperty(ref _version, value); }
        }

        private ObservableCollection<ReadingDay> _readingDays;

        public ObservableCollection<ReadingDay> ReadingDays
        {
            get { return _readingDays; }
            set { SetProperty(ref _readingDays, value); }
        }
    }
}
