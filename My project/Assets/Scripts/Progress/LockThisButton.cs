using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LockThisButton : MonoBehaviour
{
    public int activate;
    public int disactivate;
    void Start()
    {
        GameEvents.current.onCheckpoint += OnCheckpoint;
    }
    private void OnCheckpoint(int progress)
    {
        if (progress < activate)
        {
            GetComponent<Button>().interactable = false;
        }
        else if (progress == activate)
        {
            GetComponent<Button>().interactable = true;
        } 
        else if (progress > disactivate)
        {
            GetComponent<Button>().interactable = false;
        }
    }
   
    private void OnDestroy()
    {
        GameEvents.current.onCheckpoint -= OnCheckpoint;
    }
 
}
