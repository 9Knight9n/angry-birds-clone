using UnityEngine.Audio;
using System;
using UnityEngine;


public class AudioManager : MonoBehaviour
{

    public Sound[] sounds;
    void Awake()
    {
        foreach (Sound s in sounds)
        {
            Debug.Log("gameObj = " + gameObject );
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }
        
    }

    public void Play(string soundName)
    {
        Sound s = Array.Find(sounds, sound => sound.name == soundName);
        if (s != null)
        {
            s.source.Play();
        }else return;
            
    }
}
