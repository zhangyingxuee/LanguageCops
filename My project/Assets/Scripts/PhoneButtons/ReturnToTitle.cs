using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToTitle : MonoBehaviour
{
    public int SceneIndex;
    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneIndex);

    }
}
