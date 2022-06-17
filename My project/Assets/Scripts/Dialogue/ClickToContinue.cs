using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToContinue : MonoBehaviour
{   
    [SerializeField] private GameObject choiceButton;
    
    // Update is called once per frame
    void Update()
    {   
           if (Input.GetMouseButtonDown(0) && choiceButton.activeSelf == false)
            {

                FindObjectOfType<DialogueManagerInk>().ContinueStory();
            }
             
    }
    
}
