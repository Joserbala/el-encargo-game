using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{

    [SerializeField] private AudioMixer audioMixer;

    /// <summary>
    /// Setting the Music Volume.
    /// </summary>
    /// <param name="volume">The volume to be set. It has to be a value between 0.0001 and 1.</param>
    public void SetMusicVolume(float volume)
    {
        audioMixer.SetFloat("MusicVolume", Mathf.Log10(volume) * 20);
    }

    /// <summary>
    /// Setting the Sounds Volume.
    /// </summary>
    /// <param name="volume">The volume to be set. It has to be a value between 0.0001 and 1.</param>
    public void SetSoundsVolume(float volume)
    {
        audioMixer.SetFloat("SoundsVolume", Mathf.Log10(volume) * 20);
    }
}
