using GearBox.Models;
using Il2CppAssets.Scripts.PeroTools.Commons;
using Il2CppAssets.Scripts.PeroTools.Managers;
using Il2CppFormulaBase;
using MuseDashMirror.Attributes;
using UnityEngine;

namespace GearBox.Managers;

internal static partial class ModManager
{
    public static readonly StageBattleComponent StageBattleComponent = Singleton<StageBattleComponent>.instance;

    public static readonly AudioManager AudioManager = Singleton<AudioManager>.instance;

    [PnlMenuToggle("GearBoxToggle", "GearBox", nameof(SettingsManager.IsEnabled))]
    internal static GameObject EnableToggle { get; set; }
    
    [PnlMenuToggle("GearBoxPitchToggle", "GearBox Pitch", nameof(SettingsManager.KeepPitch))]
    internal static GameObject PitchToggle { get; set; }

    internal static GameObject RateSlider { get; set; }

    internal static PitchChanger PitchChangerComp { get; set; }
}