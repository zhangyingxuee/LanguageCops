using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateSubscene : MonoBehaviour
{
    public SaveDataSO InfoSO;

    public void UpdateSubScene(int count)
    {
        InfoSO.SubSceneCount =  count;
    }
}
