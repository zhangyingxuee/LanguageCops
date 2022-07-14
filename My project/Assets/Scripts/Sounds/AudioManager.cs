using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public Sound[] sounds;

    public AudioMixer audioMixer;

    private string toStop;
    private string toStart;
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
            s.source.outputAudioMixerGroup = s.output;
        }
        
    }

    void Start()
    { 
       Play("1");
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

    public void FadeIn()
    {
        Stop(toStop);
        Sound s = Array.Find(sounds, sound => sound.name ==toStart);
        if (s == null)
        { 
            Debug.LogWarning("Sound " + s.name + " wasn't found");
            return;
        }
        Play(toStart);
        StartCoroutine(FadeMixerGroup.StartFade(audioMixer, "vol", 0.75f, s.source.volume));
    }

    public void FadeInAndOut(string name)
    {
        toStart = name;
        foreach(Sound sound in sounds)
        {
            if(sound.source.isPlaying & sound.source.loop == true) 
            {
                StartCoroutine(FadeMixerGroup.StartFade(audioMixer, "vol", 0.75f, 0f));
                toStop = sound.name;
                
            }

        }
        Invoke("FadeIn",0.75f);
    }

    public void StopPlaying()
    {
        foreach(Sound sound in sounds)
        {
            if(sound.source.isPlaying) 
            {
                sound.source.Stop();
            }
        }
    }

    public void StopBuzz()
    { 
        Sound s = Array.Find(sounds, sound => sound.name =="b");
        if (s == null)
        { 
            Debug.LogWarning("Sound " + s.name + " wasn't found");
            return;
        }
        s.source.Stop();
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
