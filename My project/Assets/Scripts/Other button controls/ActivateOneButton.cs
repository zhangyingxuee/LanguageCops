using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivateOneButton : MonoBehaviour
{
    public Button button;

    public void ActivateButton()
    {
        button.interactable = true;
    }
}
