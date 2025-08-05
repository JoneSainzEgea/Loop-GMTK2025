using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour
{
    [SerializeField] public Sounds[] sounds;

    public static AudioManager instance;

    private float generalVolume = 1.0f;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        foreach (Sounds s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume * generalVolume; 
            s.source.pitch = s.tone;
            s.source.loop = s.loop;
        }
    }

    private void Start()
    {
        //Play("MainTheme");
    }

    public void Play(string soundName)
    {
        Sounds s = Array.Find(sounds, sound => sound.name == soundName);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + soundName + " not found.");
            return;
        }
        if(s.stopsOtherSounds)
            StopAllSounds();
        s.source.Play();
    }

    public void StopAllSounds()
    {
        foreach (Sounds s in sounds)
        {
            s.source.Stop();
        }
    }
}
