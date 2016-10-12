using Rage;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GangActivity.callouts.gangshooting
{
    
    /// <summary>
    /// The gang utilities class
    /// </summary>
    public static class GangUtil
    {
        /// <summary>
        /// Gets the gang colour by it's identifier
        /// </summary>
        /// <param name="type">the type of gang member</param>
        /// <returns></returns>
        public static Color getGangColour(GangTypes type)
        {
            foreach (KeyValuePair<GangTypes, Color> entry in GangConstants.GANG_COLOR)
            {
                if (entry.Key == type)
                    return entry.Value;
            }

            return Color.Red;
        }

        /// <summary>
        /// Random object
        /// </summary>
        private static readonly Random rnd = new Random();

        /// <summary>
        /// Gets a random model name
        /// </summary>
        /// <param name="type">The type of model</param>
        /// <returns></returns>
        public static string getRandomModel(GangTypes type)
        {
            foreach (KeyValuePair<GangTypes, List<string>> entry in GangConstants.MODEL_NAMES)
            {
                if (entry.Key == type)
                    return entry.Value[rnd.Next(entry.Value.Count)];
            }
            return "";
        }

        /// <summary>
        /// Gets a random weapon
        /// </summary>
        /// <returns>a weapon hash</returns>
        public static WeaponHash getRandomWeapon()
        {
            if(rnd.Next(11) <= 1)
            {
                return GangConstants.RARE_WEAPONS[rnd.Next(GangConstants.RARE_WEAPONS.Count)];
            }

            return GangConstants.WEAPONS[rnd.Next(GangConstants.WEAPONS.Count)];
        }


    }
}
