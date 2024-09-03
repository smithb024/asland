namespace Asland.ViewModels.Body
{
    using Asland.Common.Enums;
    using Asland.Common.Messages;
    using Asland.Interfaces;
    using Asland.Interfaces.Common.Utils;
    using Asland.Interfaces.Factories;
    using Asland.Interfaces.Model.IO.Data;
    using Asland.Interfaces.Model.IO.DataEntry;
    using Asland.Interfaces.ViewModels.Body;
    using NynaeveLib.ViewModel;
    using CommonMessenger = NynaeveLib.Messenger.Messenger;

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
        /// The reports view model.
        /// </summary>
        private IReportsViewModel reportsViewModel;

        /// <summary>
        /// The analysis view model.
        /// </summary>
        private IAnalysisViewModel analysisViewModel;

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
        /// <param name="dataModel">
        /// The model object containing data set. 
        /// </param>
        /// <param name="fileFactory">beastie file factory</param>
        /// <param name="logger">the logger</param>
        /// <param name="locationSearch">the location search factory</param>
        /// <param name="pathManager">the path manager</param>
        /// <param name="yearSearcher">the year searcher</param>
        public BodyViewModel(
            IEventEntry dataEntryModel,
            IDataManager dataModel,
            IBeastieDataFileFactory fileFactory,
            IAsLogger logger,
            ILocationSearchFactory locationSearch,
            IPathManager pathManager,
            IYearSearcher yearSearcher)
        {
            this.configurationViewModel = 
                new ConfigurationViewModel(
                    dataModel,
                    fileFactory,
                    pathManager);
            this.consistencyViewModel = 
                new ConsistencyViewModel(
                    pathManager);
            this.reportsViewModel =
                new ReportsViewModel(
                    pathManager,
                    yearSearcher,
                    dataModel,
                    logger);
            this.dataEntryViewModel =
                new DataEntryViewModel(
                    pathManager,
                    dataEntryModel,
                    dataModel.FindBeastie);
            this.analysisViewModel =
                new AnalysisViewModel(
                    locationSearch,
                    pathManager,
                    dataModel);

            this.currentView = this.dataEntryViewModel;

            CommonMessenger.Default.Register<MainViewMessage>(this, this.ChangeView);
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
                    this.OnPropertyChanged(nameof(this.CurrentView));
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

                case MainViews.Reports:
                    this.CurrentView = this.reportsViewModel;
                    break;

                case MainViews.Analysis:
                    this.CurrentView = this.analysisViewModel;
                    break;

                default:
                    this.CurrentView = this.dataEntryViewModel;
                    break;
            } 
        }
    }
}