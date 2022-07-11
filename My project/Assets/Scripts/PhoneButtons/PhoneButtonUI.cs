
using UnityEngine;
using UnityEngine.SceneManagement;
using System;


public class PhoneButtonUI : MonoBehaviour
{

    public GameObject Phone;
    public GameObject Phone_main;
    public GameObject Phone_setting;
    public GameObject Phone_solving;
    public GameObject Phone_notes;
    public GameObject Phone_hints;
    private bool state = false;
    private bool state_main = false;
    private bool state_setting = false;
    private bool state_solving = false;
    private bool state_notes = false;
    private bool state_hints = false;
    private bool is_from_solving = false;

    public void OpenPhone()
    {
        state = !state;
        Phone.SetActive(state);
        GameEvents.current.CloseCafe();

        state_main = !state_main;
        Phone_main.SetActive(state_main);


    }
    public void OpenPhoneSetting()
    {
        state_setting = !state_setting;
        state_main = !state_main;
        Phone_main.SetActive(state_main);
        Phone_setting.SetActive(state_setting);
    }

    public void OpenPhoneSolving()
    {
        state_solving = !state_solving;
        state_main = !state_main;
        Phone_main.SetActive(state_main);
        Phone_solving.SetActive(state_solving);

    }

    public void OpenFromSolving()
    {
        is_from_solving = true;
        OpenPhoneNotes();
    }

    public void ExitSolving()
    {
        is_from_solving = false;
        OpenPhoneSolving();
    }

    public void OpenPhoneNotes()
    {
        if (is_from_solving)
        {
            state_notes = !state_notes;
            state_solving = !state_solving;
            Phone_solving.SetActive(state_solving);
            Phone_notes.SetActive(state_notes);
        } else
        {
            state_notes = !state_notes;
            state_main = !state_main;
            Phone_main.SetActive(state_main);
            Phone_notes.SetActive(state_notes);
        }
    }

    public void OpenPhoneHints()
    {
        state_hints = !state_hints;
        state_main = !state_main;
        Phone_main.SetActive(state_main);
        Phone_hints.SetActive(state_hints);

    }

    public void Continue()
    {
        OpenPhoneSolving();
        OpenPhone();
    }

}
