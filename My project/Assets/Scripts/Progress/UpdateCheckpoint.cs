using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateCheckpoint : MonoBehaviour
{

    private bool is_ready = false;
    public int ready_id;
    public SaveDataSO InfoSO;

    private int all_items_id;
    private bool all_clicked = false;
    void Start()
    {
        GameEvents.current.onGetReady += OnGetReady;
        GameEvents.current.onDialogueEnd += OnDialogueEnd;
    }

    public void UpdateProgress(int checkpt)
    {
        InfoSO.Progress = checkpt;
        GameEvents.current.Checkpoint(checkpt); 
        //Debug.Log(checkpt);
    }

    public void All_Items_Clicked(int checkpt_plus_item_num)
    {
        int checkpt = checkpt_plus_item_num % 100;
        int num_items = checkpt_plus_item_num / 100;
        if(InfoSO.ItemCount >= num_items)
        {
            all_clicked = true;
            all_items_id = checkpt;
            
            //Debug.Log("All items clicked");
        }
    }

    public void OnDialogueEnd()
    {
        if (is_ready) 
        {
            InfoSO.Progress = ready_id;
            GameEvents.current.Checkpoint(ready_id);
        }
        if(all_clicked)
        {
            InfoSO.Progress = all_items_id;
            GameEvents.current.Checkpoint(all_items_id);
            all_clicked = false;
        }
        
    }

    private void OnGetReady(int id)
    {
        if ( id == ready_id)
        {
            is_ready = true;
        } else
        {
            is_ready = false;
        }
    }

    private void OnDestroy()
    {
        GameEvents.current.onGetReady -= OnGetReady;
        GameEvents.current.onDialogueEnd -= OnDialogueEnd;
    }
}
