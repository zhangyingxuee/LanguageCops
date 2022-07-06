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

    public GameObject popup;

    private bool send_game_event1;
    private bool send_game_event2;

    public int curr_item_count;

    private bool should_reset;
    private void Awake()
    {
        InfoSO.Progress = 0;
        InfoSO.ItemCount = 0;
        InfoSO.HighestItemId = 0;
        InfoSO.LastLoadedProgress = 0;
        InfoSO.Items = new bool[curr_item_count];
    }
    private void Start()
    {
        if (InfoSO.From_another_scene)
        {
            LoadPlayer();
            send_game_event1 = true;
            send_game_event2 = true;
            should_reset = false;
        }else
        {
            send_game_event1 = false;
            send_game_event2 = false;
            should_reset = true;
            
        }
        InfoSO.From_another_scene = false;
    }

    private void Update()
    {
        if (send_game_event1 & send_game_event2)
        {
            LoadPlayer();
            //GameEvents.current.Checkpoint(InfoSO.Progress);
            send_game_event1 = false;
            Debug.Log("Loading player...");
        } 
        else if (!send_game_event1 & send_game_event2)
        {
            GameEvents.current.Checkpoint(InfoSO.Progress);
            send_game_event2 = false;
            Debug.Log("Loading a second time.");
        }
        if (should_reset)
        {
            GameEvents.current.Checkpoint(0);
            should_reset = false;
        }
    }
    
    public void SavePlayer()
    {
        InfoSO.SceneCount = InfoSO.SubSceneCount * 10 + scene_num;
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
            InfoSO.LastLoadedProgress = data.progress;
            InfoSO.ItemCount = data.itemCount;
            InfoSO.HighestItemId = data.highestItemId;
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
            popup.SetActive(false);
            Invoke("updateProcessAftLoad", 0.3f);
            
        }
    }
private void updateProcessAftLoad()
{ 
    activatingItem.AfterLoad();
    GameEvents.current.Checkpoint(InfoSO.Progress);
    Debug.Log("Reset checkpoint to " + InfoSO.Progress);
}

}
