﻿namespace Asland.ViewModels.Body
{
    using Asland.Interfaces.ViewModels.Body;
    using Asland.Interfaces.ViewModels.Body.Analysis;
    using Asland.Interfaces.ViewModels.Common;
    using Asland.ViewModels.Body.Analysis;
    using Common;
    using NynaeveLib.Utils;
    using NynaeveLib.ViewModel;
    using System.Collections.Generic;

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
        /// View model for the beasties.
        /// </summary>
        private IBeastieViewModel beastieViewModel;

        /// <summary>
        /// View model for the locations.
        /// </summary>
        private ILocationViewModel locationViewModel;

        /// <summary>
        /// Initialises a new instance of the <see cref="AnalysisViewModel"/> class.
        /// </summary>
        public AnalysisViewModel()
        {
            this.PageSelector = new List<IPageSelector>();
            this.beastieViewModel =
                new BeastieViewModel(
                    );
            this.locationViewModel =
                new LocationViewModel(
                    );

            IPageSelector beastieSelector =
                new PageSelector(
                    AnalysisViewModel.BeastieSelector,
                    this.NewPage);
            IPageSelector locationSelector =
                new PageSelector(
                    AnalysisViewModel.LocationSelector,
                    this.NewPage);

            this.PageSelector.Add(beastieSelector);
            this.PageSelector.Add(locationSelector);

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

            this.ResetSelectedPage(newPageName);

            this.RaisePropertyChangedEvent(nameof(this.CurrentWorkspace));
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