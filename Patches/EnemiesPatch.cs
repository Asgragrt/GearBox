using GearBox.Managers;
using HarmonyLib;
using Il2Cpp;

namespace GearBox.Patches;


[HarmonyPatch(typeof(BaseEnemyObjectController))]
internal static class EnemiesPatch
{
    // Normal enemy anim rate change
    [HarmonyPatch(nameof(BaseEnemyObjectController.Init))]
    [HarmonyPostfix]
    internal static void InitPostfix(BaseEnemyObjectController __instance)
    {
        if (!SettingsManager.IsEnabled) return;

        if (!__instance.m_SkeletonAnimation) return;

        __instance.m_SkeletonAnimation.timeScale *= SettingsManager.Rate;
    }
}
