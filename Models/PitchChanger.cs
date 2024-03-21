using GearBox.Managers;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using MelonLoader;
using SoundTouch;
using UnityEngine;

namespace GearBox.Models;

[RegisterTypeInIl2Cpp]
internal class PitchChanger : MonoBehaviour
{
    private SoundTouchProcessor _soundTouchProcessor;

    public PitchChanger(IntPtr ptr) : base(ptr)
    {
    }

    public void Start()
    {
        Melon<Main>.Logger.Msg("New Component Start");
        _soundTouchProcessor = new SoundTouchProcessor
        {
            Channels = 2,
            SampleRate = ModManager.AudioManager.bgm.clip.frequency,
            Pitch = 1f / SettingsManager.Rate
        };
    }

    public void OnAudioFilterRead(Il2CppStructArray<float> data, int channels)
    {
        //var a = Singleton<AudioManager>.instance.bgm;
        //var b = ModManager.StageBattleComponent;
        //var c = a.time;
        //var d = b.timeFromMusicStart;
        //var es = b.timeFromMusicStartDecimal;
        //Melon<Main>.Logger.Msg($"A - {c:F3} - {d:F3} - {d-c:F3} - {es}");

        try
        {
            if (_soundTouchProcessor is null) return;
            
            var samples = data.Length / channels;
            var arrayData = data.ToArray();
            _soundTouchProcessor.PutSamples(arrayData, samples);
            _soundTouchProcessor.ReceiveSamples(arrayData, samples);
            for (var i = 0; i < data.Length; i++) data[i] = arrayData[i];
        }
        catch (Exception e)
        {
            Melon<Main>.Logger.Msg(e.ToString());
        }
    }

    public void UpdatePitch()
    {
        if (_soundTouchProcessor is null) return;
        _soundTouchProcessor.Pitch = 1f / SettingsManager.Rate;
    }
}