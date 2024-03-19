using GearBox.Managers;
using HarmonyLib;
using Il2CppAssets.Scripts.UI.Panels;
using System.Reflection;
using Il2CppAssets.Scripts.PeroTools.Commons;
using Il2CppAssets.Scripts.PeroTools.Managers;
using UnityEngine;

namespace GearBox.Patches;

//[HarmonyPatch(typeof(PnlBattle), nameof(PnlBattle.BattleStart))]
[HarmonyPatch]
internal static class TimeScalePatch
{
    internal static IEnumerable<MethodBase> TargetMethods()
    {
        return typeof(PnlBattle).GetMethods().Where(m => m.Name.Equals(nameof(PnlBattle.OnStageStart)));
    }
    
    internal static void Postfix()
    {
        if (!SettingsManager.IsEnabled) return;
        
        Time.timeScale = SettingsManager.Rate;
        Singleton<AudioManager>.instance.bgm.pitch = SettingsManager.Rate;
    }
}