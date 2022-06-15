
using UnityEngine;
using UnityEngine.SceneManagement;
using System;


public class PhoneButtonUI : MonoBehaviour
{

    public GameObject Phone;
    public GameObject Phone_main;
    public GameObject Phone_setting;
    public GameObject Phone_solving;
    private bool state = false;
    private bool state_main = false;
    private bool state_setting = false;
    private bool state_solving = false;

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

    public void Continue()
    {
        OpenPhoneSolving();
        OpenPhone();
    }

}
