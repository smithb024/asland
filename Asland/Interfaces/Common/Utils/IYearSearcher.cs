namespace Asland.Interfaces.Common.Utils
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    /// <summary>
    /// Interfaces for a searcher class used to manage searches corresponding to the year.
    /// </summary>
    public interface IYearSearcher
    {
        /// <summary>
        /// Get a collection of all years which have data assigned to them.
        /// </summary>
        /// <returns>raw years</returns>
        ObservableCollection<string> FindRawYears();

        /// <summary>
        /// Return the paths to all the events in a specific month.
        /// </summary>
        /// <param name="year">the year to search for</param>
        /// <param name="month">the month to search for</param>
        /// <returns>collection of paths</returns>
        List<string> FindAllRawObservationsInAMonth(
            string year,
            int month);

        /// <summary>
        /// Returns the paths to all the raw event data in a specific year.  
        /// </summary>
        /// <param name="year">the year to search for</param>
        /// <returns>All events in a year</returns>
        List<string> FindAllRawObservationsInAYear(string year);
    }
}