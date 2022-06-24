using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckTrue : MonoBehaviour
{
    public DragDropSO dataSO;
    public void CheckMatch()
    { 
        int pos1 = dataSO.CheckCorrectSet[0];
        int pos2 = dataSO.CheckCorrectSet[1];
        int pos3 = dataSO.CheckCorrectSet[2];
        
        if (dataSO.CorrectSetNumber<3)
        { 
            if (pos1 == pos2 & pos2 == pos3 & pos1 != 0)
            { 
                dataSO.CorrectSetNumber += 1;
                Debug.Log("CorrectSetNumber+1");
                GameEvents.current.Submit(pos1);
                if (dataSO.CorrectSetNumber == 3)
                { 
                    Debug.Log("all true");
                    GameEvents.current.Submit(9);
                }

                // Make the items disappear!
            }
            else
            {
                GameEvents.current.Submit(pos1);
            }
        }

    
    }

    public void Reset()
    {
        GameEvents.current.Submit(9);
    }
}
