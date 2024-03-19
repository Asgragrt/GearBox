using GearBox.Managers;
using HarmonyLib;
using Il2CppAccount;

namespace GearBox.Patches;

[HarmonyPatch(typeof(GameAccountSystem), nameof(GameAccountSystem.UploadScore))]
internal static class ScorePatch
{
    internal static bool Prefix()
    {
        return !SettingsManager.IsEnabled;
    }
}