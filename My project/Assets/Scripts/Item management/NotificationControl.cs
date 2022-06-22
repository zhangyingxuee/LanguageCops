using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NotificationControl : MonoBehaviour
{
    private int display = 0;
    private bool state = false;
    public TextMeshProUGUI Outside;
    public TextMeshProUGUI Inside;
    public GameObject PopOutside;
    public GameObject PopInside;
    public GameObject TextBox;
    public SaveDataSO InfoSO;

    private bool is_ready;

    void Start()
    {
        GameEvents.current.onAddingItem += OnAddingItem;
        GameEvents.current.onDialogueEnd += OnDialogueEnd;
    }

    private void OnAddingItem(int id)
    {
        //Debug.Log("Item added" );
        if (!InfoSO.Items[id / 10])
        {
            InfoSO.ItemCount += id % 10;
            display += id % 10;
            for (int i = id / 10; i < (id / 10 + id % 10); i++)
            {
                InfoSO.Items[i] = true;
            }
            if (TextBox.activeSelf == true)
            {
                is_ready = true;
            }
            else
            {
                DisplayItemCount();
            }   
        }
  
    }
    public void OnDialogueEnd()
    {
        if (is_ready)
        {
            DisplayItemCount();
            is_ready = false;
        }
    }
    private void DisplayItemCount()
    {
        //Debug.Log("New item");
        state = true;
        PopOutside.SetActive(true);
        PopInside.SetActive(true);
        Outside.text = display.ToString();
        Inside.text = display.ToString();

    }
    public void OnOpeningPhone()
    {
        if (display > 0)
        {
            PopOutside.SetActive(state);
            PopInside.SetActive(!state);
            Inside.text = display.ToString();
            state = !state;
        }
    }

    public void CheckedItem ()
    {
        display = 0;
        PopOutside.SetActive(false);
        PopInside.SetActive(false);
    }

    private void OnDestroy()
    {
        GameEvents.current.onAddingItem += OnAddingItem;
        GameEvents.current.onDialogueEnd += OnDialogueEnd;
    }
}
