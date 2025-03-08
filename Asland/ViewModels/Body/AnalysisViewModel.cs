namespace Asland.ViewModels.Body
{
    using Asland.ViewModels.Common;
    using Asland.Interfaces.Factories;
    using Asland.Interfaces.ViewModels.Body;
    using Asland.Interfaces.ViewModels.Body.Analysis;
    using Asland.Interfaces.ViewModels.Common;
    using Asland.ViewModels.Body.Analysis;
    using NynaeveLib.Utils;
    using NynaeveLib.ViewModel;
    using System.Collections.Generic;
    using Asland.Interfaces;
    using Asland.Interfaces.Model.IO.Data;
    using Asland.Interfaces.Common.Utils;

    /// <summary>
    /// View model which suports the analysis view.
    /// This manages all aspects of the analysis process including the different sub views.
    /// </summary>
    public class AnalysisViewModel : ViewModelBase, IAnalysisViewModel
    {
        /// <summary>
        /// String used for the Beastie button.
        /// </summary>
        private const string BeastieSelector = "Beastie";

        /// <summary>
        /// String used for the Location button.
        /// </summary>
        private const string LocationSelector = "Location";

        /// <summary>
        /// String used for the Year button.
        /// </summary>
        private const string YearSelector = "Year";

        /// <summary>
        /// View model for the beasties.
        /// </summary>
        private IBeastieViewModel beastieViewModel;

        /// <summary>
        /// View model for the locations.
        /// </summary>
        private ILocationViewModel locationViewModel;

        /// <summary>
        /// View model for the years.
        /// </summary>
        private IYearViewModel yearViewModel;

        /// <summary>
        /// Initialises a new instance of the <see cref="AnalysisViewModel"/> class.
        /// </summary>
        /// <param name="locationSearch">The location search factory</param>
        /// <param name="timeSearch">The time search factory</param>
        /// <param name="pathManager">the path manager</param>
        /// <param name="dataModel">The data model</param>
        /// <param name="yearSearcher">the year searcher</param>
        public AnalysisViewModel(
            ILocationSearchFactory locationSearch,
            ITimeSearchFactory timeSearch,
            IPathManager pathManager,
            IDataManager dataModel,
            IYearSearcher yearSearcher)
        {
            this.PageSelector = new List<IPageSelector>();
            this.beastieViewModel =
                new BeastieViewModel(
                    );
            this.locationViewModel =
                new LocationViewModel(
                    locationSearch,
                    pathManager,
                    dataModel);
            this.yearViewModel =
                new YearViewModel(
                    timeSearch,
                    yearSearcher,
                    pathManager,
                    dataModel);

            IPageSelector beastieSelector =
                new PageSelector(
                    AnalysisViewModel.BeastieSelector,
                    this.NewPage);
            IPageSelector locationSelector =
                new PageSelector(
                    AnalysisViewModel.LocationSelector,
                    this.NewPage);
            IPageSelector yearSelector =
                new PageSelector(
                    AnalysisViewModel.YearSelector,
                    this.NewPage);

            this.PageSelector.Add(beastieSelector);
            this.PageSelector.Add(locationSelector);
            this.PageSelector.Add(yearSelector);

            this.NewPage(AnalysisViewModel.BeastieSelector);
        }

        /// <summary>
        /// Gets the view model for the workspace which is displayed.
        /// </summary>
        public object CurrentWorkspace { get; private set; }

        /// <summary>
        /// Gets a selection of commands which are used to choose a page to display.
        /// </summary>
        public List<IPageSelector> PageSelector { get; private set; }

        /// <summary>
        /// Select a new page for the view.
        /// </summary>
        /// <param name="newPageName">
        /// Name of the page to display.
        /// </param>
        private void NewPage(string newPageName)
        {
            if (StringCompare.SimpleCompare(newPageName, AnalysisViewModel.BeastieSelector))
            {
                this.CurrentWorkspace = this.beastieViewModel;
            }
            else if (StringCompare.SimpleCompare(newPageName, AnalysisViewModel.LocationSelector))
            {
                this.CurrentWorkspace = this.locationViewModel;
            }
            else if (StringCompare.SimpleCompare(newPageName, AnalysisViewModel.YearSelector))
            {
                this.CurrentWorkspace = this.yearViewModel;
            }

            this.ResetSelectedPage(newPageName);

            this.OnPropertyChanged(nameof(this.CurrentWorkspace));
        }

        /// <summary>
        /// Inform each of the components in the page selector collection of the name of the 
        /// currently selected page.
        /// </summary>
        /// <param name="pageName">page name</param>
        private void ResetSelectedPage(string pageName)
        {
            foreach (IPageSelector pageSelector in this.PageSelector)
            {
                pageSelector.SelectedButton(pageName);
            }
        }
    }
}