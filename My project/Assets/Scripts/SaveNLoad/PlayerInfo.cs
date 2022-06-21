using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    public int progress;
    public int itemCount;
    public bool[] items;
    


    private void Start()
    {
        GameEvents.current.onAddingItem += OnAddingItem;
    }
    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
    }

    public void LoadPlayer (ActivatingItem activatingItem)
    {
        PlayerData data = SaveSystem.LoadPlayer();

        progress = data.progress;
        itemCount = data.itemCount;
        items = data.items;

        Vector2 position;
        position.x = data.position[0];
        position.y = data.position[1];
        transform.position = position;
        activatingItem.AfterLoad( items, itemCount);
    }

    private void OnAddingItem(int id)
    {
        if (!items[id / 10])
        {
            itemCount += id % 10;
            for (int i = id / 10; i < (id / 10 + id % 10); i++)
            {
                items[i] = true;
            }
        }
    }
    private void OnDestroy()
    {
        GameEvents.current.onAddingItem -= OnAddingItem;
    }

}
