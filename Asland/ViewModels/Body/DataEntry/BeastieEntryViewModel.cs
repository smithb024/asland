namespace Asland.ViewModels.Body.DataEntry
{
    using System.Collections.Generic;
    using Asland.Interfaces.ViewModels.Body.DataEntry;
    using NynaeveLib.ViewModel;

    /// <summary>
    /// View model which supports a view responisble for entry of the beasties in an event.
    /// </summary>
    public class BeastieEntryViewModel : ViewModelBase, IBeastieEntry
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="BeastieEntryViewModel"/> class.
        /// </summary>
        public BeastieEntryViewModel()
        {
            this.Beasties = new List<IBeastieEntry>();
        }

        /// <summary>
        /// Gets the collection of all beasties on this page.
        /// </summary>
        public List<IBeastieEntry> Beasties { get; }
    }
}
