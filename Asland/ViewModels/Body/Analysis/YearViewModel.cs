namespace Asland.ViewModels.Body.Analysis
{
    using Asland.Interfaces.ViewModels.Body.Analysis;
    using Asland.Interfaces.ViewModels.Body.Analysis.Year;
    using Asland.ViewModels.Body.Analysis.Year;
    using NynaeveLib.ViewModel;

    /// <summary>
    /// View Model which supports the year view on the analysis tab.
    /// </summary>
    public class YearViewModel : ViewModelBase, IYearViewModel
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="YearViewModel"/> class.
        /// </summary>
        public YearViewModel() 
        {
            this.Summary =
                new YearSummaryViewModel();
        }

        /// <summary>
        /// Gets the summary for the selected location.
        /// </summary>
        public IYearSummaryViewModel Summary { get; }
    }
}