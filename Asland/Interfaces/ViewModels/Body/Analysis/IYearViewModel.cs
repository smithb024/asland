namespace Asland.Interfaces.ViewModels.Body.Analysis
{
    using Asland.Interfaces.ViewModels.Body.Analysis.Year;
    using System.Collections.ObjectModel;

    /// <summary>
    /// Interface which supports the year view on the analysis tab.
    /// </summary>
    public interface IYearViewModel
    {
        /// <summary>
        /// Gets a collection of years.
        /// </summary>
        ObservableCollection<string> Years { get; }

        /// <summary>
        /// Gets or sets the index of the currently selected year.
        /// </summary>
        int YearIndex { get; set; }

        /// <summary>
        /// Gets the summary for the selected location.
        /// </summary>
        IYearSummaryViewModel Summary { get; }
    }
}