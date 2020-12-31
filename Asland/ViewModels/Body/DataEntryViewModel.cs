namespace Asland.ViewModels.Body
{
    using System.Collections.Generic;
    using System.Windows.Input;
    using Asland.ViewModels.Body.DataEntry;
    using Asland.Interfaces.Model.IO.DataEntry;
    using Asland.Interfaces.ViewModels.Body;
    using Asland.Interfaces.ViewModels.Body.DataEntry;
    using NynaeveLib.Commands;
    using NynaeveLib.Utils;
    using NynaeveLib.ViewModel;

    /// <summary>
    /// View model which suports the data entry view.
    /// This manages all aspects of the data entry process including the different sub views.
    /// </summary>
    public class DataEntryViewModel : ViewModelBase, IDataEntryViewModel
    {
        /// <summary>
        /// String used for the event details button. This button is used to select the page where
        /// the user enters the general information about the event.
        /// </summary>
        private const string EventDetails = "Event Details";

        /// <summary>
        /// Associated model.
        /// </summary>
        private IEventEntry model;

        /// <summary>
        /// Manager which handles observation data entry/interrogation.
        /// </summary>
        private IObservationManager observations;

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
            bool isSeen = true;
            this.model = model;
            this.observations = model.Observations;
            this.beastieEntryViewModel =
                new BeastieEntryViewModel(
                    this.observations.SetBeastie,
                    isSeen);
            this.detailsViewModel = 
                new EventDetailsEntryViewModel(
                    isSeen);

            this.CurrentWorkspace = this.detailsViewModel;

            this.PopulatePageSelector(EventDetails);

            List<string> beastiePages = model.GetDataEntryPageNames();

            foreach (string pageName in beastiePages)
            {
                this.PopulatePageSelector(pageName);
            }

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
        /// Gets a selection of commands which are used to choose a page to display.
        /// </summary>
        public List<IIndexCommand<string>> PageSelector { get; private set; }

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

        /// <summary>
        /// Select a new page for the view.
        /// </summary>
        /// <param name="newPageName">
        /// Name of the page to display.
        /// </param>
        private void NewPage(string newPageName)
        {
            if (StringCompare.SimpleCompare(newPageName, EventDetails))
            {
                this.CurrentWorkspace = this.detailsViewModel;
            }
            else
            {
                this.beastieEntryViewModel.Clear();

                List<string> beasties =
                    this.model.GetBeastiesOnAPage(
                        newPageName);

                foreach(string beastie in beasties)
                {
                    bool isIncluded =
                        this.observations.GetIncluded(
                            beastie,
                            this.detailsViewModel.IsSeen);
                    this.beastieEntryViewModel.Add(
                        beastie,
                        isIncluded);
                }

                this.CurrentWorkspace = this.beastieEntryViewModel;
                this.beastieEntryViewModel.Refresh();
            }

            this.RaisePropertyChangedEvent(nameof(this.CurrentWorkspace));
        }

        /// <summary>
        /// Add a new command to the collection of page selector commands.
        /// </summary>
        /// <param name="pageName">
        /// Name of the page the new command represents.
        /// </param>
        private void PopulatePageSelector(string pageName)
        {
            if (this.PageSelector == null)
            {
                this.PageSelector = new List<IIndexCommand<string>>();
            }

            IIndexCommand<string> showEventDetails =
                new IndexCommand<string>(
                    pageName,
                    this.NewPage);

            this.PageSelector.Add(showEventDetails);
        }
    }
}