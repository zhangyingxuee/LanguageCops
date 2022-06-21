using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisableButton : MonoBehaviour
{
    private bool state = false;
    private bool curr_state;
    void Start()
    {
        GameEvents.current.onCloseCafe += OnCloseCafe;
        curr_state = GetComponent<Button>().interactable;
        Debug.Log("start" + curr_state);
    }

    private void OnCloseCafe()
    {
        if (!state)
        {
            curr_state = GetComponent<Button>().interactable;
        }
        Debug.Log("curr:" + curr_state);
        if (curr_state == true)
        {
            GetComponent<Button>().interactable = state;
            Debug.Log(state);
            state = !state;
        }

    }

    private void OnDestroy()
    {
        GameEvents.current.onCloseCafe -= OnCloseCafe;
    }
}
