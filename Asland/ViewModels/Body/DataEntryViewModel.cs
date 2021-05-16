namespace Asland.ViewModels.Body
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    using System.Windows.Input;
    using Asland.Common.Enums;
    using Asland.Interfaces.Model.IO.DataEntry;
    using Asland.Interfaces.ViewModels.Body;
    using Asland.Interfaces.ViewModels.Body.DataEntry;
    using Asland.Model.IO.Data;
    using Asland.ViewModels.Body.DataEntry;
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
        /// Function used to retrieve a specific beastie from the model.
        /// </summary>
        private readonly Func<string, Beastie> getBeastie;

        /// <summary>
        /// Associated data entry model.
        /// </summary>
        private IEventEntry dataEntryModel;

        /// <summary>
        /// Is the current model being edited.
        /// </summary>
        private bool isEditing;

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
        /// <param name="getBeastie">
        /// The function used to return a specific beastie from the data model.
        /// </param>
        public DataEntryViewModel(
            IEventEntry model,
            Func<string, Beastie> getBeastie)
        {
            bool isSeen = true;
            this.dataEntryModel = model;
            this.getBeastie = getBeastie;
            this.observations = model.Observations;
            this.beastieEntryViewModel =
                new BeastieEntryViewModel(
                    this.observations.SetBeastie,
                    isSeen);
            this.detailsViewModel = 
                new EventDetailsEntryViewModel(
                    this.observations,
                    isSeen,
                    this.beastieEntryViewModel.SetIsSeen);

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
        /// Gets a value which indicates whether the current event is being edited.
        /// </summary>
        public bool IsEditing
        {
            get
            {
                return this.isEditing;
            }

            set
            {
                if (this.isEditing != value)
                {
                    this.isEditing = value;
                    this.RaisePropertyChangedEvent(nameof(this.IsEditing));
                    this.RaisePropertyChangedEvent(nameof(this.EditingText));
                }
            }
        }

        /// <summary>
        /// Gets a string which describes the editing status.
        /// </summary>
        public string EditingText => isEditing ? "Editing" : string.Empty;

        /// <summary>
        /// Save the current event.
        /// </summary>
        private void Save()
        {
            bool success = this.dataEntryModel.Save();

            if (success)
            {
                this.Reset();
            }
        }

        /// <summary>
        /// Load a new event to edit.
        /// </summary>
        private void Load()
        {
            OpenFileDialog dialog = new OpenFileDialog();


            dialog.InitialDirectory = DataPath.RawDataPath;
            dialog.Filter = "xml files (*.xml)|*.xml";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                this.dataEntryModel.Load(dialog.FileName);
            }

            this.NewPage(DataEntryViewModel.EventDetails);
            this.IsEditing = true;
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
                    this.dataEntryModel.GetBeastiesOnAPage(
                        newPageName);

                foreach(string beastie in beasties)
                {
                    bool isIncluded =
                        this.observations.GetIncluded(
                            beastie,
                            this.detailsViewModel.IsSeen);

                    Beastie modelBeastie = this.getBeastie(beastie);

                    this.beastieEntryViewModel.Add(
                        beastie,
                        modelBeastie?.LatinName ?? string.Empty,
                        modelBeastie?.Image ?? string.Empty,
                        modelBeastie?.Presence ?? (Presence)(-1),
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

        /// <summary>
        /// Reset the view models.
        /// </summary>
        private void Reset()
        {
            bool isSeen = true;
            this.observations = dataEntryModel.Observations;
            this.beastieEntryViewModel =
                new BeastieEntryViewModel(
                    this.observations.SetBeastie,
                    isSeen);

            this.detailsViewModel?.Dispose();

            this.detailsViewModel =
                new EventDetailsEntryViewModel(
                    this.observations,
                    isSeen,
                    this.beastieEntryViewModel.SetIsSeen);

            this.CurrentWorkspace = this.detailsViewModel;
            this.IsEditing = false;
            this.RaisePropertyChangedEvent(nameof(this.CurrentWorkspace));
        }
    }
}