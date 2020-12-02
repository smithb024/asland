namespace Asland.Interfaces.ViewModels.Common
{
    using System;
    using System.Windows.Input;

    /// <summary>
    /// Interface which describes a view model for a single selectable component with the 
    /// enumeration selector <see cref="IEnumSelectorViewModel{TEnum}"/>.
    /// The enumeration selector will present one of these for each enumerate in the 
    /// enumeration.
    /// When selected, the enumeration selector will return a value equal to the
    /// value represented by this component.
    /// </summary>
    /// <typeparam name="TEnum">Subject enumeration</typeparam>
    public interface IEnumComponentViewModel<TEnum> where TEnum : struct, IConvertible, IComparable, IFormattable
    {
        /// <summary>
        /// Gets the enumeration value within <see cref="TEnum"/> which is represented by this 
        /// interface.
        /// </summary>
        TEnum RepresentativeValue { get; }

        /// <summary>
        /// Gets the name of this value which is displayed to the user.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets the currently selected value within the selector component as a whole.
        /// </summary>
        TEnum CurrentValue { get; }

        /// <summary>
        /// Gets a value which indicates whether this component is currently selected.
        /// </summary>
        bool IsSelected { get; }

        /// <summary>
        /// Gets the method to action when this component is selected by the user.
        /// </summary>
        Action<TEnum> Action { get; }

        /// <summary>
        /// Gets the command presented to the user to allow them to select this component value.
        /// </summary>
        ICommand SelectStateCommand { get; }

        /// <summary>
        /// Set the current value as defined within the enumeration selector component.
        /// </summary>
        /// <param name="newValue">new value</param>
        void SetCurrent(TEnum newValue);
    }
}