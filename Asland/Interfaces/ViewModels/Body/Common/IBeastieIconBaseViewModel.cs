namespace Asland.Interfaces.ViewModels.Body.Common
{
    using Asland.Common.Enums;

    /// <summary>
    /// This interface serves as the base for a beastie icon. There are different flavours of icon,
    /// but they all have a common set of properties which are defined here.
    /// </summary>
    public interface IBeastieIconBaseViewModel
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
        /// Gets a value which indicates the residential status of the beastie.
        /// </summary>
        Presence Presence { get; }
    }
}