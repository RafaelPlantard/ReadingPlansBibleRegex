using Microsoft.Practices.Prism.Mvvm;

namespace ReadingPlansBibleRegex.Models
{
    public class ReadingItem : BindableBase
    {
        private short _day;

        public short Day
        {
            get { return _day; }
            set { SetProperty(ref _day, value); }
        }

        private string _bookAcronym;

        public string BookAcronym
        {
            get { return _bookAcronym; }
            set { SetProperty(ref _bookAcronym, value); }
        }

        private byte _chapter;

        public byte Chapter
        {
            get { return _chapter; }
            set { SetProperty(ref _chapter, value); }
        }

        private bool _isAllChapter;

        public bool IsAllChapter
        {
            get { return _isAllChapter; }
            set { SetProperty(ref _isAllChapter, value); }
        }

        private byte _startVerse;

        public byte StartVerse
        {
            get { return _startVerse; }
            set { SetProperty(ref _startVerse, value); }
        }

        private byte _endVerse;

        public byte EndVerse
        {
            get { return _endVerse; }
            set { SetProperty(ref _endVerse, value); }
        }

    }
}