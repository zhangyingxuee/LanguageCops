using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatingItem : MonoBehaviour
{
    void Start()
    {
        GameEvents.current.onAddingItem += OnAddingItem;
    }
    public GameObject[] OverviewItem;
    private void OnAddingItem(int count)
    {
        for (int i = 0; i < count; i++)
        {
            OverviewItem[i].SetActive(true);
        }
    }
    private void OnDestroy()
    {
        GameEvents.current.onAddingItem -= OnAddingItem;
    }

}
