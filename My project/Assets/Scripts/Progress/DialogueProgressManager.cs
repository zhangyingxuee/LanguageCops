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
        if (threshold > progress)
        {
            PreCP.SetActive(true);

        } else if (threshold == progress)
        {
            PreCP.SetActive(false);
            CP.SetActive(true);
        } else
        {
            CP.SetActive(false);
            PostCP.SetActive(true);
        }
    }


    void OnDestroy()
    {
        GameEvents.current.onCheckpoint -= OnCheckpoint;
    }
}
