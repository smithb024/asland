namespace Asland.Model.IO.Data
{
    using System.Collections.Generic;
    using Interfaces.Model.IO.Data;

    /// <summary>
    /// Class which manages the IO of the Data classes.
    /// </summary>
    public class DataManager : IDataManager
    {
        /// <summary>
        /// Collection of all know beasties.
        /// </summary>
        private List<Beastie> beasties;

        /// <summary>
        /// Initialises a new instance of the <see cref="DataManager"/> class.
        /// </summary>
        public DataManager()
        {
            this.beasties = new List<Beastie>();
        }

        /// <summary>
        /// Gets all the beasties in the system.
        /// </summary>
        public List<Beastie> Beasties => this.beasties;

        /// <summary>
        /// Add a beastie to the collection.
        /// </summary>
        /// <param name="newBeastie">beastie to add</param>
        public void AddBeastie(Beastie newBeastie)
        {
            if (this.beasties.Find(b => string.Equals(b.Name, newBeastie.Name)) == null)
            {
                this.beasties.Add(newBeastie);
            }
        }

        /// <summary>
        /// Reset the data in the data manager.
        /// </summary>
        public void Reset()
        {
            this.beasties = new List<Beastie>();
        }
    }
}