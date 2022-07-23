using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Change_scene : MonoBehaviour
{
    
    public GameObject fading;
    private bool state = false;

        void Start()
    {
        GameEvents.current.onCloseCafe += OnCloseCafe;
    }

    public void OnTriggerEnter2D(Collider2D wall)
    {
        if (!state)
        { 
            fading.SetActive(false);
            fading.SetActive(true);
        }

    }

     private void OnCloseCafe()
    {
        state = !state;
    }

    private void OnDestroy()
    {
        GameEvents.current.onCloseCafe -= OnCloseCafe;
    }
}
