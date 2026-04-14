using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class VolumeManager : MonoBehaviour
{
    public Slider slider;
    
    public void SetVolume(float volume)
    {
        volume = Mathf.Clamp01(volume);
        
        AudioListener.volume = volume;
        PlayerPrefs.SetFloat("volume", volume);
    }

    void Start()
    {
        float saved = PlayerPrefs.GetFloat("volume", 1);
        
        AudioListener.volume = saved;
        slider.value = saved;
    }
}
