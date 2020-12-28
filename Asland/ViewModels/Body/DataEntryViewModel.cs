namespace Asland.ViewModels.Body
{
    using System.Windows.Input;
    using Asland.Common.Enums;
    using Asland.ViewModels.Body.DataEntry;
    using Asland.Interfaces.Model.IO.DataEntry;
    using Asland.Interfaces.ViewModels.Body;
    using Asland.Interfaces.ViewModels.Body.DataEntry;
    using Interfaces.ViewModels.Common;
    using NynaeveLib.Commands;
    using NynaeveLib.ViewModel;
    using Asland.ViewModels.Common;

    /// <summary>
    /// View model which suports the data entry view.
    /// This manages all aspects of the data entry process including the different sub views.
    /// </summary>
    public class DataEntryViewModel : ViewModelBase, IDataEntryViewModel
    {
        /// <summary>
        /// Associated model.
        /// </summary>
        public IEventEntry model;

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
        /// <param name="model">
        ///  The associated model object.
        /// </param>
        public DataEntryViewModel(
            IEventEntry model)
        {
            this.model = model;
            this.beastieEntryViewModel = new BeastieEntryViewModel();
            this.detailsViewModel = new EventDetailsEntryViewModel();

            this.CurrentWorkspace = this.detailsViewModel;

            this.SaveCommand =
                new CommonCommand(
                    this.Save);
            this.LoadCommand =
                new CommonCommand(
                    this.Load);
        }

        /// <summary>
        /// Gets the view model for the workspace which is displayed.
        /// </summary>
        public object CurrentWorkspace { get; private set; }

        /// <summary>
        /// Command used to save the current event.
        /// </summary>
        public ICommand SaveCommand { get; }

        /// <summary>
        /// Command used to load an existing event.
        /// </summary>
        public ICommand LoadCommand { get; }

        /// <summary>
        /// Save the current event.
        /// </summary>
        private void Save()
        {
            this.model.Save();
        }

        /// <summary>
        /// Load a new event to edit.
        /// </summary>
        private void Load()
        {
            this.model.Load();
        }
    }
}