using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private List<Sound> sounds;
    [SerializeField] private List<Sound> music;

    public static AudioManager audioManager;

    private void Awake()
    {

        if (audioManager)
        {
            audioManager = this;

            foreach (var sound in sounds)
            {
                sound.source = gameObject.AddComponent<AudioSource>();

                sound.source.clip = sound.clip;
                sound.source.loop = sound.loop;
                sound.source.outputAudioMixerGroup = sound.group;
                sound.source.pitch = sound.pitch;
                sound.source.volume = sound.volume;
            }
        }
        else
            Destroy(gameObject);
    }

    public void Play(string name, bool isMusic)
    {
        Sound sound;

        if (isMusic)
            sound = music.Find(s => s.soundName == name);
        else
            sound = sounds.Find(s => s.soundName == name);

        if (sound == null)
            Debug.LogError("Sound " + name + " not found.");
        else
            sound.source.Play();
    }
}
