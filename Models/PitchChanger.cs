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

    internal int DelayCounter { get; private set; }

    public void Awake()
    {
        var clip = ModManager.AudioManager.bgm.clip;
        _soundTouchProcessor = new SoundTouchProcessor
        {
            Channels = clip.channels,
            SampleRate = clip.frequency,
            Pitch = 1f / SettingsManager.Rate
        };
    }

    public void OnAudioFilterRead(Il2CppStructArray<float> data, int channels)
    {
        try
        {
            if (_soundTouchProcessor is null) return;

            var samples = data.Length / channels;
            var arrayData = data.ToArray();
            _soundTouchProcessor.PutSamples(arrayData, samples);

            DelayCounter += _soundTouchProcessor.AvailableSamples == 0 ? 1 : 0;

            _soundTouchProcessor.ReceiveSamples(arrayData, samples);
            for (var i = 0; i < data.Length; i++) data[i] = arrayData[i];
        }
        catch (Exception e)
        {
            Melon<Main>.Logger.Error(e.ToString());
        }
    }

    public void Flush()
    {
        _soundTouchProcessor?.Clear();
        enabled = false;
    }


    public void ClearCounter()
    {
        DelayCounter = 0;
    }

    public void UpdatePitch()
    {
        if (_soundTouchProcessor is null) return;
        _soundTouchProcessor.Pitch = 1f / SettingsManager.Rate;
    }
}