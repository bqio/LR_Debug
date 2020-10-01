using System.Reflection;
using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using HarmonyLib;

namespace LR_Debug
{
    [BepInPlugin(GUID, NAME, VERSION)]
    public class Main : BaseUnityPlugin
    {
        public const string GUID = "langrisser.russia.lrdebug";
        public const string NAME = "Langrisser Remake Debug";
        public const string VERSION = "1.0.0";

        public static ManualLogSource Log = new ManualLogSource(NAME);
        public static ConfigEntry<bool> Enabled;
        public static ConfigEntry<int> DebugScenario;

        public void Awake()
        {
            Enabled = Config.Bind("General", "Enabled", true, "If Enabled, then plugin is enabled.");
            DebugScenario = Config.Bind("General", "Debug_Scenario", 1);

            if (Enabled.Value)
            {
                BepInEx.Logging.Logger.Sources.Add(Log);

                var harmony = new Harmony(GUID);
                var assembly = Assembly.GetExecutingAssembly();
                harmony.PatchAll(assembly);

                Log.LogDebug("Initialized.");
            }
        }
    }
}
