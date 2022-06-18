using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageUp : MonoBehaviour
{
    [SerializeField] private GameObject messagePage;
    [SerializeField] private GameObject messageContent;

    [SerializeField] private Animator messageAppear;

    public void Message()
    { 
        messagePage.SetActive(true);
        messageContent.SetActive(true);
        messageAppear.SetBool("OnClick",true);

    }
}
