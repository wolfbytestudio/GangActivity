using LSPD_First_Response.Mod.Callouts;
using Rage;
using System;
using LSPD_First_Response.Mod.API;
using Rage.Native;
using System.Drawing;
using System.Threading;
using GangActivity.callouts.gangshooting;

namespace GangActivity.callouts
{
    [CalloutInfo("Gang Activity", CalloutProbability.VeryHigh)]
    public class GangShooting : Callout
    {

        private GangController controller;

        public override bool OnBeforeCalloutDisplayed()
        {
            GangConstants.location = World.GetNextPositionOnStreet(Game.LocalPlayer.Character.Position.Around(300F));
            this.ShowCalloutAreaBlipBeforeAccepting(GangConstants.location, 50f);
            this.CalloutPosition = GangConstants.location;
            this.CalloutMessage = "Gang Shooting";
            Functions.PlayScannerAudioUsingPosition("ATTENTION_ALL_UNITS WE_HAVE IN_OR_ON_POSITION CODE3 END_BEEP", Game.LocalPlayer.Character.Position);
            controller = new GangController();

            return base.OnBeforeCalloutDisplayed();
        }


        public static bool battleOver;
        

        public override void Process()
        {
            if(Game.LocalPlayer.Character.IsDead)
            {
                this.End();
                return;
            }
            
            controller.process();
        }

        /// <summary>
        /// What happens when you accept the callout
        /// </summary>
        /// <returns></returns>
        public override bool OnCalloutAccepted()
        {
            controller.initializeBattle();
            Blip loc = new Blip(GangConstants.location, 3);
            loc.EnableRoute(Color.Gold);
            Game.DisplaySubtitle("~b~Dispatch~w~: A Gang Shooting has occured, please respond ASAP");
            return base.OnCalloutAccepted();
        }

        public override void OnCalloutNotAccepted()
        {
            base.OnCalloutNotAccepted();
        }

        /// <summary>
        /// End
        /// </summary>
        public override void End()
        {
            controller.finishBattle();
            Game.DisplayNotification("The gang war has ended!");
            base.End();
        }

    }
}
