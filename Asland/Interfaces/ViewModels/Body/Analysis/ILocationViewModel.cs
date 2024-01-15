namespace Asland.Interfaces.ViewModels.Body.Analysis
{
    using System.Collections.ObjectModel;

    /// <summary>
    /// Interface which supports the beastie view on the analysis tab.
    /// </summary>
    public interface ILocationViewModel
    {
        /// <summary>
        /// Gets a collection of locations.
        /// </summary>
        ObservableCollection<string> Locations { get; }

        /// <summary>
        /// Gets or sets the index of the currently selected location.
        /// </summary>
        int LocationIndex { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to just show NT locations.
        /// </summary>
        bool IsNt { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to just show WT locations.
        /// </summary>
        bool IsWt { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to just show WWT locations.
        /// </summary>
        bool IsWwt { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to just show RSPB locations.
        /// </summary>
        bool IsRspb { get; set; }
    }
}