using Asland.Common.Enums;
using System.Windows.Media;

namespace Asland.Common.Converters
{
    /// <summary>
    /// Utility class which is used to translate a <see cref="Presence"/> to a <see cref="Color"/>
    /// </summary>
    public static class PresenceUtility
    {
        /// <summary>
        /// Translate a <see cref="Presence"/> to a <see cref="Color"/> which can be displayed on 
        /// the screen.
        /// </summary>
        /// <param name="prescence">The value to translate</param>
        /// <returns>The new <see cref="Color"/></returns>
        public static Color Translate(Presence prescence)
        {
            switch (prescence)
            {
                case Presence.Breeding:
                    return Colors.Tomato;

                case Presence.Hibernates:
                    return Colors.PowderBlue;

                case Presence.NonBreeding:
                    return Colors.DodgerBlue;

                case Presence.Passing:
                    return Colors.DarkGoldenrod;

                case Presence.Resident:
                    return Colors.ForestGreen;

                case Presence.Vagrant:
                    return Colors.LightSteelBlue;

                default:
                    return Colors.HotPink;
            }
        }
    }
}
