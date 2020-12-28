namespace Asland.ViewModels.Body.DataEntry
{
    using Asland.Interfaces.ViewModels.Body.DataEntry;
    using NynaeveLib.ViewModel;

    /// <summary>
    /// View model used to describe a single beastie for display on the raw data entry view.
    /// </summary>
    public class BeastieViewModel : ViewModelBase, IBeastieViewModel
    {
        /// <summary>
        /// Field indicating whether this beastie has been selected as part of the current event.
        /// </summary>
        private bool isSelected;

        /// <summary>
        /// Initialises a new instance of the <see cref="BeastieViewModel"/> class.
        /// </summary>
        /// <param name="commonName">common name</param>
        /// <param name="latinName">latin name</param>
        /// <param name="imagePath">
        /// Path to an image of this beastie.
        /// </param>
        public BeastieViewModel(
            string commonName,
            string latinName,
            string imagePath)
        {
            this.CommonName = commonName;
            this.LatinName = latinName;
            this.ImagePath = imagePath;
            this.isSelected = false;
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
        /// Gets or sets a value indicating whether the beastie has been selected.
        /// </summary>
        public bool IsSelected
        {
            get
            {
                return this.isSelected;
            }
            set
            {
                if (this.isSelected != value)
                {
                    this.isSelected = value;
                    this.RaisePropertyChangedEvent(nameof(this.IsSelected));
                }
            }
        }
    }
}