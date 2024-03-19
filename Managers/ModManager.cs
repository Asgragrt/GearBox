using MuseDashMirror.Attributes;
using UnityEngine;

namespace GearBox.Managers;

internal static partial class ModManager
{
    [PnlMenuToggle("GearBoxToggle", "GearBox", nameof(SettingsManager.IsEnabled))]
    internal static GameObject EnableToggle { get; set; }

    internal static GameObject RateSlider { get; set; }
}