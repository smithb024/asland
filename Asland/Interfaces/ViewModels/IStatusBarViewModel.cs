namespace Asland.Interfaces.ViewModels
{
    /// <summary>
    /// View model used to describe the main window status bar.
    /// </summary>
    public interface IStatusBarViewModel
    {
        /// <summary>
        /// Gets the latest status of the application.
        /// </summary>
        string Status { get; }
    }
}