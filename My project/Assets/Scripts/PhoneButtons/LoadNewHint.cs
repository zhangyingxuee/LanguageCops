using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoadNewHint : MonoBehaviour
{
    [TextArea(2, 5)]
    public string[] hints;
    public TextMeshProUGUI Display;
    public SaveDataSO infoSO;

    public void LoadHint()
    {
        Display.text = hints[infoSO.Progress];
    }


}
