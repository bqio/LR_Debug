using HarmonyLib;
using UnityEngine;

namespace LR_Debug.Patches
{
    [HarmonyPatch(typeof(GameMain), "Update")]
    [HarmonyPriority(Priority.First)]
    class Info
    {
        static void Postfix(GameMain __instance)
        {
            if (Input.GetKeyDown(KeyCode.Keypad1))
            {
                Main.Log.LogDebug($"Game mode: {__instance.gameMode}");
                Main.Log.LogDebug($"Cursor: [{__instance.gameSystemWork.mapCursol_X}, {__instance.gameSystemWork.mapCursol_Y}]");
            }
        }
    }
}
