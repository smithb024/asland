namespace Asland.Common.Utils
{
    using Asland.Interfaces;
    using Asland.Interfaces.Common.Utils;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.IO;
    using System.Linq;

    /// <summary>
    /// Searcher class used to manage searches corresponding to the year.
    /// </summary>
    public class YearSearcher : IYearSearcher
    {
        /// <summary>
        /// The path manager.
        /// </summary>
        private readonly IPathManager pathManager;

        /// <summary>
        /// Initialises a new instance of the <see cref="YearSearcher"/> class.
        /// </summary>
        /// <param name="pathManager">The path manager</param>
        public YearSearcher(
            IPathManager pathManager)
        {
            this.pathManager = pathManager;
        }

        /// <summary>
        /// Get a collection of all years which have data assigned to them.
        /// </summary>
        /// <returns>raw years</returns>
        public ObservableCollection<string> FindRawYears()
        {
            string[] years =
                Directory.GetDirectories(
                    this.pathManager.RawDataPath);

            ObservableCollection<string> yearDirectories = new ObservableCollection<string>();

            foreach(string year in years)
            {
                yearDirectories.Add(Path.GetFileName(year));
            }

            return yearDirectories;
        }

        /// <summary>
        /// Return the paths to all the events in a specific month.
        /// </summary>
        /// <param name="year">the year to search for</param>
        /// <param name="month">the month to search for</param>
        /// <returns>collection of paths</returns>
        public List<string> FindAllRawObservationsInAMonth(
            string year,
            int month)
        {
            List<string> paths = new List<string>();
            List<string> eventsInAYear =
                this.FindAllRawObservationsInAYear(
                    year);
            string searchString =
                $"{year.Substring(2)}{month.ToString("00")}";

            foreach (string path in eventsInAYear)
            {
                string filename = Path.GetFileName(path);
                string fileSubString = filename.Substring(0, 4);

                if (string.Equals(fileSubString, searchString))
                {
                    paths.Add(path);
                }
            }

            return paths;
        }

        /// <summary>
        /// Returns the paths to all the raw event data in a specific year.  
        /// </summary>
        /// <param name="year">the year to search for</param>
        /// <returns>All events in a year</returns>
        public List<string> FindAllRawObservationsInAYear(string year)
        {
            string path = $"{this.pathManager.RawDataPath}\\{year}";

            List<string> events =
                Directory.GetFiles(
                    path).ToList();

            return events;
        }
    }
}