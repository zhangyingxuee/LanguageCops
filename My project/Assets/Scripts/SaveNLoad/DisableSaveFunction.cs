using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisableSaveFunction : MonoBehaviour
{
    public GameObject popUp;

    public void CheckState()
    {
        if(popUp.activeSelf == true)
        {
            GetComponent<Button>().interactable = false;
        }
        else
        {
            GetComponent<Button>().interactable = true;
        }
    }
}
