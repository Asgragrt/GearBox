using GearBox.Managers;
using HarmonyLib;
using Il2CppFormulaBase;
using UnityEngine;

namespace GearBox.Patches.PitchChangerPatches;

[HarmonyPatch(typeof(StageBattleComponent))]
internal static class OffsetPatch
{
    [HarmonyPatch(nameof(StageBattleComponent.getMusicOffset), MethodType.Getter)]
    [HarmonyPostfix]
    internal static void MusicOffset(ref int __result)
    {
        if (!SettingsManager.IsEnabled) return;

        if (!ModManager.PitchChangerComp) return;

        // Add offset
        __result += AudioSettings.GetConfiguration().dspBufferSize * ModManager.PitchChangerComp.DelayCounter;
    }
}