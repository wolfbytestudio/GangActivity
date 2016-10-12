using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GangActivity.callouts.gangshooting
{
    public class GangBattle
    {

        /// <summary>
        /// The first gang team
        /// </summary>
        private GangTeam firstGang;

        /// <summary>
        /// The second gang team
        /// </summary>
        private GangTeam secondGang;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="first">The first gang type</param>
        /// <param name="second">The second gang type</param>
        public GangBattle(GangTypes first, GangTypes second)
        {
            firstGang = new GangTeam(first);
            secondGang = new GangTeam(second);
        }

        /// <summary>
        /// Starts the battle
        /// </summary>
        public void start()
        {
            firstGang.generateTeam();
            secondGang.generateTeam();

            firstGang.spawnTeam();
            SecondGang.spawnTeam();

            if(firstGang.team.Count >= secondGang.team.Count)
            {
                firstGang.getTarget(secondGang);
            }
            else
            {
                secondGang.getTarget(firstGang);
            }
        }

        /// <summary>
        /// Checks if everyone is dead
        /// </summary>
        /// <returns></returns>
        public bool everyoneDead()
        {
            return (teamDead(firstGang) && teamDead(secondGang));
        }

        /// <summary>
        /// Checks if a team is dead
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        private bool teamDead(GangTeam t)
        {
            foreach(GangMember member in t.team)
            {
                if (member == null || !member.member.Exists()) continue;
                if(!member.member.IsDead)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Removes every team
        /// </summary>
        public void removeEverything()
        {
            removeTeam(firstGang);
            removeTeam(secondGang);

            firstGang = null;
            secondGang = null;
        }

        private void removeTeam(GangTeam t)
        {
            foreach (GangMember member in t.team)
            {
                if(member.member.Exists())
                {
                    member.blip.Delete();
                    member.member.Delete();
                }
                
            }
        }


        /// <summary>
        /// Removes the dead players blips
        /// </summary>
        public void removeDeadBlips()
        {
            firstGang.removeDead();
            secondGang.removeDead();
        }

        public bool nobodyLeft()
        {
            return (nobodyLeft(firstGang) && nobodyLeft(secondGang));
        }
        
        /// <summary>
        /// Checks if anyone is capable
        /// </summary>
        /// <param name="team"></param>
        /// <returns></returns>
        private bool nobodyLeft(GangTeam team)
        {
            foreach (GangMember g in team.team)
            {
                if (g.member.IsAlive) return false;
            }
            return true;
        }

        public GangTeam FirstGang
        {
            get { return firstGang; }
        }

        public GangTeam SecondGang
        {
            get { return secondGang; }
        }

    }
}
