namespace Asland.ViewModels.Body.DataEntry
{
    using System;
    using System.Collections.ObjectModel;
    using Asland.Interfaces.ViewModels.Body.DataEntry;
    using GalaSoft.MvvmLight;

    /// <summary>
    /// View model which supports a view responisble for entry of the beasties in an event.
    /// </summary>
    public class BeastieEntryViewModel : ViewModelBase, IBeastieEntry
    {
        /// <summary>
        /// Set the beastie as observed in the model.
        /// </summary>
        private Action<string, bool, bool> setObservation;

        /// <summary>
        /// Indicates whether the view model is managing seen or heard observations.
        /// </summary>
        private bool isSeen;

        /// <summary>
        /// Initialises a new instance of the <see cref="BeastieEntryViewModel"/> class.
        /// </summary>
        /// <param name="setObservation">
        /// Action used to set an observation in the model.
        /// </param>
        /// <param name="isSeen">Indicates whether the observations are seen or heard</param>
        public BeastieEntryViewModel(
            Action<string, bool, bool> setObservation,
            bool isSeen)
        {
            this.Beasties = new ObservableCollection<IBeastieViewModel>();
            this.setObservation = setObservation;
            this.isSeen = isSeen;
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
        /// <param name="isSelected">
        /// Indicates whether the new beastie is present in the model.
        /// </param>
        public void Add(
            string beastie,
            bool isSelected)
        {
            IBeastieViewModel newBeastie =
                new BeastieViewModel(
                    beastie,
                    "TBC",
                    $"{DataPath.BasePath}\\Sample.png",
                    isSelected,
                    this.setObservation,
                    this.isSeen);

            this.Beasties.Add(newBeastie);
        }

        /// <summary>
        /// Refresh the page.
        /// </summary>
        public void Refresh()
        {
            this.RaisePropertyChanged(nameof(this.Beasties));
        }

        /// <summary>
        /// Set a value which indicates whether the view model is managing seen or heard observations.
        /// </summary>
        /// <param name="isSeen">is seen flag</param>
        public void SetIsSeen(bool isSeen)
        {
            this.isSeen = isSeen;
        }
    }
}