using GearBox.Managers;
using HarmonyLib;
using Il2Cpp;
using Il2CppFormulaBase;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using Object = Il2CppSystem.Object;

namespace GearBox.Patches;

[HarmonyPatch]
internal static class StopPatch
{
    [HarmonyPatch(typeof(StageBattleComponent), nameof(StageBattleComponent.Exit))]
    [HarmonyPostfix]
    internal static void SBCExitPostfix()
    {
        if (!SettingsManager.IsEnabled) return;

        if (!ModManager.PitchChangerComp) return;

        ModManager.PitchChangerComp.enabled = false;
    }

    [HarmonyPatch(typeof(PnlVictory), nameof(PnlVictory.OnVictory), typeof(Object), typeof(Object),
        typeof(Il2CppReferenceArray<Object>))]
    [HarmonyPrefix]
    internal static void PnlVPostfix()
    {
        if (!SettingsManager.IsEnabled) return;

        if (!ModManager.PitchChangerComp) return;

        ModManager.PitchChangerComp.enabled = false;
    }
}