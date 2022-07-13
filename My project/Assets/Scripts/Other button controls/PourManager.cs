using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PourManager : MonoBehaviour
{
    public GameObject[] indicator;
    public GameObject[] filled;
    public GameObject[] empty;
    public DragDropSO dataSO;
    public GameObject thisPage;
    public GameObject confirmPage;
    public GameObject fade;
    public int[] endSceneNo;

    private int level = 0;
    private int end = 0;

    private void Start()
    {
        GameEvents.current.onCheckpoint += OnCheckPoint;
    }

    public void initialiseButton()
    {
        for(int i = 0;i < dataSO.CorrectSetNumber;i++ )
        {
            filled[i].SetActive(true);
        }
        for(int i = dataSO.CorrectSetNumber; i < empty.Length; i++)
        {
            empty[i].SetActive(true);
        }
    }
    public void fill()
    {
        indicator[level].SetActive(false);
        level++;
        indicator[level].SetActive(true);
    }

    public void unfill()
    {
        indicator[level].SetActive(false);
        level--;
        indicator[level].SetActive(true);
    }

    public void Finish()
    {
        thisPage.SetActive(false);
        confirmPage.SetActive(true);
    }
    public void Cancel()
    {
        thisPage.SetActive(true);
        confirmPage.SetActive(false);
    }

    public void Continue()
    {
        fade.SetActive(true);
        if(level == 0)
        {
            if(dataSO.CorrectSetNumber == 0)
            {
                //load end 1 (bad end)
                end = 1;
            }
            else
            {
                //load end 2 (evil end)
                end = 2;
            }
        } else if (level == indicator.Length - 1)
        {
            //load end 4 (good end)
            end = 4;
        }
        else
        {
            //load end 3 (normal end)
            end = 3;
        }
    }

    private void OnCheckPoint(int id)
    {
        if (end != 0)
        {
            SceneManager.LoadScene(endSceneNo[end - 1]);
        }
    }
}
