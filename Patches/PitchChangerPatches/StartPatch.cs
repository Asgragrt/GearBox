using GearBox.Managers;
using GearBox.Models;
using HarmonyLib;
using Il2CppAssets.Scripts.PeroTools.Commons;
using Il2CppAssets.Scripts.PeroTools.Managers;
using Il2CppFormulaBase;

namespace GearBox.Patches;

[HarmonyPatch(typeof(StageBattleComponent), nameof(StageBattleComponent.GameStart))]
internal static class StartPatch
{
    internal static void Postfix()
    {
        if (!SettingsManager.IsEnabled) return;

        var audioGame = Singleton<AudioManager>.instance.bgm.gameObject;
        ModManager.PitchChangerComp = audioGame.TryGetComponent<PitchChanger>(out var pitchChanger)
            ? pitchChanger
            : audioGame.AddComponent<PitchChanger>();
        ModManager.PitchChangerComp.UpdatePitch();
        ModManager.PitchChangerComp.enabled = true;
    }
}