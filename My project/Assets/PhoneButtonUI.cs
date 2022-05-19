
using UnityEngine;
using UnityEngine.SceneManagement;


public class PhoneButtonUI : MonoBehaviour
{
    public Object phone;
    public void LoadPhone()
    {
        SceneManager.LoadScene(phone.name);
    }
    
}
