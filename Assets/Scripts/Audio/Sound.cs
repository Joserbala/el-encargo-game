using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound
{

    public bool loop;
    public bool ignoreListenerPause;
    [Range(0f, 1f)] public float volume;
    public string soundName;
    public AudioClip clip;
    public AudioMixerGroup group;

    [HideInInspector] public AudioSource source;
}
