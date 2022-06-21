using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatingItem : MonoBehaviour
{
    private int item_sum;
    private int activate_id;
    public bool[] item_state;
    void Start()
    {
        GameEvents.current.onAddingItem += OnAddingItem;
    }
    public GameObject[] OverviewItem;
    private void OnAddingItem(int id)
    {
        //id = [set active id][number of items activated]
        item_sum += id % 10;
        activate_id = id / 10;
        if (!item_state[activate_id])
        {
            for (int i = activate_id; i < (activate_id + id % 10); i++)
            {
                OverviewItem[i].SetActive(true);
            }
        }
    }

    public void AfterLoad(bool[] items, int count)
    {
        for ( int i = 0; i < count; i++)
        {
            OverviewItem[i].SetActive(items[i]);
        }
        item_state = items;
    }
    private void OnDestroy()
    {
        GameEvents.current.onAddingItem -= OnAddingItem;
    }

}
