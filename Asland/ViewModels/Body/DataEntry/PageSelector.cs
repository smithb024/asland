namespace Asland.ViewModels.Body.DataEntry
{
    using System;
    using System.Windows.Input;
    using Asland.Interfaces.ViewModels.Body.DataEntry;
    using NynaeveLib.Commands;
    using NynaeveLib.ViewModel;

    /// <summary>
    /// A view model which supports the data entry page selection.
    /// </summary>
    public class PageSelector : ViewModelBase, IPageSelector
    {
        /// <summary>
        /// Indicates whether this button is currently selected.
        /// </summary>
        private bool isSelected;

        /// <summary>
        /// Command to run when the left mouse button is pressed.
        /// </summary>
        private Action<string> command;

        /// <summary>
        /// Initialises a new instance of the <see cref="PageSelector"/> class.
        /// </summary>
        /// <param name="name">Index command name</param>
        /// <param name="command">
        /// The method to invoke when this command is actioned.
        /// </param>
        public PageSelector(
            string name,
            Action<string> command)
        {
            this.Name = name;
            this.command = command;
            this.SelectNewPage =
                new CommonCommand(
                    this.Select);
            this.isSelected = false;
        }

        /// <summary>
        /// Gets the name of this value which is displayed to the user.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets a value indicating whether the button is selected.
        /// </summary>
        public bool IsSelected
        {
            get
            {
                return this.isSelected;
            }

            private set
            {
                if (this.isSelected != value)
                {
                    this.isSelected = value;
                    this.RaisePropertyChangedEvent(nameof(this.IsSelected));
                }
            }
        }

        /// <summary>
        /// Gets the command used to select a new data entry page.
        /// </summary>
        public ICommand SelectNewPage { get; }

        /// <summary>
        /// The the name of the button which is selected. 
        /// </summary>
        /// <remarks>
        /// It is the responsibility of the button to decide if it is the one which is selected.
        /// </remarks>
        /// <param name="selectedName">Name of the selected button</param>
        public void SelectedButton(string selectedName)
        {
            this.IsSelected =
                string.Compare(
                    this.Name,
                    selectedName) == 0;
        }

        /// <summary>
        /// Invoke the command.
        /// </summary>
        private void Select()
        {
            this.command.Invoke(this.Name);
        }
    }
}