using System.Diagnostics;
using GearBox.Managers;
using HarmonyLib;
using Il2CppAssets.Scripts.Database;
using Il2CppFormulaBase;
using UnityEngine;
using Random = System.Random;

namespace GearBox.Patches;

[HarmonyPatch(typeof(StageBattleComponent))]
internal static class ApplyOffset
{
    [HarmonyPatch(nameof(StageBattleComponent.getMusicOffset), MethodType.Getter)]
    [HarmonyPostfix]
    internal static void MusicOffset(ref int __result)
    {
        if (!SettingsManager.IsEnabled) return;

        if (!ModManager.PitchChangerComp) return;

        var offset = AudioSettings.GetConfiguration().dspBufferSize * ModManager.PitchChangerComp.DelayCounter;
        var original = __result;
        __result += offset;
        MelonLoader.Melon<Main>.Logger.Msg($"Music offset: {original} - {__result}");
        //ModManager.PitchChangerComp.enabled = true;
    }
}