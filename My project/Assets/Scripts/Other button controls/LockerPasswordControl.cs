using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class LockerPasswordControl : MonoBehaviour
{
    public string Sound = "a";
    public string CorrectSound = "d";
    public string IncorrectSound = "e";
    public TextMeshProUGUI[] display;
    public Button[] button;
    public int[] password;
    public int checkpt;
    private int[] input;
    public GameObject Correct;
    public GameObject Incorrect;
    public GameObject LockerPage;
    public SaveDataSO InfoSO;

    private int pos = 0;

    private void Start()
    {
        input = new int[password.Length];
    }

    public void InputNumber(int num)
    {
        AudioManager.instance.Play(Sound);
        display[pos].text = num.ToString();
        input[pos] = num;
        pos++;
        if(pos == display.Length)
        {
            for(int i = 0; i < button.Length; i++)
            {
                button[i].interactable = false;
            }
        }
        EventSystem.current.SetSelectedGameObject(null);
    }

    public void Back()
    {
        AudioManager.instance.Play(Sound);
        if(pos == 0)
        {
            LockerPage.SetActive(false);
            GameEvents.current.CloseCafe();
        }
        else if (pos == display.Length)
        {
            pos--;
            display[pos].text = " ";
            input[pos] = 0;
            for (int i = 0; i < button.Length; i++)
            {
                button[i].interactable = true;
            }
        }
        else
        {
            pos--;
            display[pos].text = " ";
            input[pos] = 0;
        }
        EventSystem.current.SetSelectedGameObject(null);
    }

    public void ResetPage()
    {
        for (int i = 0; i < display.Length; i++)
        {
            display[i].text = " ";
        }
        for (int i = 0; i < button.Length; i++)
        {
            button[i].interactable = true;
        }
        input = new int[password.Length];
        pos = 0;
        Incorrect.SetActive(false);
    }

    public void Submit()
    {
        AudioManager.instance.Play(Sound);
        bool is_correct = true;
        if(pos == display.Length)
        {
            for (int i = 0; i < password.Length; i++)
            {
                if (password[i] != input[i])
                {
                    is_correct = false;
                }
            }
            if(is_correct)
            {
                AudioManager.instance.Play(CorrectSound);
                Correct.SetActive(true);
                Invoke("AfterCorrect", 1f);
            }
            else
            {
                AudioManager.instance.Play(IncorrectSound);
                Incorrect.SetActive(true);
                Invoke("ResetPage", 0.5f);
                EventSystem.current.SetSelectedGameObject(null);
            }
        }
        else
        {
            Incorrect.SetActive(true);
            Invoke("ResetPage", 0.5f);
            EventSystem.current.SetSelectedGameObject(null);
        }
    }

    private void AfterCorrect()
    {
        LockerPage.SetActive(false);
        GameEvents.current.CloseCafe();
        InfoSO.Progress = checkpt;
        GameEvents.current.Checkpoint(checkpt);
    }
}
