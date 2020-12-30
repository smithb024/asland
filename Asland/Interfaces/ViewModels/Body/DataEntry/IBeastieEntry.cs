namespace Asland.Interfaces.ViewModels.Body.DataEntry
{
    using System.Collections.ObjectModel;

    /// <summary>
    /// Interface for a view model which supports a view responisble for entry of the beasties in 
    /// an event.
    /// </summary>
    public interface IBeastieEntry
    {
        /// <summary>
        /// Gets the collection of all beasties on this page.
        /// </summary>
        ObservableCollection<IBeastieViewModel> Beasties { get; }

        /// <summary>
        /// Clear the beasties.
        /// </summary>
        void Clear();

        /// <summary>
        /// Add a new beastie to the view model.
        /// </summary>
        /// <param name="beastie">beastie common name</param>
        void Add(string beastie);

        /// <summary>
        /// Refresh the page.
        /// </summary>
        void Refresh();
    }
}
