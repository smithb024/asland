namespace Asland.ViewModels.Body.Configuration
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Windows.Input;
    using Asland.Common.Enums;
    using Asland.Interfaces.Factories;
    using Asland.Interfaces.Model.IO.Data;
    using Asland.Interfaces.ViewModels.Body.Configuration;
    using Asland.Model.IO.Data;
    using GalaSoft.MvvmLight;
    using NynaeveLib.Commands;

    public class BeastieConfigurationViewModel : ViewModelBase, IBeastieConfigurationViewModel
    {
        /// <summary>
        /// Indicates whether a file is being edited or not.
        /// </summary>
        private bool isEditMode;

        /// <summary>
        /// The name of the beastie
        /// </summary>
        private string name;

        /// <summary>
        /// The latin name of the beastie.
        /// </summary>
        private string nameLatin;

        /// <summary>
        /// The index for the list of beastie image lists.
        /// </summary>
        private int beastieImageListIndex;

        /// <summary>
        /// The path to the selected image.
        /// </summary>
        private string imagePath;

        /// <summary>
        /// The beastie's size.
        /// </summary>
        private int size;

        /// <summary>
        /// The index for the presence of a beastie.
        /// </summary>
        private int presenceListIndex;

        /// <summary>
        /// The Genus of the beastie.
        /// </summary>
        private string genus;

        /// <summary>
        /// The Genus of the beastie in latin.
        /// </summary>
        private string genusLatin;

        /// <summary>
        /// The Sub Family of the beastie.
        /// </summary>
        private string subFamily;

        /// <summary>
        /// The Sub Family of the beastie in latin.
        /// </summary>
        private string subFamilyLatin;

        /// <summary>
        /// The Family of the beastie.
        /// </summary>
        private string family;

        /// <summary>
        /// The Family of the beastie in latin.
        /// </summary>
        private string familyLatin;

        /// <summary>
        /// The Order of the beastie.
        /// </summary>
        private string order;

        /// <summary>
        /// The Order of the beastie in latin.
        /// </summary>
        private string orderLatin;

        /// <summary>
        /// The Class of the beastie.
        /// </summary>
        private string beastieClass;

        /// <summary>
        /// The Class of the beastie in latin.
        /// </summary>
        private string classLatin;

        /// <summary>
        /// The data manager class.
        /// </summary>
        private IDataManager dataManager;

        /// <summary>
        /// Factory class used to save 
        /// </summary>
        private IBeastieDataFileFactory fileFactory;

        /// <summary>
        /// Initialises a new instance of the <see cref="BeastieConfigurationViewModel"/> class.
        /// </summary>
        /// <param name="dataManager">data manager</param>
        /// <param name="fileFactory">beastie file factory</param>
        public BeastieConfigurationViewModel(
            IDataManager dataManager,
            IBeastieDataFileFactory fileFactory)
        {
            this.isEditMode = false;
            this.dataManager = dataManager;
            this.fileFactory = fileFactory;
            this.BeastieImageList = new ObservableCollection<string>();
            this.PresenceList = new ObservableCollection<Presence>();

            string[] imageFileNamesRaw =
                System.IO.Directory.GetFiles(
                    DataPath.ImageDataPath);

            foreach (string file in imageFileNamesRaw)
            {
                string fileName = file.Substring(file.LastIndexOf('\\') + 1);
                this.BeastieImageList.Add(fileName);
            }

            IEnumerable<Presence> presenceData = Enum.GetValues(typeof(Presence)).Cast<Presence>();

            foreach(Presence presence in presenceData)
            {
                this.PresenceList.Add(presence);
            }

            this.Beasties = new ObservableCollection<string>();
            foreach(Beastie beastie in dataManager.Beasties)
            {
                Beasties.Add(beastie.Name);
            }

            this.SaveCommand =
                new CommonCommand(
                    this.Save,
                    this.CanSave);
            this.LoadCommand =
                new CommonCommand(
                    this.Load,
                    this.CanLoad);
            this.DiscardCommand =
                new CommonCommand(
                    this.Discard,
                    this.CanSave);
        }

        /// <summary>
        /// Gets a collection of the names of all the beasties in the data collection.
        /// </summary>
        public ObservableCollection<string> Beasties { get; }

        /// <summary>
        /// Gets or sets the name of the beastie
        /// </summary>
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.Set(ref this.name, value);
            }
        }

        /// <summary>
        /// Gets or sets the latin name of the beastie.
        /// </summary>
        public string NameLatin
        {
            get
            {
                return this.nameLatin;
            }
            set
            {
                this.Set(ref this.nameLatin, value);
            }
        }

        /// <summary>
        /// Gets the list of beastie image lists.
        /// </summary>
        public ObservableCollection<string> BeastieImageList { get; }

        /// <summary>
        /// Gets or sets the index for the list of beastie image lists.
        /// </summary>
        public int BeastieImageListIndex
        {
            get
            {
                return this.beastieImageListIndex;
            }
            set
            {
                if (this.beastieImageListIndex != value)
                {
                    this.beastieImageListIndex = value;
                    this.RaisePropertyChanged(nameof(this.BeastieImageListIndex));
                    this.RaisePropertyChanged(nameof(this.ImagePath));
                }
            }
        }

        /// <summary>
        /// Gets the path to the selected image.
        /// </summary>
        public string ImagePath => $"{DataPath.ImageDataPath}\\{this.BeastieImageList[this.BeastieImageListIndex]}";

        /// <summary>
        /// Gets or sets the beastie's size.
        /// </summary>
        public int Size
        {
            get
            {
                return this.size;
            }
            set
            {
                this.Set(ref this.size, value);
            }
        }

        /// <summary>
        /// Gets the list of possible residency states.
        /// </summary>
        public ObservableCollection<Presence> PresenceList { get; }

        /// <summary>
        /// Gets or sets the index for the presence of a beastie.
        /// </summary>
        public int PresenceListIndex
        {
            get
            {
                return this.presenceListIndex;
            }
            set
            {
                this.Set(ref this.presenceListIndex, value);
            }
        }

        /// <summary>
        /// Gets or sets the Genus of the beastie.
        /// </summary>
        public string Genus
        {
            get
            {
                return this.genus;
            }
            set
            {
                this.Set(ref this.genus, value);
            }
        }

        /// <summary>
        /// Gets or sets the Genus of the beastie in latin.
        /// </summary>
        public string GenusLatin
        {
            get
            {
                return this.genusLatin;
            }
            set
            {
                this.Set(ref this.genusLatin, value);
            }
        }

        /// <summary>
        /// Gets or sets the Sub Family of the beastie.
        /// </summary>
        public string SubFamily
        {
            get
            {
                return this.subFamily;
            }
            set
            {
                this.Set(ref this.subFamily, value);
            }
        }

        /// <summary>
        /// Gets or sets the Sub Family of the beastie in latin.
        /// </summary>
        public string SubFamilyLatin
        {
            get
            {
                return this.subFamilyLatin;
            }
            set
            {
                this.Set(ref this.subFamilyLatin, value);
            }
        }

        /// <summary>
        /// Gets or sets the Family of the beastie.
        /// </summary>
        public string Family
        {
            get
            {
                return this.family;
            }
            set
            {
                this.Set(ref this.family, value);
            }
        }

        /// <summary>
        /// Gets or sets the Family of the beastie in latin.
        /// </summary>
        public string FamilyLatin
        {
            get
            {
                return this.familyLatin;
            }
            set
            {
                this.Set(ref this.familyLatin, value);
            }
        }

        /// <summary>
        /// Gets or sets the Order of the beastie.
        /// </summary>
        public string Order
        {
            get
            {
                return this.order;
            }
            set
            {
                this.Set(ref this.order, value);
            }
        }

        /// <summary>
        /// Gets or sets the Order of the beastie in latin.
        /// </summary>
        public string OrderLatin
        {
            get
            {
                return this.orderLatin;
            }
            set
            {
                this.Set(ref this.orderLatin, value);
            }
        }

        /// <summary>
        /// Gets or sets the Class of the beastie.
        /// </summary>
        public string Class
        {
            get
            {
                return this.beastieClass;
            }
            set
            {
                this.Set(ref this.beastieClass, value);
            }
        }

        /// <summary>
        /// Gets or sets the Class of the beastie in latin.
        /// </summary>
        public string ClassLatin
        {
            get
            {
                return this.classLatin;
            }
            set
            {
                this.Set(ref this.classLatin, value);
            }
        }

        /// <summary>
        /// Command used to save a beastie.
        /// </summary>
        public ICommand SaveCommand { get; }

        /// <summary>
        /// Command used to load a beastie.
        /// </summary>
        public ICommand LoadCommand { get; }

        /// <summary>
        /// Command used to discard results.
        /// </summary>
        public ICommand DiscardCommand { get; }

        /// <summary>
        /// Indicates whether a beastie can be loaded.
        /// </summary>
        /// <returns>can load flag</returns>
        public bool CanLoad()
        {
            return !this.isEditMode;
        }

        /// <summary>
        /// Indicates whether a beastie can be saved.
        /// </summary>
        /// <returns></returns>
        public bool CanSave()
        {
            return this.isEditMode;
        }

        /// <summary>
        /// Load a beastie from a file.
        /// </summary>
        private void Load()
        {
            
        }

        /// <summary>
        /// Save the beastie back to the file.
        /// </summary>
        private void Save()
        {

        }

        /// <summary>
        /// Discard any updates.
        /// </summary>
        private void Discard()
        {

        }
    }
}
