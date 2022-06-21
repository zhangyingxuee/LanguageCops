using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public float[] position;
    public int progress;
    public int itemCount;
    public bool[] items;

    public PlayerData (PlayerInfo player) 
    {
        progress = player.progress;
        itemCount = player.itemCount;
        items = player.items;

        position = new float[2];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
    }
}
