namespace Asland.Interfaces
{
    /// <summary>
    /// Interface for the manager which manages the path data.
    /// </summary>
    public interface IPathManager
    {
        /// <summary>
        /// Gets the base path.
        /// </summary>
        string BasePath { get; }

        /// <summary>
        /// Gets the location of all beastie data files.
        /// </summary>
        string BeastieDataPath { get; }

        /// <summary>
        /// Gets the location of all raw data files.
        /// </summary>
        string RawDataPath { get; }

        /// <summary>
        /// Gets the location of all image files.
        /// </summary>
        string ImageDataPath { get; }

        /// <summary>
        /// Gets the location of the index file.
        /// </summary>
        string IndexPath { get; }
    }
}