using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CheckTrueAct2 : MonoBehaviour
{
    public string BGM;
    public DragDropSO dataSO;
    public SaveDataSO InfoSO;
    public int checkpt;
    public PhoneButtonUI control;

    public TextMeshProUGUI result;

    public TextMeshProUGUI slotLabel;

    void Start()
    {
        result.text = " ";
    }
    public void CheckMatch()
    { 
        dataSO.Act2Solution = true;
        int pos2 = dataSO.CheckCorrectSet[1];
        int pos3 = dataSO.CheckCorrectSet[2];
        
        if (dataSO.CorrectSetNumber<2)
        { 
            if (pos2 == pos3 & pos2 != 8 & pos2 != 0 & pos2 == dataSO.CorrectSetNumber+1)
            { 
                
                dataSO.CorrectSetNumber += 1;
                Debug.Log("CorrectSetNumber+1");
                slotLabel.text = "People";
                GameEvents.current.Submit(pos2);
                dataSO.PlaceTaken = new bool[3];
                dataSO.PlaceConflict = new bool[3];
                dataSO.CheckCorrectSet = new int[] {8,8,8};
                result.text = "Correct";
                AudioManager.instance.Play("d");

                
                if (dataSO.CorrectSetNumber == 2)
                { 
                    Debug.Log("all true");
                    GameEvents.current.Submit(9);
                    control.ExitSolving();
                    control.OpenPhone();
                    AudioManager.instance.FadeInAndOut(BGM);
                    InfoSO.Progress = checkpt;
                    GameEvents.current.Checkpoint(checkpt);
                }

                // Make the items disappear!
            }
            else
            {
                AudioManager.instance.Play("e");
                result.text = "Incorrect";
                GameEvents.current.Submit(9);
                dataSO.PlaceTaken[1] = false;
                dataSO.PlaceTaken[2] = false;
                dataSO.PlaceConflict[2] = false;
                dataSO.PlaceConflict[1] = false;
                /*if (pos1 == pos2)
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
                }*/
            }
            dataSO.Act2Solution = false;

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

