namespace Asland
{
    /// <summary>
    /// Holds the global base path location.
    /// </summary>
    /// <remarks>
    /// Temporary file: this data should be configurable. This will be done later.
    /// </remarks>
    public static class DataPath
    {
        /// <summary>
        /// Gets the location of all raw data files.
        /// </summary>
        public static string BasePath => "C:\\birding";

        /// <summary>
        /// Gest the location of all beastie data files.
        /// </summary>
        public static string BeastieDataPath => $"{BasePath}\\beasties";

        /// <summary>
        /// Gest the location of all raw data files.
        /// </summary>
        public static string RawDataPath => $"{BasePath}\\raw";
    }
}
