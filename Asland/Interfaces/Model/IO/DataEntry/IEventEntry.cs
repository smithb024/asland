namespace Asland.Interfaces.Model.IO.DataEntry
{
    using System.Collections.Generic;

    /// <summary>
    /// Interface for the model class which manages the event entry process.
    /// </summary>
    public interface IEventEntry
    {
        /// <summary>
        /// Gets the manager class for the current observations.
        /// </summary>
        IObservationManager Observations { get; }

        /// <summary>
        /// Save the current model.
        /// </summary>
        /// <returns>success flag</returns>
        bool Save();

        /// <summary>
        /// Load a model to edit.
        /// </summary>
        void Load();

        /// <summary>
        /// Clear the existing model and reset to default.
        /// </summary>
        void Clear();

        /// <summary>
        /// Gets a list of all the pages defined in the configuration file.
        /// </summary>
        /// <returns>Predefined page names</returns>
        List<string> GetDataEntryPageNames();

        /// <summary>
        /// Gets a list of all the beastie on a specific page, as defined by the configuration 
        /// file.
        /// </summary>
        /// <param name="pageName">
        /// Name of the page to search for.
        /// </param>
        /// <returns>
        /// Predefined beastie name.
        /// </returns>
        List<string> GetBeastiesOnAPage(string pageName);
    }
}
