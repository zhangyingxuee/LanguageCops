using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControlCenter : MonoBehaviour
{
    void Start()
    {
        GameEvents.current.onCheckpoint += OnCheckpoint;
    }
    public GameObject[] Scenes;

    private void OnCheckpoint(int progress)
    {
        if (progress < Scenes.Length)
        {
            Scenes[progress].SetActive(true);
        }
        if (progress > 0) 
        {
            Scenes[progress - 1].SetActive(false);
        }
        

    }
}
