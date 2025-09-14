namespace Asland.Common.Converters
{
    using Asland.Common.Enums;
    using Asland.Common.Utils;
    using System;
    using System.Globalization;
    using System.Windows.Data;
    using System.Windows.Media;

    /// <summary>
    /// Used to convert a <see cref="Presence"/> value to a <see cref="Brush"/> to be used
    /// as the day icon background.
    /// This is a multi converter and will return a selected colour if a flag is set.
    /// </summary>
    public class PresenceSelectedToBrushConverter : IMultiValueConverter
    {
        /// <summary>
        /// Convert a <see cref="Presence"/> to a <see cref="Brush"/>.
        /// </summary>
        /// <param name="values">
        /// Array of two values:
        /// 1 - A component is selected flag.
        /// 2 - A <see cref="Presence"/> value.
        /// </param>
        /// <param name="targetType">Not used</param>
        /// <param name="parameter">Not used</param>
        /// <param name="culture">Not used</param>
        /// <returns></returns>
        public object Convert(
            object[] values,
            Type targetType,
            object parameter,
            CultureInfo culture)
        {
            Color convertedColour;

            if (values.Length != 2)
            {
                convertedColour = ColourLibrary.UnknownColour;
            }
            else if (values[0].GetType() != typeof(bool) ||
                values[1].GetType() != typeof(Presence))
            {
                convertedColour = ColourLibrary.UnknownColour;
            }
            else if ((bool)values[0])
            {
                convertedColour = ColourLibrary.IsSelected;
            }
            else
            {
                convertedColour =
                    PresenceUtility.Translate(
                        (Presence)values[1]);
            }

            return new SolidColorBrush(convertedColour);
        }

        /// <summary>
        /// Convert back is not used.
        /// </summary>
        /// <param name="value">Not used</param>
        /// <param name="targetTypes">Not used</param>
        /// <param name="parameter">Not used</param>
        /// <param name="culture">Not used</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public object[] ConvertBack(
            object value,
            Type[] targetTypes,
            object parameter,
            CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}