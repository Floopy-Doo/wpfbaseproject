namespace Base.UI.Infrastructure.Commands
{
    using System.Threading.Tasks;
    using System.Windows.Input;

    /// <summary>
    /// https://msdn.microsoft.com/en-us/magazine/dn605875.aspx?f=255&MSPPError=-2147217396
    /// </summary>
    public interface IAsyncCommand : ICommand
    {
        Task ExecuteAsync(object parameter);
    }
}