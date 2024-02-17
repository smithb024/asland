namespace Asland.Interfaces.ViewModels.Body.Analysis.Location
{
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
        /// Sets a new location for which to display a new set of summary data.
        /// </summary>
        /// <param name="name">The name of the new location</param>
        void SetNewLocation(string name);
    }
}