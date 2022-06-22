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
        Debug.Log("Progress updated to " + progress);
        if (threshold > progress)
        {
            PreCP.SetActive(true);
            CP.SetActive(false);
            PostCP.SetActive(false);

        }
        else if (threshold == progress)
        {
            PreCP.SetActive(false);
            CP.SetActive(true);
            PostCP.SetActive(false);
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
