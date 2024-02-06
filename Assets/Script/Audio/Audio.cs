using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Audio;
using UnityEngine.UI;

public class Audio : MonoBehaviour
{
    public AudioMixer masterMixer;

    public Slider BGSlider;
    public Slider EFSlider;
    public Slider CLSlider;

    private static float BG_sound;
    private static float EF_sound;
    private static float CL_sound;

    float sound;

    private void Awake()
    {
        AudioManager.Instance.PlayBGSound("Main");
    }

    public void AudioControl(string parameter)
    {
        switch (parameter)
        {
            case "BGSound": sound = BGSlider.value; BG_sound = sound;  break;
            case "EFSound": sound = EFSlider.value; EF_sound = sound;  break;
            case "CLSound": sound = CLSlider.value; CL_sound = sound;  break;
        }

        if (sound == -40f) masterMixer.SetFloat(parameter, -80);
        else masterMixer.SetFloat(parameter, sound);
    }

    public void AudioVolume()
    {
        BGSlider.value = BG_sound;
        EFSlider.value = EF_sound;
        CLSlider.value = CL_sound;
    }

    private void Update()
    {
        AudioVolume();
    }
}
