using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisableButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameEvents.current.onCloseCafe += OnCloseCafe;
    }
    private bool state = false;
    private void OnCloseCafe()
    {
        GetComponent<Button>().enabled = state;
       // Debug.Log(state);
        state = !state;
    }

    private void OnDestroy()
    {
        GameEvents.current.onCloseCafe -= OnCloseCafe;
    }
}
