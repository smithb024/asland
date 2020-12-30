namespace Asland.ViewModels.Body.DataEntry
{
    using System.Collections.ObjectModel;
    using Asland.Interfaces.ViewModels.Body.DataEntry;
    using GalaSoft.MvvmLight;

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
            this.Beasties = new ObservableCollection<IBeastieViewModel>();
        }

        /// <summary>
        /// Gets the collection of all beasties on this page.
        /// </summary>
        public ObservableCollection<IBeastieViewModel> Beasties { get; }

        /// <summary>
        /// Clear the beasties.
        /// </summary>
        public void Clear()
        {
            this.Beasties.Clear();
        }

        /// <summary>
        /// Add a new beastie to the view model.
        /// </summary>
        /// <param name="beastie">beastie common name</param>
        public void Add(string beastie)
        {
            IBeastieViewModel newBeastie =
                new BeastieViewModel(
                    beastie,
                    "TBC",
                    $"{DataPath.BasePath}\\Sample.png");

            this.Beasties.Add(newBeastie);
        }

        /// <summary>
        /// Refresh the page.
        /// </summary>
        public void Refresh()
        {
            this.RaisePropertyChanged(nameof(this.Beasties));
        }
    }
}