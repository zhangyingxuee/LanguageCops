
using UnityEngine;
using UnityEngine.SceneManagement;


public class PhoneButtonUI : MonoBehaviour
{
    public Object NextScene;
    public void LoadNextScene()
    {
        SceneManager.LoadScene(NextScene.name);
    }
    
}
