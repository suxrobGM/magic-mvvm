using MagicMvvm;

namespace BasicApp.ViewModels
{
    public class CounterViewModel : ViewModelBase
    {
        public int CurrentCount { get; set; }

        public void IncrementCount()
        {
            CurrentCount++;
        }
    }
}
