using GearBox.Properties;
using MelonLoader;

namespace GearBox.Managers;

using static MelonBuildInfo;

internal static class SettingsManager
{
    private const string SettingsPath = $"UserData/{ModName}.cfg";

    internal const int ScaledDefinition = 5;

    internal const int LowerScaledRate = 50;

    internal const int HigherScaledRate = 200;

    private static MelonPreferences_Entry<bool> _isEnabled;

    private static MelonPreferences_Entry<bool> _keepPitch;

    private static MelonPreferences_Entry<int> _scaledRate;

    internal static bool IsEnabled
    {
        get => _isEnabled.Value && ScaledRate != 100;
        set => _isEnabled.Value = value;
    }

    internal static bool KeepPitch
    {
        get => _keepPitch.Value;
        set => _keepPitch.Value = value;
    }

    internal static float Rate => (float)ScaledRate / 100;

    internal static int ScaledRate
    {
        get => _scaledRate.Value;
        set => _scaledRate.Value = RoundToDefinition(value);
    }

    private static int RoundToDefinition(int value)
    {
        return value / ScaledDefinition * ScaledDefinition;
    }

    private static void VerifyRate()
    {
        var originalScaledRate = ScaledRate;
        ScaledRate = Math.Clamp(ScaledRate, LowerScaledRate, HigherScaledRate);

        if (originalScaledRate == ScaledRate) return;
        Melon<Main>.Logger.Warning($"ScaledRate outside of bounds.\nMin: {LowerScaledRate}, Max: {HigherScaledRate}");
    }

    internal static void Load()
    {
        var mainCategory = MelonPreferences.CreateCategory(ModName);
        mainCategory.SetFilePath(SettingsPath, true, false);

        _isEnabled = mainCategory.CreateEntry(nameof(IsEnabled), true);
        _keepPitch = mainCategory.CreateEntry(nameof(KeepPitch), true);
        _scaledRate = mainCategory.CreateEntry(nameof(Rate), 150,
            description: $"Percentage \nMin: {LowerScaledRate}, Max: {HigherScaledRate}");
        
        VerifyRate();
    }
}