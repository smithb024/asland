namespace Asland.Interfaces.ViewModels.Body.Analysis.Common
{
    using Asland.Common.Enums;

    /// <summary>
    /// This interface counts a single habitat.
    /// </summary>
    public interface IHabitatCounterViewModel
    {
        /// <summary>
        /// Gets the <see cref="ObservationHabitat"/> which is the subject of this view model.
        /// </summary>
        ObservationHabitat Name { get; }

        /// <summary>
        /// Gets the <see cref="Name"/> as a string.
        /// </summary>
        string Description { get; }

        /// <summary>
        /// Gets the total number of occurances of <see cref="Name"/>.
        /// </summary>
        int Count { get; }

        /// <summary>
        /// Add one to the <see cref="Count"/>.
        /// </summary>
        void CountHabitat();
    }
}