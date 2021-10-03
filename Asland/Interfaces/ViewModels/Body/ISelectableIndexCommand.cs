namespace Asland.Interfaces.ViewModels.Body
{
    using NynaeveLib.Commands;

    /// <summary>
    /// Extension of the <see cref="IIndexCommand{T}"/> interface to allow support of a button 
    /// which can indicate when it is selected.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ISelectableIndexCommand<T> : IIndexCommand<T>
    {
        /// <summary>
        /// Gets a value indicating whether the button is selected.
        /// </summary>
        bool IsSelected { get; }

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
