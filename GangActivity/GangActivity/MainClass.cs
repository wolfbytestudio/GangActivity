using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rage;
using LSPD_First_Response.Mod.API;
using GangActivity.callouts;
using System.Reflection;

[assembly: Rage.Attributes.Plugin("Gang Activity", Author = "Optimum & HazeMate", Description = "The gang activity mod")]
namespace GangActivity
{
    /// <summary>
    /// The main class itself, extends plugin
    /// </summary>
    public class MainClass : Plugin
    {

        /// <summary>
        /// Constructor, calls base
        /// </summary>
        public MainClass() : base() { }
        
        /// <summary>
        /// Initializes the 
        /// </summary>
        public override void Initialize()
        {

            Functions.OnOnDutyStateChanged += OnOnDutyStateChanged;

            Game.LogTrivial(Constants.PLUGIN_NAME);
            int num = (int)Game.DisplayNotification(
                Constants.PLUGIN_NAME + " by ~r~ Optimum & HazeMate ~w~has loaded! ~g~V" 
                + Constants.PLUGIN_VERSION);

            AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(LSPDFRResolveEventHandler);
        }


        public static Assembly LSPDFRResolveEventHandler(object sender, ResolveEventArgs args)
        {
            foreach (Assembly assembly in Functions.GetAllUserPlugins())
            {
                if (args.Name.ToLower().Contains(assembly.GetName().Name.ToLower()))
                    return assembly;
            }
            return (Assembly)null;
        }

        /// <summary>
        /// Registers the callouts
        /// </summary>
        /// <param name="onDuty"></param>
        internal void OnOnDutyStateChanged(bool onDuty)
        {
            if (!onDuty)
                return;

            Functions.RegisterCallout(typeof(GangShooting));
        }

        public override void Finally()
        {
        }
    }
}
