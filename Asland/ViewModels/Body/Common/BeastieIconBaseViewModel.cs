namespace Asland.ViewModels.Body.Common
{
    using Asland.Common.Enums;
    using Asland.Interfaces.ViewModels.Body.Common;
    using NynaeveLib.ViewModel;

    /// <summary>
    /// This class serves as the base for a beastie icon. There are different flavours of icon, but
    /// they all have a common set of properties which are defined here.
    /// </summary>
    public class BeastieIconBaseViewModel : ViewModelBase, IBeastieIconBaseViewModel
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="BeastieReportIconViewModel"/> class
        /// </summary>
        /// <param name="commonName">the name of the beastie</param>
        /// <param name="latinName">the latin name of the beastie</param>
        /// <param name="imagePath">the path to the beastie's image</param>
        /// <param name="presence">the presence of the beastie in the locality</param>
        public BeastieIconBaseViewModel(
            string commonName,
            string latinName,
            string imagePath,
            Presence presence)
        {
            this.CommonName = commonName;
            this.LatinName = latinName;
            this.Presence = presence;

            if (string.IsNullOrEmpty(imagePath))
            {
                this.ImagePath = $"{DataPath.BasePath}\\Sample.png";
            }
            else
            {
                this.ImagePath = $"{DataPath.ImageDataPath}\\{imagePath}";
            }
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