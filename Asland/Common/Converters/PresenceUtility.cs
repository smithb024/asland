using Asland.Common.Enums;
using Asland.Common.Utils;
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
                    return ColourLibrary.Breeding;

                case Presence.Hibernates:
                    return ColourLibrary.Hibernates;

                case Presence.NonBreeding:
                    return ColourLibrary.NonBreeding;

                case Presence.Passing:
                    return ColourLibrary.Passing;

                case Presence.Resident:
                    return ColourLibrary.Resident;

                case Presence.Vagrant:
                    return ColourLibrary.Vagrant;

                default:
                    return ColourLibrary.UnknownColour;
            }
        }
    }
}
