using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Rage;

namespace GangActivity.callouts.gangshooting
{
    public class GangConstants
    {
        public static Vector3 location;

        public static bool battleOver = false;


        /// <summary>
        /// The maximum amount of members per team
        /// </summary>
        public static readonly int MAX_MEMBERS_PER_TEAM = 14;

        /// <summary>
        /// All the gang colours
        /// </summary>
        public static readonly Dictionary<GangTypes, Color> GANG_COLOR = new Dictionary<GangTypes, Color>
        {
            { GangTypes.Ballas, Color.FromArgb(255, 49, 29, 106) },
            { GangTypes.The_Families, Color.FromArgb(255, 2, 74, 3)},
            { GangTypes.The_Lost_MC, Color.LightGray},
            { GangTypes.Vagos, Color.FromArgb(255, 255, 202, 16)}
        };

        /// <summary>
        /// A list of all possible weapons
        /// </summary>
        public static readonly List<WeaponHash> WEAPONS = new List<WeaponHash>()
        {
            WeaponHash.Pistol
        };

        /// <summary>
        /// A list of all rare items
        /// </summary>
        public static readonly List<WeaponHash> RARE_WEAPONS = new List<WeaponHash>()
        {
            WeaponHash.SawnOffShotgun,
            WeaponHash.MicroSMG
        };

        /// <summary>
        /// A list of all model names
        /// </summary>
        public static readonly Dictionary<GangTypes, List<string>> MODEL_NAMES = new Dictionary<GangTypes, List<string>>
        {
            { GangTypes.Ballas, new List<string>
                {
                    "csb_ballasog", "g_f_y_ballas_01",
                    "g_m_y_ballaeast_01", "g_m_y_ballaorig_01",
                    "g_m_y_ballasout_01", "ig_ballasog"
                }
            },
            { GangTypes.The_Families, new List<string>
                {
                    "g_m_y_famdnf_01", "g_m_y_famca_01",
                    "g_m_y_famfor_01", "mp_m_famdd_01"
                }
            },
            { GangTypes.The_Lost_MC, new List<string>
                {
                    "g_m_y_lost_01", "g_m_y_lost_02",
                    "g_f_y_lost_01", "g_m_y_lost_03"
                }
            },
            { GangTypes.Vagos, new List<string>
                {
                    "g_f_y_vagos_01", "g_m_y_mexgoon_01",
                    "g_m_y_mexgoon_02", "g_m_y_mexgoon_03",
                    "a_m_y_mexthug_01"
                }
            }
        };
        

    }
}
