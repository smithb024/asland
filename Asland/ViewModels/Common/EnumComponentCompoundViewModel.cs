namespace Asland.ViewModels.Common
{
    using System;
    using System.Windows.Input;
    using Interfaces.ViewModels.Common;
    using NynaeveLib.Commands;
    using NynaeveLib.ViewModel;

    /// <summary>
    /// A view model for a selectable component with the enumeration selector 
    /// <see cref="IEnumSelectorComponentViewModel{TEnum}"/>.
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
    public class EnumComponentCompoundViewModel<TEnum> : ViewModelBase, IEnumComponentCompoundViewModel<TEnum> where TEnum : struct, IConvertible, IComparable, IFormattable
    {
        /// <summary>
        /// Action to invoke when the component is selected.
        /// </summary>
        private readonly Action<TEnum> setAction;

        /// <summary>
        /// Action to invoke when the component is deselected.
        /// </summary>
        private readonly Action<TEnum> unsetAction;

        /// <summary>
        /// Indicates whether this component is selected.
        /// </summary>
        private bool isSelected;

        /// <summary>
        /// Initialises a new instance of the <see cref="EnumComponentCompoundViewModel{TEnum}"/> class.
        /// </summary>
        /// <param name="representative">
        /// The enumerate which this component represents.
        /// </param>
        /// <param name="setAction">
        /// The action to run when this component is selected.
        /// </param>
        /// <param name="setAction">
        /// The action to run when this component is desselected.
        /// </param>
        public EnumComponentCompoundViewModel(
            TEnum representative,
            Action<TEnum> setAction,
            Action<TEnum> unsetAction)
        {
            this.isSelected = false;
            this.RepresentativeValue = representative;
            this.Name = representative.ToString();
            this.setAction = setAction;
            this.unsetAction = unsetAction;

            this.SelectStateCommand =
                new CommonCommand(
                    this.Select);
        }

        /// <summary>
        /// Gets the enumeration value within <see cref="TEnum"/> which is represented by this 
        /// interface.
        /// </summary>
        public TEnum RepresentativeValue { get; }

        /// <summary>
        /// Gets the name of this value which is displayed to the user.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets a value which indicates whether this component is currently selected.
        /// </summary>
        public bool IsSelected => this.isSelected;

        /// <summary>
        /// Gets the command presented to the user to allow them to select this component value.
        /// </summary>
        public ICommand SelectStateCommand { get; }

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
        public void Set(bool isSelected)
        {
            this.isSelected = isSelected;
            this.OnPropertyChanged(nameof(this.isSelected));
        }

        /// <summary>
        /// Select this <see cref="RepresentativeValue"/> as the current value within the 
        /// enumeration selector.
        /// </summary>
        private void Select()
        {
            this.isSelected = !this.isSelected;

            if (this.isSelected)
            {
                this.setAction.Invoke(this.RepresentativeValue);
            }
            else
            {
                this.unsetAction.Invoke(this.RepresentativeValue);
            }

            this.OnPropertyChanged(nameof(this.isSelected));
        }
    }
}