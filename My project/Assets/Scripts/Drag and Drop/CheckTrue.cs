using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CheckTrue : MonoBehaviour
{
    public DragDropSO dataSO;
    public GameObject this_page;
    public GameObject next_page;

    public TextMeshProUGUI result;


    void Start()
    {
        result.text = " ";
    }
    public void CheckMatch()
    { 
        int pos1 = dataSO.CheckCorrectSet[0];
        int pos2 = dataSO.CheckCorrectSet[1];
        int pos3 = dataSO.CheckCorrectSet[2];
        
        if (dataSO.CorrectSetNumber<3)
        { 
            if (pos1 == pos2 & pos2 == pos3 & pos1 != 8 & pos1 != 0)
            { 
                dataSO.CorrectSetNumber += 1;
                Debug.Log("CorrectSetNumber+1");
                GameEvents.current.Submit(pos1);
                dataSO.PlaceTaken = new bool[3];
                dataSO.PlaceConflict = new bool[3];
                dataSO.CheckCorrectSet = new int[] {8,8,8};
                result.text = "Correct";
                AudioManager.instance.Play("d");
                if (dataSO.CorrectSetNumber == 3)
                { 
                    Debug.Log("all true");
                    GameEvents.current.Submit(9);
                    this_page.SetActive(false);
                    next_page.SetActive(true);
                }

                // Make the items disappear!
            }
            else
            {
                AudioManager.instance.Play("e");
                result.text = "Incorrect";
                GameEvents.current.Submit(pos1);
                if (pos1 == pos2)
                {
                    dataSO.PlaceTaken[2] = false;
                    dataSO.PlaceConflict[2] = false;
                } 
                else if (pos1 == pos3)
                {
                    dataSO.PlaceTaken[1] = false;
                    dataSO.PlaceConflict[1] = false;
                }
                else
                {
                    dataSO.PlaceTaken[1] = false;
                    dataSO.PlaceTaken[2] = false;
                    dataSO.PlaceConflict[2] = false;
                    dataSO.PlaceConflict[1] = false;
                }
            }
        }

    
    }

    public void Reset()
    {
        result.text = " ";
        GameEvents.current.Submit(9);
        dataSO.PlaceTaken = new bool[3];
        dataSO.PlaceConflict = new bool[3];
    }
}
