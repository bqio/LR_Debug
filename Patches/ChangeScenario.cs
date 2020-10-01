using HarmonyLib;
using UnityEngine;

namespace LR_Debug.Patches
{
    [HarmonyPatch(typeof(GameMain), "Update")]
    [HarmonyPriority(Priority.Normal)]
    class ChangeScenario
    {
        static void Postfix(GameMain __instance)
        {
            if (Input.GetKeyDown(KeyCode.Keypad2))
            {
                if (__instance.gameMode == 3300)
                {
                    __instance.gameSystemWork.scenarioNumber = Main.DebugScenario.Value;
                    __instance.mapMainCTRL.ExitMapMain();
                    __instance.mapMainCTRL.gameMapMode = 2000;

                    Main.Log.LogDebug($"Changed scenario: {__instance.gameSystemWork.scenarioNumber}");
                }
                else
                {
                    Main.Log.LogDebug("Wait game mode 3300.");
                }
            }
        }
    }
}
