using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionButton : MonoBehaviour
{
    public GameObject Correct;
    public GameObject Incorrect;
    public GameObject Current;
    private void Start()
    {
        GameEvents.current.onCloseCafe += OnCloseCafe;

    }
    private void OnCloseCafe()
    {
        Current.SetActive(true);
        Incorrect.SetActive(false);
        Correct.SetActive(false);
    }
    public void CorrrectOption()
    {
        Current.SetActive(false);
        Correct.SetActive(true);
    }
    public void IncorrrectOption()
    {
        Current.SetActive(false);
        Incorrect.SetActive(true);
    }
    public void Retry()
    {
        Current.SetActive(true);
        Incorrect.SetActive(false);
    }
}
