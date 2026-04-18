using UnityEngine;
using UnityEngine.Audio;

public class VolumeManager : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    private const string MasterVolumeParam = "MasterVolume";

    public void SetMasterVolume(float volume)
    {
        // Slider 0-1 to dB range -80 to +20
        float dB = Mathf.Lerp(-80f, 0f, volume);
        audioMixer.SetFloat(MasterVolumeParam, dB);
    }
}