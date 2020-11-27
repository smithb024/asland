namespace Asland.Interfaces.Model.IO.DataEntry
{
    /// <summary>
    /// Interface for the model class which manages the event entry process.
    /// </summary>
    public interface IEventEntry
    {
        /// <summary>
        /// Save the current model.
        /// </summary>
        void Save();

        /// <summary>
        /// Load a model to edit.
        /// </summary>
        void Load();

        /// <summary>
        /// Clear the existing model and reset to default.
        /// </summary>
        void Clear();
    }
}
