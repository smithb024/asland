namespace Asland.Interfaces.ViewModels.Body.DataEntry
{
    using Asland.Common.Enums;

    /// <summary>
    /// Interface for a view model which is used to select a beastie in an event.
    /// </summary>
    public interface IBeastieViewModel
    {
        /// <summary>
        /// Gets the name of the beastie.
        /// </summary>
        string CommonName { get; }

        /// <summary>
        /// Gets the (latin) name of the beastie.
        /// </summary>
        string LatinName { get; }

        /// <summary>
        /// Gets the path to an image of the beastie.
        /// </summary>
        string ImagePath { get; }

        /// <summary>
        /// Gets or sets a value indicating whether the beastie has been selected.
        /// </summary>
        bool IsSelected { get; set; }

        /// <summary>
        /// Gets a value which indicates the residential status of the beastie.
        /// </summary>
        Presence Presence { get; }
    }
}
