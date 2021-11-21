namespace Asland.Common.Utils
{
    using System.Collections.ObjectModel;
    using System.IO;

    /// <summary>
    /// Searcher class used to manage searches corresponding to the year.
    /// </summary>
    public static class YearSearcher
    {
        /// <summary>
        /// Get a collection of all years which have data assigned to them.
        /// </summary>
        /// <returns>raw years</returns>
        public static ObservableCollection<string> FindRawYears()
        {
            string[] years =
                Directory.GetDirectories(
                    DataPath.RawDataPath);

            ObservableCollection<string> yearDirectories = new ObservableCollection<string>();

            foreach(string year in years)
            {
                yearDirectories.Add(Path.GetFileName(year));
            }

            return yearDirectories;
        }
    }
}