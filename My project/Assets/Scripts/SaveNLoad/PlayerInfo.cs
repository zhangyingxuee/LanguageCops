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

    private bool send_game_event;

    public int curr_item_count;
    private void Awake()
    {
        InfoSO.Progress = 0;
        InfoSO.ItemCount = 0;
        InfoSO.Items = new bool[curr_item_count];
    }
    private void Start()
    {
        if (InfoSO.From_another_scene)
        {
            LoadPlayer();
            send_game_event = true;
        }else
        {
            send_game_event = false;
        }
        InfoSO.From_another_scene = false;
    }
    private void Update()
    {
        if (send_game_event)
        {
            GameEvents.current.Checkpoint(InfoSO.Progress);
            send_game_event = false;
        }
    }
    public void SavePlayer()
    {
        InfoSO.SceneCount = (InfoSO.SceneCount / 10) * 10 + scene_num;
        SaveSystem.SavePlayer(this);
    }

    public void LoadPlayer ()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        if (data.scene_count % 10 != scene_num)
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
            Debug.Log("Reset checkpoint to " + InfoSO.Progress);
        }
    }


}
