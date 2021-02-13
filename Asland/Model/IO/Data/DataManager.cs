namespace Asland.Model.IO.Data
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using Factories.IO;
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

        }
    }
}