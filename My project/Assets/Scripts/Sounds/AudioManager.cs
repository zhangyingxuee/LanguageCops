using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public Sound[] sounds;
    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        { 
            instance = this;
        }
        else
        { 
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        foreach (Sound s in sounds)
        { 
            // Set up the Audio Source to be our input one
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.loop = s.loop;
        }
        
    }

    void Start()
    { 
        Play("tryout");
    }

    // Update is called once per frame
    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name ==name);
        if (s == null)
        { 
            Debug.LogWarning("Sound " + s.name + " wasn't found");
            return;
        }
        s.source.Play();
    }

    public void Stop(string name)
    { 
        Sound s = Array.Find(sounds, sound => sound.name ==name);
        if (s == null)
        { 
            return;
        }
        s.source.Stop();
    }
}
