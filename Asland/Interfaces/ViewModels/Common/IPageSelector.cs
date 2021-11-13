namespace Asland.Interfaces.ViewModels.Common
{
    using System.Windows.Input;

    /// <summary>
    /// Interface for a view model which supports the data entry page selection.
    /// </summary>
    public interface IPageSelector
    {
        /// <summary>
        /// Gets the name of this value which is displayed to the user.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets a value indicating whether the button is selected.
        /// </summary>
        bool IsSelected { get; }

        /// <summary>
        /// Gets the command used to select a new data entry page.
        /// </summary>
        ICommand SelectNewPage { get; }

        /// <summary>
        /// The the name of the button which is selected. 
        /// </summary>
        /// <remarks>
        /// It is the responsibility of the button to decide if it is the one which is selected.
        /// </remarks>
        /// <param name="name">Name of the selected button</param>
        void SelectedButton(string name);
    }
}