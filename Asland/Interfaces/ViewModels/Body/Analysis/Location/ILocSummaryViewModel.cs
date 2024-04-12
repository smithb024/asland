namespace Asland.Interfaces.ViewModels.Body.Analysis.Location
{
    using Asland.Interfaces.ViewModels.Body.Analysis.Common;
    using Asland.Interfaces.ViewModels.Body.Reports;
    using System.Collections.ObjectModel;

    /// <summary>
    /// Interface which supports the summary view on the location analysis page.
    /// </summary>
    public interface ILocSummaryViewModel
    {
        /// <summary>
        /// Gets the name of the current location.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets the number of times the location has been visited.
        /// </summary>
        int Count { get; }

        /// <summary>
        /// Gets the beasties present in the analysis.
        /// </summary>
        ObservableCollection<IBeastieAnalysisIconViewModel> Beasties { get; }

        /// <summary>
        /// Gets the dates of visits to the location.
        /// </summary>
        ObservableCollection<string> Dates { get; }

        /// <summary>
        /// Sets a new location for which to display a new set of summary data.
        /// </summary>
        /// <param name="name">The name of the new location</param>
        void SetNewLocation(string name);
    }
}