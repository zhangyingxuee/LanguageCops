using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInfo : MonoBehaviour
{
    public int scene_num;

    public GameObject[] sub_scene;

    public SaveDataSO InfoSO;

    public ActivatingItem activatingItem;


    private void Awake()
    {
        if (InfoSO.From_another_scene)
        {
            LoadPlayer();
            InfoSO.From_another_scene = false;
        }
    }
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

        if (data.scene_count % 10 != scene_num % 10)
        {
            InfoSO.From_another_scene = true;
            SceneManager.LoadScene(data.scene_count % 10);
        } else
        {
            InfoSO.Progress = data.progress;
            InfoSO.ItemCount = data.itemCount;
            InfoSO.Items = data.items;
            for (int i = 0; i < sub_scene.Length; i++)
            {
                if(i == data.scene_count / 10)
                {
                    sub_scene[i].SetActive(true);
                } else
                {
                    sub_scene[i].SetActive(false);
                }
            }

            Vector2 position;
            position.x = data.position[0];
            position.y = data.position[1];
            transform.position = position;
            InfoSO.Position = position;
            activatingItem.AfterLoad();
            GameEvents.current.Checkpoint(InfoSO.Progress);
        }
    }

    private void OnAddingItem(int id)
    {
        if (!InfoSO.Items[id / 10])
        {
            InfoSO.ItemCount += id % 10;
            for (int i = id / 10; i < (id / 10 + id % 10); i++)
            {
                InfoSO.Items[i] = true;
            }
        }
    }
    private void OnDestroy()
    {
        GameEvents.current.onAddingItem -= OnAddingItem;
    }

}
