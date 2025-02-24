namespace Asland.ViewModels.Body.Analysis
{
    using Asland.Interfaces;
    using Asland.Interfaces.Common.Utils;
    using Asland.Interfaces.Factories;
    using Asland.Interfaces.Model.IO.Data;
    using Asland.Interfaces.ViewModels.Body.Analysis;
    using Asland.Interfaces.ViewModels.Body.Analysis.Year;
    using Asland.ViewModels.Body.Analysis.Year;
    using NynaeveLib.ViewModel;
    using System.Collections.ObjectModel;

    /// <summary>
    /// View Model which supports the year view on the analysis tab.
    /// </summary>
    public class YearViewModel : ViewModelBase, IYearViewModel
    {
        /// <summary>
        /// The year searcher.
        /// </summary>
        private readonly IYearSearcher yearSearcher;

        /// <summary>
        /// The index of the currently selected year.
        /// </summary>
        private int selectedYearIndex;

        /// <summary>
        /// Initialises a new instance of the <see cref="YearViewModel"/> class.
        /// </summary>
        /// <param name="search">The search factory</param>
        /// <param name="yearSearcher">the year searcher</param>
        /// <param name="pathManager">the path manager</param>
        /// <param name="dataModel">The data model</param>
        public YearViewModel(
            ITimeSearchFactory search,
            IYearSearcher yearSearcher,
            IPathManager pathManager,
            IDataManager dataModel) 
        {
            this.Summary =
                new YearSummaryViewModel(
                    search,
                    pathManager,
                    dataModel.FindBeastie);

            this.Years = yearSearcher.FindRawYears();
            this.selectedYearIndex = this.Years.Count - 1;
            this.Summary.SetNewYear(
                    this.Years[this.YearIndex]);
        }

        /// <summary>
        /// Gets a collection of years.
        /// </summary>
        public ObservableCollection<string> Years { get; }

        /// <summary>
        /// Gets or sets the index of the currently selected year.
        /// </summary>
        public int YearIndex
        {
            get => this.selectedYearIndex;
            set
            {
                if (this.selectedYearIndex == value)
                {
                    return;
                }

                this.selectedYearIndex = value;
                this.OnPropertyChanged(nameof(this.YearIndex));

                this.Summary.SetNewYear(
                    this.Years[this.YearIndex]);
            }
        }

        /// <summary>
        /// Gets the summary for the selected location.
        /// </summary>
        public IYearSummaryViewModel Summary { get; }
    }
}