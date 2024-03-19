using GearBox.Managers;
using HarmonyLib;
using Il2CppAssets.Scripts.PeroTools.Commons;
using Il2CppAssets.Scripts.PeroTools.Managers;
using Il2CppFormulaBase;
using UnityEngine;

namespace GearBox.Patches;

[HarmonyPatch(typeof(StageBattleComponent), nameof(StageBattleComponent.GameStart))]
internal static class SongPatch
{
    internal static void Postfix()
    {
        if (!SettingsManager.IsEnabled) return;
        
        //Singleton<AudioManager>.instance.bgm.pitch = SettingsManager.Rate;
    }
}