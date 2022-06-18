using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageUp : MonoBehaviour
{
    [SerializeField] private GameObject messagePage;

    public void Message()
    { 
        messagePage.SetActive(true);
    
    }
}
