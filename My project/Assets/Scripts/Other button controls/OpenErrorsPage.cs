using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenErrorsPage: MonoBehaviour
{
    public GameObject ErrorPage;
    public bool state;

    public void OpenPage()
    {
        ErrorPage.SetActive(state);
        GameEvents.current.CloseCafe();
    }
}
