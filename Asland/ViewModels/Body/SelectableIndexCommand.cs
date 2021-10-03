namespace Asland.ViewModels.Body
{
    using System;
    using Asland.Interfaces.ViewModels.Body;
    using NynaeveLib.Commands;

    /// <summary>
    /// Override of the <see cref="IndexCommand{T}"/>. This allows a button view model to be 
    /// supported which indicates a selection model.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SelectableIndexCommand<T> : IndexCommand<T>, ISelectableIndexCommand<T>
    {
        /// <summary>
        /// Indicates whether this button is currently selected.
        /// </summary>
        private bool isSelected;

        /// <summary>
        /// Initialises a new instance of the <see cref="SelectableIndexCommand{T}"/> class.
        /// </summary>
        /// <param name="name">Index command name</param>
        /// <param name="command">
        /// The method to invoke when this command is actioned.
        /// </param>
        public SelectableIndexCommand(
            T name,
            Action<T> command)
            : base(name, command)
        {
            this.isSelected = false;
        }

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
    }
}