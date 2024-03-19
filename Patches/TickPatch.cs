using GearBox.Managers;
using HarmonyLib;
using Il2CppFormulaBase;
using Decimal = Il2CppSystem.Decimal;

namespace GearBox.Patches;


[HarmonyPatch(typeof(StageBattleComponent))]
internal static class TickPatch
{
    // Tick rate change
    [HarmonyPatch(nameof(StageBattleComponent.timeFromMusicStart), MethodType.Getter)]
    [HarmonyPostfix]
    internal static void TimeStartPostfix(ref float __result)
    {
        if (!SettingsManager.IsEnabled) return;

        __result *= SettingsManager.Rate;
    }

    // Holds rate
    [HarmonyPatch(nameof(StageBattleComponent.timeFromMusicStartDecimal), MethodType.Getter)]
    [HarmonyPostfix]
    internal static void TimeStartDecPostfix(ref Decimal __result)
    {
        if (!SettingsManager.IsEnabled) return;

        __result *= (Decimal)SettingsManager.Rate;
    }
}