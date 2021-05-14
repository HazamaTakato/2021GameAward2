using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class VolumeScript : MonoBehaviour
{
    public AudioMixer mixer;
    public Slider bgmSlider;

    public static float BGMVolume;
    public static float SEVolume;

    void Example()
    {
        bgmSlider.GetComponent<Slider>();
        mixer.SetFloat("BGMVolume", bgmSlider.value);
    }

    void Update()
    {
        
    }

    public void SetBGM(float volume)
    {
        mixer.SetFloat("BGMVolume", volume);
        BGMVolume = volume;
    }
    public void SetSE(float volume)
    {
        mixer.SetFloat("SEVolume", volume);
        SEVolume = volume;
    }
}
