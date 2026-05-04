namespace Asland.Interfaces.ViewModels.Body.Analysis
{
    using Asland.Interfaces.ViewModels.Body.Analysis.Beasties;
    using System.Collections.ObjectModel;

    /// <summary>
    /// Interface which supports the beastie view on the analysis tab.
    /// </summary>
    public interface IBeastieViewModel
    {
        /// <summary>
        /// Gets a collection of beastie.
        /// </summary>
        ObservableCollection<string> Beasties { get; }

        /// <summary>
        /// Gets or sets the index of the currently selected beastie.
        /// </summary>
        int BeastieIndex { get; set; }

        /// <summary>
        /// Gets the summary for the selected beastie.
        /// </summary>
        IBeastieSummaryViewModel Summary { get; }
    }
}