using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearStoredData : MonoBehaviour
{
    public SaveDataSO InfoSO;
    public int curr_item_count;
    void Start()
    {
        InfoSO.Progress = 0;
        InfoSO.ItemCount = 0;
        InfoSO.Items = new bool[curr_item_count]; 
    }


}
