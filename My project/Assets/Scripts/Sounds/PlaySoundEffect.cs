using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundEffect : MonoBehaviour
{
    public bool play_at_start;
   // public bool play_at_OnEnable;
    public bool play_BGM;
    public string name_of_effect;
    void Start()
    {
        if(play_at_start)
        {
            AudioManager.instance.Play(name_of_effect);
        } 
        if (play_BGM)
        {
            AudioManager.instance.FadeInAndOut(name_of_effect);
        }        
    }

/*
    private void OnEnable()
    { 
         if(play_at_OnEnable)
        {
            AudioManager.instance.Play(name_of_effect);
        } 
    }
*/
    public void PlayOnClick()
    {
        AudioManager.instance.Play(name_of_effect);
    }

    public void ChangeBGM()
    {
        //Debug.Log("ChangeBGM is triggered");
        AudioManager.instance.StopPlaying();
        AudioManager.instance.Play(name_of_effect);
    }

    public void FadeChange()
    {
        AudioManager.instance.FadeInAndOut(name_of_effect);
    }

}
