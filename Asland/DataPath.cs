namespace Asland
{
    /// <summary>
    /// Holds the global base path location.
    /// </summary>
    /// <remarks>
    /// Temporary file: this data should be configurable. #58.
    /// </remarks>
    public static class DataPath
    {
        /// <summary>
        /// Gets the location of all raw data files.
        /// </summary>
        public static string BasePath => "C:\\birding";

        /// <summary>
        /// Gets the location of all beastie data files.
        /// </summary>
        public static string BeastieDataPath => $"{BasePath}\\beasties";

        /// <summary>
        /// Gets the location of all raw data files.
        /// </summary>
        public static string RawDataPath => $"{BasePath}\\raw";

        /// <summary>
        /// Gets the location of all image files.
        /// </summary>
        public static string ImageDataPath => $"{BasePath}\\images";
    }
}
