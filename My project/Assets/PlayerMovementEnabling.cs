using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementEnabling : MonoBehaviour
{
    public int[] activatePointSet;
    public NewMovement player;
    private bool is_inbetween;

    void Start()
    {
        GameEvents.current.onCheckpoint += OnCheckpoint;
    }

    private void OnCheckpoint(int progress)
    {
        for (int i = 1; i < activatePointSet.Length; i++)
        {
            int disactivatePoint = activatePointSet[i] / 100;
            int activatePoint = activatePointSet[i] % 100;
            if ( activatePoint > progress & progress >= disactivatePoint)
            {
                player.isInCutScene = true;
                is_inbetween = true;
            }
        }
        if (!is_inbetween)
        {
            player.isInCutScene = false;
        }
    }
}
