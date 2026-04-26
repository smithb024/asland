namespace Asland.Interfaces.ViewModels.Body.Analysis.Common
{
    using Asland.Interfaces.ViewModels.Body.Common;

    /// <summary>
    /// This interface presents analysis information for a location.
    /// </summary>
    public interface ILocationAnalysisIconViewModel
    {
        /// <summary>
        /// Gets the name of the location.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets the total number of times this location has been counted.
        /// </summary>
        int Count { get; }

        /// <summary>
        /// Count the location.
        /// </summary>
        void CountLocation();
    }
}