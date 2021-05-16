namespace Asland.Interfaces.ViewModels.Body.Configuration
{
    using System.Collections.ObjectModel;
    using System.Windows.Input;
    using Asland.Common.Enums;

    /// <summary>
    /// Interface for a view model which is used to configure a beastie.
    /// </summary>
    public interface IBeastieConfigurationViewModel
    {
        /// <summary>
        /// Gets a collection of the names of all the beasties in the data collection.
        /// </summary>
        ObservableCollection<string> Beasties { get; }

        /// <summary>
        /// Gets or sets the index of the currently selected beastie.
        /// </summary>
        int BeastieIndex { get; set; }

        /// <summary>
        /// Gets or sets the name of the beastie
        /// </summary>
        string DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the latin name of the beastie.
        /// </summary>
        string NameLatin { get; set; }

        /// <summary>
        /// Gets the list of beastie image lists.
        /// </summary>
        ObservableCollection<string> BeastieImageList { get; }

        /// <summary>
        /// Gets or sets the index for the list of beastie image lists.
        /// </summary>
        int BeastieImageListIndex { get; set; }

        /// <summary>
        /// Gets the path to the selected image.
        /// </summary>
        string ImagePath { get; }

        /// <summary>
        /// Gets or sets the beastie's size.
        /// </summary>
        int Size { get; set; }

        /// <summary>
        /// Gets the list of possible residency states.
        /// </summary>
        ObservableCollection<Presence> PresenceList { get; }

        /// <summary>
        /// Gets or sets the index for the presence of a beastie.
        /// </summary>
        int PresenceListIndex { get; set; }

        /// <summary>
        /// Gets or sets the Genus of the beastie.
        /// </summary>
        string Genus { get; set; }

        /// <summary>
        /// Gets or sets the Genus of the beastie in latin.
        /// </summary>
        string GenusLatin { get; set; }

        /// <summary>
        /// Gets or sets the Sub Family of the beastie.
        /// </summary>
        string SubFamily { get; set; }

        /// <summary>
        /// Gets or sets the Sub Family of the beastie in latin.
        /// </summary>
        string SubFamilyLatin { get; set; }

        /// <summary>
        /// Gets or sets the Family of the beastie.
        /// </summary>
        string Family { get; set; }

        /// <summary>
        /// Gets or sets the Family of the beastie in latin.
        /// </summary>
        string FamilyLatin { get; set; }

        /// <summary>
        /// Gets or sets the Order of the beastie.
        /// </summary>
        string Order { get; set; }

        /// <summary>
        /// Gets or sets the Order of the beastie in latin.
        /// </summary>
        string OrderLatin { get; set; }

        /// <summary>
        /// Gets or sets the Class of the beastie.
        /// </summary>
        string Class { get; set; }

        /// <summary>
        /// Gets or sets the Class of the beastie in latin.
        /// </summary>
        string ClassLatin { get; set; }

        /// <summary>
        /// Command used to save a beastie.
        /// </summary>
        ICommand SaveCommand { get; }

        /// <summary>
        /// Command used to load a beastie.
        /// </summary>
        ICommand LoadCommand { get; }

        /// <summary>
        /// Command used to discard results.
        /// </summary>
        ICommand DiscardCommand { get; }

        /// <summary>
        /// Indicates whether a beastie can be loaded.
        /// </summary>
        /// <returns>can load flag</returns>
        bool CanLoad();

        /// <summary>
        /// Indicates whether a beastie can be saved.
        /// </summary>
        /// <returns></returns>
        bool CanSave();
    }
}
