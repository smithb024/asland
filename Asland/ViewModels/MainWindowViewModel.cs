namespace Asland.ViewModels
{
    using CommunityToolkit.Mvvm.ComponentModel;
    using Interfaces.ViewModels;

    /// <summary>
    /// The view model which supports the main window.
    /// </summary>
    public class MainWindowViewModel : ObservableRecipient, IMainWindowViewModel
    {
        /// <summary>
        /// Gets the temporary test string.
        /// </summary>
        public string TestString => "TestString";
    }
}