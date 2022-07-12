using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CheckTrueEpilogue : MonoBehaviour
{
    public DragDropSO dataSO;
    public SaveDataSO InfoSO;
    public int checkpt;
    
    public GameObject[] pages;

    void Start()
    {
       
    }

    public void CheckMatch()
    { 
        dataSO.EpilogueSolution = true;

        int pos = dataSO.CheckCorrectSet[1];
        
        if (dataSO.CorrectSetNumber<6)
        { 
            if (pos == dataSO.EpiloguePageNum)
            { 
                dataSO.CorrectSetNumber += 1;
                Debug.Log("CorrectSetNumber+1");
                GameEvents.current.Submit(pos);
                dataSO.PlaceTaken = new bool[3];
                dataSO.PlaceConflict = new bool[3];
                Debug.Log(dataSO.EpiloguePageNum);
                pages[dataSO.EpiloguePageNum-1].SetActive(false);
                pages[dataSO.EpiloguePageNum].SetActive(true);
                dataSO.EpiloguePageNum += 1;
                Debug.Log(dataSO.CorrectSetNumber + "until page "+ dataSO.EpiloguePageNum+1);

            }
            else
            {
                pages[dataSO.EpiloguePageNum-1].SetActive(false);
                pages[dataSO.EpiloguePageNum].SetActive(true);
                dataSO.EpiloguePageNum += 1;
                GameEvents.current.Submit(pos);
                dataSO.PlaceTaken = new bool[3];
                dataSO.PlaceConflict = new bool[3];
                Debug.Log(dataSO.CorrectSetNumber + "until page "+ dataSO.EpiloguePageNum+1);
            }
        }
        dataSO.EpilogueSolution = false;
    
    }

    public void Reset()
    {
        GameEvents.current.Submit(9);
        dataSO.PlaceTaken = new bool[3];
        dataSO.PlaceConflict = new bool[3];
    }
}

