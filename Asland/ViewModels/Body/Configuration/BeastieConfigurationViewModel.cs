namespace Asland.ViewModels.Body.Configuration
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using Asland.Common.Enums;
    using Asland.Interfaces.ViewModels.Body.Configuration;
    using GalaSoft.MvvmLight;

    public class BeastieConfigurationViewModel : ViewModelBase, IBeastieConfigurationViewModel
    {
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
        /// Initialises a new instance of the <see cref="BeastieConfigurationViewModel"/> class.
        /// </summary>
        public BeastieConfigurationViewModel()
        {
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
        }

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
    }
}
