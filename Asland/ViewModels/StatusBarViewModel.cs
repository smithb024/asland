namespace Asland.ViewModels
{
    using Asland.Common.Messages;
    using Asland.Interfaces.ViewModels;
    using GalaSoft.MvvmLight;
    using GalaSoft.MvvmLight.Messaging;

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
            Messenger.Default.Register<AppStatusMessage>(this, this.NewStatus);
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
                this.Set(() => this.Status, ref this.status, value);
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
