using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivatePop : MonoBehaviour
{
    private void onEnable() 
    {
         GetComponent<Button>().interactable = true;
    }
}
