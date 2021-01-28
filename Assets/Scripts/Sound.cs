using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound
{

    public bool loop;
    [Range(0.1f, 3f)] public float pitch;
    [Range(0f, 1f)] public float volume;
    public string soundName;
    public AudioClip clip;
    public AudioMixerGroup group;
    [HideInInspector] public AudioSource source;
}
