using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialiseSO : MonoBehaviour
{
    public DragDropSO dataSO;
   
    void Awake()
    {
        dataSO.PlaceTaken = new bool[3];
        dataSO.PlaceConflict = new bool[3];
        dataSO.CorrectSetNumber = 0;
        dataSO.CheckCorrectSet = new int[] {0,0,0};
        dataSO.ObjectSet = 0;
    }

   
}
