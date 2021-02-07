namespace Asland.Interfaces.ViewModels.Common
{
    using System;
    using System.Windows.Input;

    /// <summary>
    /// Interface which describes a view model for a selectable component with the 
    /// enumeration selector <see cref="IEnumSelectorCompoundViewModel{TEnum}"/>.
    /// The enumeration selector will present one of these for each enumerate in the 
    /// enumeration.
    /// When selected, the enumeration selector will return a value equal to the
    /// value represented by this component.
    /// </summary>
    /// <remarks>
    /// This type of selector allows multiple enumeration values to be selected, therefore 
    /// instances of this class are not mutually exclusive.
    /// </remarks>
    /// <typeparam name="TEnum">Subject enumeration</typeparam>
    public interface IEnumComponentCompoundViewModel<TEnum> where TEnum : struct, IConvertible, IComparable, IFormattable
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
        /// Gets a value which indicates whether this component is currently selected.
        /// </summary>
        bool IsSelected { get; }

        /// <summary>
        /// Gets the command presented to the user to allow them to select this component value.
        /// </summary>
        ICommand SelectStateCommand { get; }

        /// <summary>
        /// Set a new value for this <see cref="IEnumComponentCompoundViewModel{TEnum}"/> object.
        /// </summary>
        /// <remarks>
        /// This method sets this object, but does not trigger any actions other than redraw. It
        /// is assumed that the setting object already knows the value.
        /// </remarks>
        /// <param name="isSelected">
        /// Indicates whether the object is selected or not.
        /// </param>
        void Set(bool isSelected);
    }
}