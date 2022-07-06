using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SaveDataSO : ScriptableObject
{
    private int scene_count;
    private int sub_scene_count;
    private int progress;
    private int lastLoadedProgress;
    private int itemCount;
    private int highestItemId;
    private string player_name;
    private bool[] items = new bool[30];
    private Vector2 position;
    private bool from_another_scene;

    public int SceneCount
    {
        get { return scene_count; }
        set { scene_count = value; }
    }
    public int SubSceneCount
    {
        get { return sub_scene_count; }
        set { sub_scene_count = value; }
    }
    public int Progress
    {
        get { return progress; }
        set { progress = value; }
    }
    public int LastLoadedProgress
    {
        get { return lastLoadedProgress; }
        set { lastLoadedProgress = value; }
    }
    public int ItemCount
    {
        get { return itemCount; }
        set { itemCount = value; }
    }
    public int HighestItemId
    {
        get { return highestItemId; }
        set { highestItemId = value; }
    }
    public string PlayerName
    {
        get { return player_name; }
        set { player_name = value; }
    }

    public bool[] Items
    {
        get { return items; }
        set { items = value; }
    }
    public Vector2 Position
    {
        get { return position; }
        set { position = value; }
    }
    public bool From_another_scene
    {
        get { return from_another_scene; }
        set { from_another_scene = value; }
    }
}
