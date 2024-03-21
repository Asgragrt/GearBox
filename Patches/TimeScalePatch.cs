using GearBox.Managers;
using HarmonyLib;
using Il2CppFormulaBase;
using UnityEngine;

namespace GearBox.Patches;

[HarmonyPatch(typeof(StageBattleComponent), nameof(StageBattleComponent.GameStart))]
internal static class TimeScalePatch
{
    internal static void Postfix()
    {
        if (!SettingsManager.IsEnabled) return;

        Time.timeScale = SettingsManager.Rate;
    }
}