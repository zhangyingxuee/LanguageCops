using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateSubscene : MonoBehaviour
{
    public SaveDataSO InfoSO;

    public void UpdateSubScene(int count)
    {
        InfoSO.SceneCount = InfoSO.SceneCount % 10 + count * 10;
    }
}
