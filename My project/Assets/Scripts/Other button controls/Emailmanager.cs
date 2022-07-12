using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Emailmanager : MonoBehaviour
{
    public TextMeshProUGUI CurrentSelected;
    public TextMeshProUGUI TotalToSelect;
    public TextMeshProUGUI DisplayCorrect;
    public GameObject QuestionPage;
    public GameObject IncorrectPage;
    public GameObject too_much;
    public GameObject too_few;
    public GameObject too_incorrect;
    public GameObject CorrectPage;
    public EmailSelectionControl[] buttons;
    public int TotalS;
    private int CurrentS = 0;
    private int correct = 0;

    private void Start()
    {
        GameEvents.current.onSelectButton += OnSelectButton;
        GameEvents.current.onDeselectButton += OnDeselectButton;
    }
    public void LoadThisEmail()
    {
        TotalToSelect.text = TotalS.ToString();
        QuestionPage.SetActive(true);
        IncorrectPage.SetActive(false);
        CorrectPage.SetActive(false);
        GameEvents.current.AllReset();
        /*
        for(int i = 0; i < buttons.Length; i++)
        {
            buttons[i].is_selected = true;
            buttons[i].ToggleSelection();
        }
        */
        CurrentS = 0;
        correct = 0;
        CurrentSelected.text = CurrentS.ToString();
    }
    private void OnSelectButton(int no_correct)
    {
        CurrentS++;
        CurrentSelected.text = CurrentS.ToString();
        correct += no_correct;
        if (CurrentS == TotalS)
        {
            GameEvents.current.AllSelect(1);    
        }
    }
    private void OnDeselectButton(int no_correct)
    {
        CurrentS--;
        CurrentSelected.text = CurrentS.ToString();
        correct -= no_correct;
        if (CurrentS == TotalS - 1)
        {
            GameEvents.current.AllSelect(0);
        }
    }
    public void IncorrectSelect()
    {
        CurrentS++;
        CurrentSelected.text = CurrentS.ToString();
    }
    public void IncorrectDeselect()
    {
        CurrentS--;
        CurrentSelected.text = CurrentS.ToString();
    }
    public void CorrectSelect()
    {
        CurrentS++;
        correct++;
        CurrentSelected.text = CurrentS.ToString();
    }
    public void CorrectDeselect()
    {
        CurrentS--;
        correct--;
        CurrentSelected.text = CurrentS.ToString();
    }

    public void Submit()
    {
        if (CurrentS > TotalS)
        {
            QuestionPage.SetActive(false);
            IncorrectPage.SetActive(true);
            DisplayCorrect.text = correct.ToString();
            
            too_few.SetActive(false);
            too_incorrect.SetActive(false);
            too_much.SetActive(true);

        } else if (CurrentS < TotalS)
        {
            QuestionPage.SetActive(false);
            IncorrectPage.SetActive(true);
            DisplayCorrect.text = correct.ToString();

            too_much.SetActive(false);
            too_incorrect.SetActive(false);
            too_few.SetActive(true);

        } else 
        {
            if (correct == TotalS)
            {
                QuestionPage.SetActive(false);
                CorrectPage.SetActive(true);
                DisplayCorrect.text = correct.ToString();
            }
            else
            {
                QuestionPage.SetActive(false);
                IncorrectPage.SetActive(true);
                DisplayCorrect.text = correct.ToString();

                too_much.SetActive(false);
                too_few.SetActive(false);
                too_incorrect.SetActive(true);
            }
        }
    }

    public void Retry()
    {
        LoadThisEmail();
    }

    private void OnDestroy()
    {
        GameEvents.current.onSelectButton -= OnSelectButton;
        GameEvents.current.onDeselectButton -= OnDeselectButton;
    }
}
