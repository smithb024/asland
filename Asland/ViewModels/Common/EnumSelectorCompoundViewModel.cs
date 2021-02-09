namespace Asland.ViewModels.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Interfaces.ViewModels.Common;
    using NynaeveLib.Commands;
    using NynaeveLib.ViewModel;

    /// <summary>
    /// Interface which describes a component used by a user to select a enumerate value from all
    /// possible enumeration values.
    /// </summary>
    /// <typeparam name="TEnum">Subject enumeration</typeparam>
    public class EnumSelectorCompoundViewModel<TEnum> : ViewModelBase, IEnumSelectorCompoundViewModel<TEnum> where TEnum : struct, IConvertible, IComparable, IFormattable
    {
        /// <summary>
        /// The currently selected values.
        /// </summary>
        private List<TEnum> current;

        /// <summary>
        /// Initialises a new instances of the <see cref="EnumSelectorCompoundViewModel{TEnum}"/> class
        /// </summary>
        /// <param name="name">The name of the component as presented to the user</param>
        /// <param name="command">
        /// The method to invoke when a new value is selected.
        /// </param>
        public EnumSelectorCompoundViewModel(
            string name,
            Action<List<TEnum>> command)
        {
            this.Name = name;
            this.Action = command;
            this.current = new List<TEnum>();

            this.Controls = new List<IEnumComponentCompoundViewModel<TEnum>>();

            foreach (TEnum enumerate in Enum.GetValues(typeof(TEnum)))
            {
                EnumComponentCompoundViewModel<TEnum> newComponent =
                    new EnumComponentCompoundViewModel<TEnum>(
                        enumerate,
                        this.Set,
                        this.Unset);
                this.Controls.Add(newComponent);
            }
        }

        /// <summary>
        /// Gets the name of the comonent.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Collection of all the enumerate selector controls within the enumeration selector.
        /// </summary>
        public List<IEnumComponentCompoundViewModel<TEnum>> Controls { get; }

        /// <summary>
        /// Gets the action to invoke when a new enumerate has been selected.
        /// </summary>
        public Action<List<TEnum>> Action { get; }

        /// <summary>
        /// Set a new collection of values.
        /// </summary>
        /// <remarks>
        /// This just sets the values, it doesn't inform any other interested parties that it
        /// has done this.
        /// </remarks>
        /// <param name="newValues">The new values</param>
        public void Set(List<TEnum> newValues)
        {
            // Clear the local values.
            foreach (TEnum enumerate in Enum.GetValues(typeof(TEnum)))
            {
                this.current.Remove(enumerate);
            }

            // Clear the view controls
            foreach (IEnumComponentCompoundViewModel<TEnum> control in this.Controls)
            {
                control.Set(false);
            }

            // Set up the new values.
            foreach (TEnum newValue in newValues)
            {
                IEnumComponentCompoundViewModel<TEnum> control =
                    this.Controls.Find(c => c.RepresentativeValue.Equals(newValue));
                control.Set(true);
                this.current.Add(newValue);
            }
        }

        /// <summary>
        /// Set a new current value.
        /// </summary>
        /// <param name="newValue">The new value</param>
        private void Set(TEnum newValue)
        {
            if (!this.current.Contains(newValue))
            {
                this.current.Add(newValue);
            }

            this.Action.Invoke(this.current);
        }

        /// <summary>
        /// Remove a value from the list.
        /// </summary>
        /// <param name="newValue">Value to remove</param>
        private void Unset(TEnum newValue)
        {
            this.current.Remove(newValue);
            this.Action.Invoke(this.current);
        }
    }
}