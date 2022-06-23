using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ContinueGame : MonoBehaviour
{
    public SaveDataSO InfoSO;

    private void Awake()
    {
        if (SaveSystem.LoadPlayer() == null)
        {
            GetComponent<Button>().interactable = false;
        }
        else
        {
            GetComponent<Button>().interactable = true;
        }
    }

    public void ContinueFromSave()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        InfoSO.From_another_scene = true;
        SceneManager.LoadScene(data.scene_count % 10);

    }
}
