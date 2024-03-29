using GearBox.Managers;
using HarmonyLib;
using Il2CppFormulaBase;

namespace GearBox.Patches.PitchChangerPatches;

[HarmonyPatch(typeof(StageBattleComponent))]
internal static class StopPatch
{
    [HarmonyPatch(nameof(StageBattleComponent.Exit))]
    [HarmonyPostfix]
    internal static void ExitPostfix()
    {
        if (!SettingsManager.IsEnabled) return;

        if (!ModManager.PitchChangerComp) return;

        ModManager.PitchChangerComp.enabled = false;
    }

    [HarmonyPatch(nameof(StageBattleComponent.End))]
    [HarmonyPrefix]
    internal static void EndPrefix()
    {
        if (!SettingsManager.IsEnabled) return;

        if (!ModManager.PitchChangerComp) return;

        ModManager.PitchChangerComp.enabled = false;
    }

    [HarmonyPatch(nameof(StageBattleComponent.Dead))]
    [HarmonyPrefix]
    internal static void DeadPrefix()
    {
        if (!SettingsManager.IsEnabled) return;

        if (!ModManager.PitchChangerComp) return;

        ModManager.PitchChangerComp.enabled = false;
    }
}