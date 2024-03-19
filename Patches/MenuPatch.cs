using GearBox.Managers;
using HarmonyLib;
using Il2Cpp;
using Il2CppAssets.Scripts.PeroTools.GeneralLocalization;
using Il2CppAssets.Scripts.PeroTools.Nice.Actions;
using Il2CppAssets.Scripts.PeroTools.Nice.Events;
using Il2CppAssets.Scripts.PeroTools.Nice.Interface;
using Il2CppAssets.Scripts.PeroTools.Nice.Variables;
using Il2CppAssets.Scripts.UI.Panels;
using MuseDashMirror.Extensions.UnityExtensions;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Text = UnityEngine.UI.Text;

namespace GearBox.Patches;

using static ModManager;
using static SettingsManager;

[HarmonyPatch(typeof(PnlMenu), nameof(PnlMenu.Awake))]
internal static class MenuPatch
{
    internal static void Postfix(PnlMenu __instance)
    {
        RateSlider = GameObject.Find("Forward").transform.Find("PnlVolume").Find("SldMusicVolume").gameObject
            .FastInstantiate(__instance.transform);
        RateSlider.name = "GearBoxRateSlider";


        var rateSliderChild = RateSlider.transform.GetChild(0).gameObject;
        var slider = rateSliderChild.GetComponent<Slider>();
        slider.onValueChanged.RemoveAllListeners();

        var sliderTextTag = slider.GetComponentInChildren<Text>();
        sliderTextTag.name = "SliderTextTag";
        sliderTextTag.text = "GearBox Rate: ";
        sliderTextTag.GetComponent<Localization>().Destroy();

        var sliderTagValue = sliderTextTag.transform.GetChild(0).GetComponent<Text>();
        sliderTagValue.name = "SliderTagValue";
        sliderTagValue.text = $"{Rate}";

        slider.minValue = LowerScaledRate;
        slider.maxValue = HigherScaledRate;
        slider.SetValueWithoutNotify(ScaledRate);
        slider.onValueChanged.AddListener((UnityAction<float>)
            ((float val) =>
            {
                ScaledRate = (int)val;
                slider.SetValueWithoutNotify(ScaledRate);
                sliderTagValue.text = $"{Rate}";
            })
        );

        var nextButton = RateSlider.transform.GetChild(1);
        // Remove onclickevent, keeping the audio
        nextButton.GetComponent<OnClick>().playables.RemoveAt(1);
        // Setting a new on click event
        nextButton.GetComponent<Button>().onClick.AddListener((UnityAction)(() =>
        {
            slider.Set(slider.value + ScaledDefinition);
        }));
        
        var prevButton = RateSlider.transform.GetChild(2);
        // Remove onclickevent, keeping the audio
        prevButton.GetComponent<OnClick>().playables.RemoveAt(1);
        // Setting a new on click event
        prevButton.GetComponent<Button>().onClick.AddListener((UnityAction)(() =>
        {
            slider.Set((int)slider.value - ScaledDefinition);
        }));


        rateSliderChild.GetComponent<OnSliderValueChanged>().Destroy();
        rateSliderChild.GetComponent<OnStart>().Destroy();

        RateSlider.transform.position = new Vector3(0, 3.2f, 100f);
        RateSlider.transform.SetParent(__instance.transform.Find("Panels").Find("PnlOption"));
    }
}