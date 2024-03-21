using GearBox.Managers;
using Il2CppAssets.Scripts.PeroTools.Commons;
using Il2CppAssets.Scripts.PeroTools.Managers;
using MelonLoader;
using UnityEngine;

namespace GearBox;

public partial class Main : MelonMod
{
    public override void OnInitializeMelon()
    {
        SettingsManager.Load();
        LoggerInstance.Msg("GearBox has loaded correctly!");
    }

    public override void OnSceneWasLoaded(int buildIndex, string sceneName)
    {
        //Restart audio speed
        Singleton<AudioManager>.instance.bgm.pitch = 1f;

        //Restart game speed
        Time.timeScale = 1f;
    }
}