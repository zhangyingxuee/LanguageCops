using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupPage : MonoBehaviour
{
    public GameObject textBox;
    public GameObject nameText;

    public GameObject dialogueText;

    private void Start() 
    {
        nameText.SetActive(false);
        dialogueText.SetActive(false);
        textBox.SetActive(false);
    }

    public void appear()
    {
        nameText.SetActive(true);
        dialogueText.SetActive(true);
        textBox.SetActive(true);

    }

    public void disappear() 
    {
        
        nameText.SetActive(false);
        dialogueText.SetActive(false);
        textBox.SetActive(false);
    }
    
}
