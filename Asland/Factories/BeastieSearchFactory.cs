namespace Asland.Factories
{
    using System.Collections.Generic;
    using Asland.Interfaces.Factories;
    using Asland.Interfaces.Model.IO.Data;
    using Asland.Model.IO.Data;

    /// <summary>
    /// The object with manages search access to the beasties. 
    /// </summary>
    public class BeastieSearchFactory : IBeastieSearchFactory
    {
        /// <summary>
        ///  The data manager.
        /// </summary>
        private IDataManager dataManager;

        /// <summary>
        /// Initialises a new instance of the <see cref="BeastieDataFileFactory"/> class.
        /// </summary>
        /// <param name="dataManager">The data manager</param>
        public BeastieSearchFactory(
            IDataManager dataManager)
        {
            this.dataManager = dataManager;
        }

        /// <summary>
        /// Get a list of all known beasties.
        /// </summary>
        /// <returns>beastie names</returns>
        public Dictionary<string, string> FindAllNames()
        {
            Dictionary<string, string> names = 
                new Dictionary<string, string>();

            foreach (Beastie beastie in this.dataManager.Beasties)
            {
                names.Add(
                    beastie.Name, 
                    beastie.DisplayName);
            }

            return names;
        }

        /// <summary>
        /// Find and return a specific beastie
        /// </summary>
        /// <param name="name">name to search for</param>
        /// <returns>found beastie</returns>
        public Beastie Find(string name)
        {
            Beastie foundBeastie =
                this.dataManager.Beasties.Find(
                    b => string.Compare(b.Name, name) == 0);

            return foundBeastie;
        }
    }
}
