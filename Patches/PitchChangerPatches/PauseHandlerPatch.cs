using GearBox.Managers;
using HarmonyLib;
using Il2CppFormulaBase;

namespace GearBox.Patches;

[HarmonyPatch(typeof(StageBattleComponent))]
internal static class PauseHandlerPatch
{
    [HarmonyPatch(nameof(StageBattleComponent.Pause))]
    [HarmonyPrefix]
    internal static void SbcPausePostfix()
    {
        if (!SettingsManager.IsEnabled) return;

        if (!ModManager.PitchChangerComp) return;

        ModManager.PitchChangerComp.enabled = false;
    }

    [HarmonyPatch(nameof(StageBattleComponent.Resume))]
    [HarmonyPostfix]
    internal static void SbcResumePostfix()
    {
        if (!SettingsManager.IsEnabled) return;

        if (!ModManager.PitchChangerComp) return;

        ModManager.PitchChangerComp.enabled = true;
    }
}