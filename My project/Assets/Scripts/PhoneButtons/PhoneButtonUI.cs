
using UnityEngine;
using UnityEngine.SceneManagement;


public class PhoneButtonUI : MonoBehaviour
{
    //public Object NextScene;
    public int SceneIndex;
    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneIndex);
       
    }
    
}
