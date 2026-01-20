using Asland.Common.Enums;
using Asland.Interfaces.ViewModels.Body.Analysis.Common;
using System.Collections.ObjectModel;

namespace Asland.Interfaces.ViewModels.Body.Analysis.Beasties
{
    /// <summary>
    /// Interface which supports the summary view on the beastie analysis page.
    /// </summary>
    public interface IBeastieSummaryViewModel
    {
        /// <summary>
        /// Gets the name of the current beastie.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets the intensities present in the analysis.
        /// </summary>
        ObservableCollection<IEnumCounterViewModel<ObservationIntensity>> Intensities { get; }

        /// <summary>
        /// Gets the habitats present in the analysis.
        /// </summary>
        ObservableCollection<IEnumCounterViewModel<ObservationHabitat>> Habitats { get; }

        /// <summary>
        /// Sets a new beastie for which to display a new set of summary data.
        /// </summary>
        /// <param name="name">The name of the new beastie</param>
        void SetNewBeastie(string name);
    }
}
