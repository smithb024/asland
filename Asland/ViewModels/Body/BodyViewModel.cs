
namespace Asland.ViewModels.Body
{
    using Asland.Common.Enums;
    using Asland.Common.Messages;
    using Asland.Interfaces.Model.IO.DataEntry;
    using Asland.Interfaces.ViewModels.Body;
    using GalaSoft.MvvmLight.Messaging;
    using NynaeveLib.ViewModel;

    /// <summary>
    /// View model which describes the main pane.
    /// </summary>
    public class BodyViewModel : ViewModelBase, IBodyViewModel
    {
        /// <summary>
        /// The configuration view model;
        /// </summary>
        private IConfigurationViewModel configurationViewModel;

        /// <summary>
        /// The consistency view model.
        /// </summary>
        private IConsistencyViewModel consistencyViewModel;

        /// <summary>
        /// The data entry view model.
        /// </summary>
        private IDataEntryViewModel dataEntryViewModel;

        /// <summary>
        /// The current view.
        /// </summary>
        private object currentView;

        /// <summary>
        /// Initialises a new instance of the <see cref="BodyViewModel"/> class.
        /// </summary>
        /// <param name="dataEntryModel">
        ///  The model object associated with the data entry process.
        /// </param>
        public BodyViewModel(
            IEventEntry dataEntryModel)
        {
            this.configurationViewModel = new ConfigurationViewModel();
            this.consistencyViewModel = new ConsistencyViewModel();
            this.dataEntryViewModel = 
                new DataEntryViewModel(
                    dataEntryModel);

            this.currentView = this.configurationViewModel;

            Messenger.Default.Register<MainViewMessage>(this, this.ChangeView);
        }

        /// <summary>
        /// Gets the current view.
        /// </summary>
        public object CurrentView
        {
            get
            {
                return this.currentView;
            }

            private set
            {
                if (this.currentView != value)
                {
                    this.currentView = value;
                    this.RaisePropertyChangedEvent(nameof(this.CurrentView));
                }
            }
        }

        /// <summary>
        /// Change the main view
        /// </summary>
        /// <param name="newViewMessage">the new view to display</param>
        private void ChangeView(MainViewMessage newViewMessage)
        {
            switch (newViewMessage.View)
            {
                case MainViews.Configuration:
                    this.CurrentView = this.configurationViewModel;
                    break;

                case MainViews.Consistency:
                    this.CurrentView = this.consistencyViewModel;
                    break;

                case MainViews.DataEntry:
                    this.CurrentView = this.dataEntryViewModel;
                    break;

                default:
                    this.CurrentView = this.configurationViewModel;
                    break;
            } 
        }
    }
}