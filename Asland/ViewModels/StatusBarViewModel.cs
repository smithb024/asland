namespace Asland.ViewModels
{
    using Asland.Interfaces.ViewModels;

    /// <summary>
    /// View model which describes the application status bar.
    /// </summary>
    public class StatusBarViewModel : IStatusBarViewModel
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="StatusBarViewModel"/> class.
        /// </summary>
        public StatusBarViewModel()
        {

        }

        /// <summary>
        /// Gets the latest status of the application.
        /// </summary>
        public string Status { get; }
    }
}
