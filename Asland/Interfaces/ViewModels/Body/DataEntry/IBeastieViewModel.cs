namespace Asland.Interfaces.ViewModels.Body.DataEntry
{
    using Asland.Common.Enums;
    using Asland.Interfaces.ViewModels.Body.Common;

    /// <summary>
    /// Interface for a view model which is used to select a beastie in an event.
    /// </summary>
    public interface IBeastieViewModel : IBeastieIconBaseViewModel
    {
        /// <summary>
        /// Gets or sets a value indicating whether the beastie has been selected.
        /// </summary>
        bool IsSelected { get; set; }
    }
}