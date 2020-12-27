namespace Asland.Interfaces.ViewModels.Body.DataEntry
{
    using System.Collections.Generic;

    /// <summary>
    /// Interface for a view model which supports a view responisble for entry of the beasties in 
    /// an event.
    /// </summary>
    public interface IBeastieEntry
    {
        /// <summary>
        /// Gets the collection of all beasties on this page.
        /// </summary>
        List<IBeastieViewModel> Beasties { get; }
    }
}
