namespace Asland.Common.Converters
{
    using System;
    using System.Windows.Data;
    using System.Windows.Media;

    using Asland.Common.Enums;
    using Asland.Common.Utils;

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
                convertedColour = ColourLibrary.UnknownColour;
            }
            else
            {
                ObservationIntensity convertedState = (ObservationIntensity)value;

                switch (convertedState)
                {
                    case ObservationIntensity.Snapshot:
                        convertedColour = ColourLibrary.Snapshot;
                        break;

                    case ObservationIntensity.H:
                        convertedColour = ColourLibrary.HighIntensity;
                        break;

                    case ObservationIntensity.M:
                        convertedColour = ColourLibrary.MediumIntensity;
                        break;

                    case ObservationIntensity.L:
                        convertedColour = ColourLibrary.LowIntensity;
                        break;

                    case ObservationIntensity.Run:
                        convertedColour = ColourLibrary.Run;
                        break;

                    case ObservationIntensity.Cycling:
                        convertedColour = ColourLibrary.Cycling;
                        break;

                    case ObservationIntensity.Walk:
                        convertedColour = ColourLibrary.Walk;
                        break;

                    case ObservationIntensity.Commute:
                        convertedColour = ColourLibrary.Commute;
                        break;

                    case ObservationIntensity.RailJourney:
                        convertedColour = ColourLibrary.Rail;
                        break;

                    case ObservationIntensity.SeaJourney:
                        convertedColour = ColourLibrary.Sea;
                        break;

                    default:
                        convertedColour = ColourLibrary.UnknownColour;
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
