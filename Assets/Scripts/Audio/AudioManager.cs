using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private List<Sound> sounds;
    [SerializeField] private List<Sound> music;

    public static AudioManager audioManager;

    private void Awake()
    {
        for (int i = 0; i < sounds.Count; i++)
        {
            sounds[i].source = gameObject.AddComponent<AudioSource>();

            sounds[i].source.clip = sounds[i].clip;
            sounds[i].source.loop = sounds[i].loop;
            sounds[i].source.ignoreListenerPause = sounds[i].ignoreListenerPause;
            sounds[i].source.outputAudioMixerGroup = sounds[i].group;
            sounds[i].source.volume = sounds[i].volume;
        }
    }

    public void Play(string name, bool isMusic = false)
    {
        Sound sound;

        if (isMusic)
            sound = music.Find(s => s.soundName == name); // TODO: stop playing previous track?
        else
            sound = sounds.Find(s => s.soundName == name);

        if (sound == null)
            Debug.LogError("Sound " + name + " not found.");
        else
            sound.source.Play();
    }
}
