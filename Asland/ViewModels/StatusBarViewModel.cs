namespace Asland.ViewModels
{
    using Asland.Common.Messages;
    using Asland.Interfaces.ViewModels;
    using NynaeveLib.ViewModel;
    using CommonMessenger = NynaeveLib.Messenger.Messenger;

    /// <summary>
    /// View model which describes the application status bar.
    /// </summary>
    public class StatusBarViewModel : ViewModelBase, IStatusBarViewModel
    {
        /// <summary>
        /// Application status
        /// </summary>
        private string status;

        /// <summary>
        /// Initialises a new instance of the <see cref="StatusBarViewModel"/> class.
        /// </summary>
        public StatusBarViewModel()
        {
            this.status = string.Empty;
            CommonMessenger.Default.Register<AppStatusMessage>(this, this.NewStatus);
        }

        /// <summary>
        /// Gets the latest status of the application.
        /// </summary>
        public string Status
        {
            get
            {
                return this.status;
            }

            private set
            {
                this.SetProperty(ref this.status, value);
            }
        }

        /// <summary>
        /// Update the status with the contents of the latest message.
        /// </summary>
        /// <param name="message">
        /// Message received via the MVVM messenger service.
        /// </param>
        private void NewStatus(AppStatusMessage message)
        {
            this.Status = message.Status;
        }
    }
}
