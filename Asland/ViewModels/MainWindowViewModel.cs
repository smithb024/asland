namespace Asland.ViewModels
{
    using GalaSoft.MvvmLight;
    using Interfaces.ViewModels;
    public class MainWindowViewModel : ViewModelBase, IMainWindowViewModel
    {
        public string TestString => "TestString";
    }
}