using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueProgressManager : MonoBehaviour
{
    void Start()
    {
        GameEvents.current.onCheckpoint += OnCheckpoint;
    }

    public int threshold;


    public GameObject PreCP;
    public GameObject CP;
    public GameObject PostCP;
    private void OnCheckpoint (int progress)
    {
        //Debug.Log("Progress updated to " + progress);
        if (threshold > progress)
        {
            CP.SetActive(false);
            PostCP.SetActive(false);
            PreCP.SetActive(true);
        }
        else if (threshold == progress)
        {
            //Debug.Log("Active:" + CP.name);
            PreCP.SetActive(false);
            PostCP.SetActive(false);
            CP.SetActive(true);   
        } else
        {
            PreCP.SetActive(false);
            CP.SetActive(false);
            PostCP.SetActive(true);
        }
    }


    void OnDestroy()
    {
        GameEvents.current.onCheckpoint -= OnCheckpoint;
    }
}
