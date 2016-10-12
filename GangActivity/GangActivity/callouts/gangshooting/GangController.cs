using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GangActivity.callouts.gangshooting
{
    public class GangController
    {

        /// <summary>
        /// The battle object
        /// </summary>
        private GangBattle battle;
        
        /// <summary>
        /// Initializes the battle
        /// </summary>
        public void initializeBattle()
        {
            battle = new GangBattle(GangTypes.Ballas, GangTypes.The_Lost_MC);
            battle.start();
        }

        /// <summary>
        /// Checks if the battle is over
        /// </summary>
        /// <returns></returns>
        public bool battleOver()
        {
            return battle.nobodyLeft();
        }

        /// <summary>
        /// Process
        /// </summary>
        public void process()
        {
            if(battleOver())
            {
                GangShooting.battleOver = true;
            }
            else
            {
                battle.removeDeadBlips();
            }
        }

        /// <summary>
        /// Finishes the battle
        /// </summary>
        public void finishBattle()
        {
            battle.removeEverything();
        }
    }
}
