namespace Asland.ViewModels.Body
{
    using Asland.ViewModels.Body.DataEntry;
    using Asland.Interfaces.ViewModels.Body;
    using Asland.Interfaces.ViewModels.Body.DataEntry;
    using NynaeveLib.ViewModel;

    /// <summary>
    /// View model which suports the data entry view.
    /// This manages all aspects of the data entry process including the different sub views.
    /// </summary>
    public class DataEntryViewModel : ViewModelBase, IDataEntryViewModel
    {
        /// <summary>
        /// View model for the beastie entry view.
        /// </summary>
        private IBeastieEntry beastieEntryViewModel;

        /// <summary>
        /// View model for the event details entry view.
        /// </summary>
        private IEventDetailsEntry detailsViewModel;

        /// <summary>
        /// Initialises a new instance of the <see cref="DataEntryViewModel"/> class.
        /// </summary>
        public DataEntryViewModel()
        {
            this.beastieEntryViewModel = new BeastieEntryViewModel();
            this.detailsViewModel = new EventDetailsEntryViewModel();
        }

        /// <summary>
        /// Gets the view model for the workspace which is displayed.
        /// </summary>
        public object CurrentWorkspace { get; private set; }
    }
}