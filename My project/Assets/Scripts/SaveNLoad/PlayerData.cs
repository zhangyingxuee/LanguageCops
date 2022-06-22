using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public float[] position;
    public int progress;
    public int itemCount;
    public int scene_count;
    public bool[] items;
    public string player_name;

    public PlayerData (PlayerInfo player) 
    {
        progress = player.InfoSO.Progress;
        itemCount = player.InfoSO.ItemCount;
        items = player.InfoSO.Items;
        player_name = player.InfoSO.PlayerName;
        scene_count = player.InfoSO.SceneCount;

        position = new float[2];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
    }
}
