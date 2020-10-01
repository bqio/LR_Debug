using HarmonyLib;
using Newtonsoft.Json;
using System.IO;
using UnityEngine;

namespace LR_Debug.Patches
{
    [HarmonyPatch(typeof(GameMain), "Update")]
    [HarmonyPriority(Priority.Last)]
    class Dump
    {
        static void Postfix(GameMain __instance)
        {
            if (Input.GetKeyDown(KeyCode.Keypad3))
            {
                if (__instance.gameMode == 3300)
                {
                    Directory.CreateDirectory("data/raw");
                    int lang = __instance.gameSystemWork.gameSelect;
                    Main.Log.LogDebug($"Dumping L{lang} data...");

                    DumpData("data/raw/scenarioInfoData.json", __instance.scenarioInfoData);
                    DumpData("data/raw/charaData.json", __instance.unitManager.charaData);
                    DumpData($"data/raw/eventData_{lang}.json", __instance.eventData);
                    DumpData($"data/raw/eventMessageData_{lang}.json", Traverse.CreateWithType("StData").Field("eventMessageList").GetValue<EventMessageList>());
                    DumpData($"data/raw/scenarioUnitList_{lang}.json", __instance.scenarioUnitList);
                    DumpData($"data/raw/classTree.json", __instance.unitManager.classTreeData);
                    DumpData($"data/raw/classData.json", __instance.unitManager.classData);
                    DumpData($"data/raw/itemData.json", __instance.unitManager.itemData);
                    DumpData($"data/raw/weaponData.json", __instance.unitManager.weaponData);
                    DumpData($"data/raw/skillData.json", __instance.unitManager.skillData);
                    DumpData($"data/raw/magicData.json", __instance.unitManager.magicData);
                    DumpData($"data/raw/levelUpPattern.json", __instance.unitManager.levelUpData);
                    DumpData($"data/raw/impactAreaData.json", __instance.unitManager.impactAreaData);
                    DumpData($"data/raw/unitAnimationList.json", __instance.unitManager.unitAnimeData);
                    DumpData($"data/raw/bgmData.json", __instance.soundCTRL.bgmData);

                    Main.Log.LogDebug("Done.");
                }
                else
                {
                    Main.Log.LogDebug("Wait game mode 3300.");
                }
            }
        }

        static void DumpData<T>(string filename, T obj)
        {
            Main.Log.LogDebug($"Dumpinng {filename}...");

            using (StreamWriter streamWriter = File.CreateText(filename))
            {
                JsonSerializer jsonSerializer = new JsonSerializer
                {
                    Formatting = Formatting.Indented
                };
                jsonSerializer.Serialize(streamWriter, obj);
            }
        }
    }
}
