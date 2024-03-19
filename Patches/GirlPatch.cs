using GearBox.Managers;
using HarmonyLib;
using Il2Cpp;
using MelonLoader;

namespace GearBox.Patches;

[HarmonyPatch]
internal static class GirlPatch
{
    [HarmonyPatch(typeof(GirlActionController), nameof(GirlActionController.Init))]
    [HarmonyPostfix]
    internal static void GirlActionControllerPostfix(GirlActionController __instance)
    {
        if (!SettingsManager.IsEnabled) return;

        if (__instance.animator)
        {
            __instance.animator.speed *= SettingsManager.Rate;
        }

        if (__instance.spineActionCtrl.m_SkeletonAnimation)
        {
            __instance.spineActionCtrl.m_SkeletonAnimation.timeScale *= SettingsManager.Rate;
        }
    }
}