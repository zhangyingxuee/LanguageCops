using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NotificationControl : MonoBehaviour
{
    void Start()
    {
        GameEvents.current.onAddingItem += OnAddingItem;
    }

    private int display = 0;
    private bool state = false;
    public TextMeshProUGUI Outside;
    public TextMeshProUGUI Inside;
    public GameObject PopOutside;
    public GameObject PopInside;
    public SaveDataSO InfoSO;
    private void OnAddingItem(int id)
    {
        Debug.Log("Item added" );
        if (!InfoSO.Items[id / 10])
        {
            Debug.Log("New item");
            display += id % 10;
            InfoSO.ItemCount += id % 10;
            state = true;
            PopOutside.SetActive(true);
            PopInside.SetActive(true);
            Outside.text = display.ToString();
            Inside.text = display.ToString();
            for (int i = id / 10; i < (id / 10 + id % 10); i++)
            {
                InfoSO.Items[i] = true;
            }
        }
  
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
}
