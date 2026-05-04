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
        /// Gets the total number of times this location has been assessed.
        /// </summary>
        int Total { get; }

        /// <summary>
        /// Gets the totla number of times this location has been counted as a percentage of the
        /// number of times it has been assessed. 
        /// </summary>
        double Percentage { get; }

        /// <summary>
        /// Gets the <see cref="Percentage"/> as a string.
        /// </summary>
        string PercentageString { get; }

        /// <summary>
        /// Count the location.
        /// </summary>
        void CountLocation();

        /// <summary>
        /// Set the total number of times this location has been visited.
        /// </summary>
        /// <param name="total">The total number of times.</param>
        void SetTotal(int total);
    }
}