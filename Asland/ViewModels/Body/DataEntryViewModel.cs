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

            this.PageSelector = new List<IIndexCommand<string>>();

            IIndexCommand<string> showEventDetails =
                new IndexCommand<string>(
                    EventDetails,
                    this.NewPage);

            this.PageSelector.Add(showEventDetails);

            IIndexCommand<string> testCommand1 = new IndexCommand<string>("1", this.NewPage);
            IIndexCommand<string> testCommand2 = new IndexCommand<string>("2", this.NewPage);
            IIndexCommand<string> testCommand3 = new IndexCommand<string>("3", this.NewPage);
            IIndexCommand<string> testCommand4 = new IndexCommand<string>("4", this.NewPage);
            IIndexCommand<string> testCommand5 = new IndexCommand<string>("5", this.NewPage);
            IIndexCommand<string> testCommand6 = new IndexCommand<string>("6", this.NewPage);
            IIndexCommand<string> testCommand7 = new IndexCommand<string>("7", this.NewPage);
            IIndexCommand<string> testCommand8 = new IndexCommand<string>("8", this.NewPage);

            this.PageSelector.Add(testCommand1);
            this.PageSelector.Add(testCommand2);
            this.PageSelector.Add(testCommand3);
            this.PageSelector.Add(testCommand4);
            this.PageSelector.Add(testCommand5);
            this.PageSelector.Add(testCommand6);
            this.PageSelector.Add(testCommand7);
            this.PageSelector.Add(testCommand8);

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
        public List<IIndexCommand<string>> PageSelector { get; }

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

        private void NewPage(string newPageName)
        {
            if (StringCompare.SimpleCompare(newPageName, EventDetails))
            {
                this.CurrentWorkspace = this.detailsViewModel;
            }
            else
            {
                this.CurrentWorkspace = this.beastieEntryViewModel;
            }

            this.RaisePropertyChangedEvent(nameof(this.CurrentWorkspace));
        }
    }
}