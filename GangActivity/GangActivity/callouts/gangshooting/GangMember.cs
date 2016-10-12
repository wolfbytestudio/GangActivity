using Rage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GangActivity.callouts.gangshooting
{
    public class GangMember
    {

        /// <summary>
        /// The gang Member
        /// </summary>
        public Ped member { get; set; }

        /// <summary>
        /// The members blip
        /// </summary>
        public Blip blip { get; set; }

        /// <summary>
        /// The type of gang member
        /// </summary>
        public GangTypes type { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="member">The gang members ped object</param>
        /// <param name="blip">The gang members blip</param>
        public GangMember(Ped member, GangTypes type)
        {
            this.member = member;
            blip = member.AttachBlip();
            blip.Color = GangUtil.getGangColour(type);
            this.type = type;
        }

        /// <summary>
        /// Spawns the player with items
        /// </summary>
        public void spawn()
        {
            member.Inventory.GiveNewWeapon(GangUtil.getRandomWeapon(), 500, true);
            member.BlockPermanentEvents = false;
            member.CanBeTargetted = true;
        }

        /// <summary>
        /// Removes the member
        /// </summary>
        public void remove()
        {
            if(EntityExtensions.Exists((IHandleable)this.member))
            {
                ((Entity)this.member).Dismiss();
            }
                  
        }
    }
}
