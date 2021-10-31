using MagicMvvm;

namespace BasicApp.ViewModels
{
    public class CounterViewModel : ViewModelBase
    {
		private int _currentCount;
        public int CurrentCount
		{
		    get => _currentCount;
			set => SetProperty(ref _currentCount, value);
		}

        public void IncrementCount()
        {
            CurrentCount++;
        }
    }
}
