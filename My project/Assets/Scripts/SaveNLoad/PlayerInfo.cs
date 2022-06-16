using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    public int progress;
    public int itemCount;
    //public bool[] items = new bool[5];

    private void Start()
    {
        GameEvents.current.onAddingItem += OnAddingItem;
    }
    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
    }

    public void LoadPlayer ()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        progress = data.progress;
        itemCount = data.itemCount;

        Vector2 position;
        position.x = data.position[0];
        position.y = data.position[1];
        transform.position = position;
    }

    private void OnAddingItem(int count)
    {
        itemCount = count;
    }
    private void OnDestroy()
    {
        GameEvents.current.onAddingItem -= OnAddingItem;
    }

}
