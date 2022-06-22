using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageUp : MonoBehaviour
{
    [SerializeField] private GameObject messagePage;
    [SerializeField] private GameObject messageContent;

    [SerializeField] private Animator messageAppear;

    [SerializeField] private GameObject title1;

    [SerializeField] private GameObject title2;

    [SerializeField] private GameObject blackSquare;

    public void Message()
    { 
        messagePage.SetActive(true);
        messageContent.SetActive(true);
        messageAppear.SetBool("OnClick",true);
        title1.SetActive(true);
        title2.SetActive(true);
        blackSquare.SetActive(true);
    }
}
