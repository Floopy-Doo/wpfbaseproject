namespace Base.UI
{
    using System.Windows;
    using System.Windows.Threading;

    /// <summary>
    ///     Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
            this.DispatcherUnhandledException -= this.OnDispatcherUnhandledException;
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            this.DispatcherUnhandledException += this.OnDispatcherUnhandledException;

            MainWindow mainWindow = new MainWindow { DataContext = new MainWindowViewModel() };
            mainWindow.ShowDialog();
        }

        private void OnDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            //TODO: Unexpected Error Handlers
        }
    }
}