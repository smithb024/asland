namespace Asland.Interfaces.ViewModels.Body.Analysis
{
    using Asland.Interfaces.ViewModels.Body.Analysis.Year;

    /// <summary>
    /// Interface which supports the year view on the analysis tab.
    /// </summary>
    public interface IYearViewModel
    {
        /// <summary>
        /// Gets the summary for the selected location.
        /// </summary>
        IYearSummaryViewModel Summary { get; }
    }
}