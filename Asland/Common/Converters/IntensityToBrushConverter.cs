namespace Asland.Common.Converters
{
    using System;
    using System.Windows.Data;
    using System.Windows.Media;

    using Asland.Common.Enums;

    /// <summary>
    /// Used to convert a <see cref="ComponentState"/> value to a <see cref="Brush"/> to be used
    /// as the day icon background.
    /// </summary>
    [ValueConversion(typeof(ObservationIntensity), typeof(Brush))]
    public class IntensityToBrushConverter : IValueConverter
    {
        /// <summary>
        /// Convert from a <see cref="ObservationIntensity"/> to a <see cref="Brush"/>
        /// </summary>
        /// <param name="value">original value</param>
        /// <param name="targetType">target type is not used.</param>
        /// <param name="parameter">parameter is not used.</param>
        /// <param name="culture">culture is not used.</param>
        /// <returns>new brush</returns>
        public object Convert(
          object value,
          Type targetType,
          object parameter,
          System.Globalization.CultureInfo culture)
        {
            Color convertedColour;

            if (
              value == null ||
              value.GetType() != typeof(ObservationIntensity))
            {
                convertedColour = Colors.HotPink;
            }
            else
            {
                ObservationIntensity convertedState = (ObservationIntensity)value;

                switch (convertedState)
                {
                    case ObservationIntensity.Snapshot:
                        convertedColour = Colors.Indigo;
                        break;

                    case ObservationIntensity.H:
                        convertedColour = Colors.DarkGreen;
                        break;

                    case ObservationIntensity.M:
                        convertedColour = Colors.ForestGreen;
                        break;

                    case ObservationIntensity.L:
                        convertedColour = Colors.Olive;
                        break;

                    case ObservationIntensity.Run:
                        convertedColour = Colors.DarkBlue;
                        break;

                    case ObservationIntensity.Cycling:
                        convertedColour = Colors.MediumBlue;
                        break;

                    case ObservationIntensity.Walk:
                        convertedColour = Colors.RoyalBlue;
                        break;

                    case ObservationIntensity.Commute:
                        convertedColour = Colors.IndianRed;
                        break;

                    case ObservationIntensity.RailJourney:
                        convertedColour = Colors.DarkGoldenrod;
                        break;

                    case ObservationIntensity.SeaJourney:
                        convertedColour = Colors.Goldenrod;
                        break;

                    default:
                        convertedColour = Colors.Black;
                        break;
                }
            }

            return new SolidColorBrush(convertedColour);
        }

        /// <summary>
        /// Not used.
        /// </summary>
        /// <param name="value">value is not used.</param>
        /// <param name="targetType">target type is not used.</param>
        /// <param name="parameter">parameter is not used.</param>
        /// <param name="culture">culture is not used.</param>
        /// <returns>no return</returns>
        public object ConvertBack(
          object value,
          Type targetType,
          object parameter,
          System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
