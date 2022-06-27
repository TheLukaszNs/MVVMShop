using System.Threading.Tasks;

namespace MVVMShop.Commands
{
    public abstract class AsyncBaseCommand : BaseCommand
    {
        private bool _isExecuting;

        private bool IsExecuting
        {
            get => _isExecuting;
            set
            {
                _isExecuting = value;
                OnCanExecuteChanged();
            }
        }

        public override bool CanExecute(object parameter) => !IsExecuting && base.CanExecute(parameter);

        public override async void Execute(object parameter)
        {
            IsExecuting = true;

            try
            {
                await ExecuteAsync(parameter);
            }
            finally
            {
                IsExecuting = false;
            }
        }

        public abstract Task ExecuteAsync(object parameter);
    }
}