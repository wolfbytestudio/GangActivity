using Rage;
using Rage.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GangActivity.callouts.gangshooting
{
    /// <summary>
    /// A gang team contains a team of gang members
    /// </summary>
    public class GangTeam
    {

        /// <summary>
        /// The type of gang
        /// </summary>
        public GangTypes type { get; set; }

        /// <summary>
        /// The team of members
        /// </summary>
        public List<GangMember> team { get; set; }

        /// <summary>
        /// The ped leader
        /// </summary>
        public Ped leader;

        /// <summary>
        /// Gang Team
        /// </summary>
        /// <param name="type"></param>
        public GangTeam(GangTypes type)
        {
            this.type = type;
        }

        /// <summary>
        /// Adds a member to the list
        /// </summary>
        /// <param name="member"></param>
        public void addMember(GangMember member)
        {
            if (team == null) team = new List<GangMember>();
            if (team.Count >= 7) return;

            member.type = type;
            team.Add(member);
        }

        /// <summary>
        /// Generates a team of people
        /// </summary>
        public void generateTeam()
        {
            int amount = 1 + random.Next(GangConstants.MAX_MEMBERS_PER_TEAM);
            for(int i = 0; i < amount; i++)
            {
                GangMember member = new GangMember(new Ped(GangUtil.getRandomModel(type), GangConstants.location, 0F), type);
                member.member.CanAttackFriendlies = false;
                addMember(member);
            }

            leader = team[0].member;

            foreach (GangMember ped in team)
            {
                if (ped.member == null) continue;
                try
                {
                    leader.Group.AddMember(ped.member);
                }
                catch(Exception e)
                {
                    
                }
                
            }
        }

        /// <summary>
        /// Spawns the team
        /// </summary>
        public void spawnTeam()
        {
            foreach (GangMember m in team)
            {
                m.spawn();
            }
        }

        /// <summary>
        /// Random object for generating random numbers
        /// </summary>
        public static Random random = new Random();

        /// <summary>
        /// Get's and assigns a target
        /// </summary>
        /// <param name="opps"></param>
        public void getTarget(GangTeam opps)
        {
            foreach (GangMember m in team)
            {
                if (m == null) continue;
                
                Ped randomPedInOpps = opps.team[random.Next(opps.team.Count)].member;
                randomPedInOpps.Tasks.FireWeaponAt(randomPedInOpps.Position, 100000, FiringPattern.SingleShot);
            }
        }

        /// <summary>
        /// Removes all the dead members from the minimap
        /// </summary>
        public void removeDead()
        {
            for (int i = 0; i < team.Count; i++)
            {
                if (team[i].member.IsDead)
                {
                    team[i].remove();
                }
            }
        }

        /// <summary>
        /// Removed everyone
        /// </summary>
        public void removeAll()
        {
            foreach (GangMember m in team)
            {
                m.remove();
            }
        }


    }
}
