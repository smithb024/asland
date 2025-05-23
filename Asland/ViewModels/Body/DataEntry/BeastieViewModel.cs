﻿namespace Asland.ViewModels.Body.DataEntry
{
    using System;
    using Asland.Interfaces.ViewModels.Body.DataEntry;
    using Asland.Common.Enums;
    using Asland.ViewModels.Body.Common;
    using Asland.Interfaces;
    using System.Windows.Input;
    using NynaeveLib.Commands;

    /// <summary>
    /// View model used to describe a single beastie for display on the raw data entry view.
    /// </summary>
    public class BeastieViewModel : BeastieIconBaseViewModel, IBeastieViewModel
    {
        /// <summary>
        /// Indicates whether the view model is managing seen or heard observations.
        /// </summary>
        private readonly bool isSeen;

        /// <summary>
        /// Set the beastie as observed in the model.
        /// </summary>
        private readonly Action<string, bool, bool> setObservation;

        /// <summary>
        /// Field indicating whether this beastie has been selected as part of the current event.
        /// </summary>
        private bool isSelected;

        /// <summary>
        /// Initialises a new instance of the <see cref="BeastieViewModel"/> class.
        /// </summary>
        /// <param name="pathManager">the path manager</param>
        /// <param name="name">beastie name</param>
        /// <param name="commonName">common name</param>
        /// <param name="latinName">latin name</param>
        /// <param name="imagePath">
        /// Path to an image of this beastie.
        /// </param>
        /// <param name="presence">
        /// Residency of this beastie.
        /// </param>
        /// <param name="isSelected">
        /// Indicates whether this beastie is present in the model.
        /// </param>
        /// <param name="setObservation">
        /// Action used to set an observation in the model.
        /// </param>
        /// <param name="isSeen">
        /// Indicates whether this observation is seen or heard.
        /// </param>
        public BeastieViewModel(
            IPathManager pathManager,
            string name,
            string commonName,
            string latinName,
            string imagePath,
            Presence presence,
            bool isSelected,
            Action<string, bool, bool> setObservation,
            bool isSeen)
            : base(
                  pathManager,
                  name,
                  commonName,
                  latinName,
                  imagePath,
                  presence)
        {
            this.isSelected = isSelected;
            this.isSeen = isSeen;
            this.setObservation = setObservation;
            this.SelectCommand =
                new CommonCommand(
                    this.Select);
        }

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
                    this.OnPropertyChanged(nameof(this.IsSelected));

                    this.setObservation.Invoke(
                        this.CommonName,
                        this.isSelected,
                        this.isSeen);
                }
            }
        }

        /// <summary>
        /// Gets the command presented to the user to allow them to select this beastie.
        /// </summary>
        public ICommand SelectCommand { get; }

        /// <summary>
        /// Invert <see cref="IsSelected"/>. 
        /// </summary>
        private void Select()
        {
            this.IsSelected = !this.IsSelected;
        }
    }
}