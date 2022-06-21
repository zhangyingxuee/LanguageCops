using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Change_scene : MonoBehaviour
{
    
    public GameObject fading;

    public void OnTriggerEnter2D(Collider2D wall)
    {
        fading.SetActive(false);
        fading.SetActive(true);
    }


}
