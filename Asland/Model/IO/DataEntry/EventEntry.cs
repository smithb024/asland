namespace Asland.Model.IO.DataEntry
{
    using Asland.Interfaces.Model.IO.DataEntry;
    using Factories.IO;

    /// <summary>
    /// Top class for the model which manages the entry of the events.
    /// </summary>
    public class EventEntry : IEventEntry
    {
        /// <summary>
        /// The current event.
        /// </summary>
        private RawObservations observations;

        /// <summary>
        /// The filename for the current event.
        /// </summary>
        private string filename;

        /// <summary>
        /// Initialises a new instance of the <see cref="EventEntry"/> class.
        /// </summary>
        public EventEntry()
        {
            this.observations = new RawObservations();
        }

        /// <summary>
        /// Save the current model.
        /// </summary>
        public void Save()
        {
            // TODO - Flesh out management of filename.
            XmlFileIo.WriteXml(
                this.observations,
                this.filename);
        }

        /// <summary>
        /// Load a model to edit.
        /// </summary>
        public void Load()
        {
        }

        /// <summary>
        /// Clear the existing model and reset to default.
        /// </summary>
        public void Clear()
        {
        }
    }
}