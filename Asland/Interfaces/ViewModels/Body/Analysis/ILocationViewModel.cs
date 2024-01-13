using System.Collections.ObjectModel;

namespace Asland.Interfaces.ViewModels.Body.Analysis
{
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
    }
}