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
           // Debug.Log(gameObject.name + " is now deactivated");
            GetComponent<Button>().interactable = false;
        }
        else if (progress == activate)
        {
           // Debug.Log(gameObject.name + " is activated");
            GetComponent<Button>().interactable = true;
        } 
        else if (progress > activate & progress < disactivate)
        { 
           // Debug.Log(gameObject.name + " is activated");
            GetComponent<Button>().interactable = true;
        }
        else if (progress >= disactivate)
        {
           // Debug.Log(gameObject.name + " is now deactivated");
            GetComponent<Button>().interactable = false;
        }
        //Debug.Log(gameObject.name + " is now in state: " + GetComponent<Button>().interactable);
    }
   
    private void OnDestroy()
    {
        GameEvents.current.onCheckpoint -= OnCheckpoint;
    }
 
}
