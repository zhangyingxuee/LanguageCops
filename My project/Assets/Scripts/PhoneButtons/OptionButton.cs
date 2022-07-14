using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionButton : MonoBehaviour
{
    public GameObject Correct;
    public GameObject Incorrect;
    public GameObject Current;

    public string CorrectSound = "d";
    public string IncorrectSound = "e";
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
        AudioManager.instance.Play(CorrectSound);
        Current.SetActive(false);
        Correct.SetActive(true);
    }
    public void IncorrrectOption()
    {
        AudioManager.instance.Play(IncorrectSound);
        Current.SetActive(false);
        Incorrect.SetActive(true);
    }
    public void Retry()
    {
        Current.SetActive(true);
        Incorrect.SetActive(false);
    }
}
