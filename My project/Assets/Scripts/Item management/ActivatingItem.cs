using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatingItem : MonoBehaviour
{
    private int activate_id;
    public SaveDataSO InfoSO;
    public GameObject[] OverviewItem;
    void Start()
    {
        GameEvents.current.onAddingItem += OnAddingItem;
    }

    private void OnAddingItem(int id)
    {
        //id = [set active id][number of items activated]
        activate_id = id / 10;
        for (int i = activate_id; i < (activate_id + id % 10); i++)
        {
            OverviewItem[i].SetActive(true);
        }
    }

    public void AfterLoad()
    {
        for ( int i = 0; i < OverviewItem.Length; i++)
        {
            OverviewItem[i].SetActive(InfoSO.Items[i]);
        }
    }
    private void OnDestroy()
    {
        GameEvents.current.onAddingItem -= OnAddingItem;
    }

}
