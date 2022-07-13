using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunAnimationAgain : MonoBehaviour
{
    public GameObject[] Animation;
    public int[] checkpt;
    void Start()
    {
        GameEvents.current.onCheckpoint += OnCheckPoint;
    }

    private void OnCheckPoint(int id)
    {
        for(int i = 0; i < checkpt.Length; i++)
        {
            if(id == checkpt[i])
            {

            }
        }
    }
}
