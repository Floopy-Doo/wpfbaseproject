namespace Base.UI.Infrastructure.Commands
{
    using System;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Threading.Tasks;

#pragma warning disable SA1402 // Static elements must appear before instance elements
#pragma warning disable SA1204 // Static elements must appear before instance elements

    /// <summary>
    /// https://msdn.microsoft.com/en-us/magazine/dn605875.aspx?f=255&MSPPError=-2147217396
    /// </summary>
    public class AsyncCommand<TResult> : AsyncCommandBase, INotifyPropertyChanged
    {
        private readonly Func<Task<TResult>> command;
        private NotifyTaskCompletion<TResult> execution;

        public AsyncCommand(Func<Task<TResult>> command)
        {
            this.command = command;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public NotifyTaskCompletion<TResult> Execution
        {
            get => this.execution;
            private set
            {
                this.execution = value;
                this.OnPropertyChanged();
            }
        }

        public override bool CanExecute(object parameter)
        {
            return this.Execution == null || this.Execution.IsCompleted;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            this.Execution = new NotifyTaskCompletion<TResult>(this.command());
            this.RaiseCanExecuteChanged();
            await this.Execution.TaskCompletion;
            this.RaiseCanExecuteChanged();
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public static class AsyncCommand
    {
        public static AsyncCommand<object> Create(Func<Task> command)
        {
            return new AsyncCommand<object>(
                async () =>
                {
                    await command();
                    return null;
                });
        }

        public static AsyncCommand<TResult> Create<TResult>(Func<Task<TResult>> command)
        {
            return new AsyncCommand<TResult>(command);
        }
    }

#pragma warning restore SA1204 // Static elements must appear before instance elements
#pragma warning restore SA1204 // Static elements must appear before instance elements
}