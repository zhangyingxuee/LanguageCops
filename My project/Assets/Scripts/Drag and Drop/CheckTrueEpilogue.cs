using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CheckTrueEpilogue : MonoBehaviour
{
    public DragDropSO dataSO;
    public GameObject thisScene;
    public GameObject nextScene;
    public PourManager manager;
    
    public GameObject[] pages;

    private bool is_correct = false;

    void Start()
    {
        GameEvents.current.onSelectButton += OnSelectButton;
        GameEvents.current.onDeselectButton += OnDeselectButton;
    }

    private void OnSelectButton(int no_correct)
    {
        if (no_correct == 1)
        {
            is_correct = true;
        }
        GameEvents.current.AllSelect(1);

    }
    private void OnDeselectButton(int no_correct)
    {
        if (no_correct == 1)
        {
            is_correct = false;
        }  
        GameEvents.current.AllSelect(0);
    }

    public void CheckMatch()
    { 
        dataSO.EpilogueSolution = true;

        int pos = dataSO.CheckCorrectSet[1];
        dataSO.PlaceTaken = new bool[3];
        dataSO.PlaceConflict = new bool[3];
        if (pos == dataSO.EpiloguePageNum & is_correct == true)
        {
            dataSO.CorrectSetNumber += 1;
            Debug.Log("CorrectSetNumber is: "+dataSO.CorrectSetNumber);
            //Debug.Log(dataSO.EpiloguePageNum);
            //Debug.Log(dataSO.CorrectSetNumber + "until page "+ dataSO.EpiloguePageNum+1);
        }

        if (dataSO.EpiloguePageNum == pages.Length)
        {
            thisScene.SetActive(false);
            nextScene.SetActive(true);
            manager.initialiseButton();
            dataSO.EpilogueSolution = false;
        }
        else
        {
            pages[dataSO.EpiloguePageNum - 1].SetActive(false);
            pages[dataSO.EpiloguePageNum].SetActive(true);
            dataSO.EpiloguePageNum += 1;
            GameEvents.current.Submit(pos);
            GameEvents.current.AllReset();

        }



    }

    public void Reset()
    {
        GameEvents.current.Submit(9);
        dataSO.PlaceTaken = new bool[3];
        dataSO.PlaceConflict = new bool[3];
        GameEvents.current.AllReset();
    }
}

