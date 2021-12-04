﻿namespace Asland.ViewModels.Body.Reports
{
    using NynaeveLib.ViewModel;
    using Asland.Common.Enums;
    using Asland.Interfaces.ViewModels.Body.Reports;

    /// <summary>
    /// View model class for a report beastie icon.
    /// </summary>
    public class BeastieReportIconViewModel : ViewModelBase, IBeastieReportIconViewModel
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="BeastieReportIconViewModel"/> class
        /// </summary>
        /// <param name="commonName">the name of the beastie</param>
        /// <param name="latinName">the latin name of the beastie</param>
        /// <param name="imagePath">the path to the beastie's image</param>
        /// <param name="presence">the presence of the beastie in the locality</param>
        public BeastieReportIconViewModel(
            string commonName,
            string latinName,
            string imagePath,
            Presence presence)
        {
            this.CommonName = commonName;
            this.LatinName = latinName;
            this.ImagePath = imagePath;
            this.Presence = presence;
        }

        /// <summary>
        /// Gets the name of the beastie.
        /// </summary>
        public string CommonName { get; }

        /// <summary>
        /// Gets the (latin) name of the beastie.
        /// </summary>
        public string LatinName { get; }

        /// <summary>
        /// Gets the path to an image of the beastie.
        /// </summary>
        public string ImagePath { get; }

        /// <summary>
        /// Gets a value which indicates the residential status of the beastie.
        /// </summary>
        public Presence Presence { get; }
    }
}