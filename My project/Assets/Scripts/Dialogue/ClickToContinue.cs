using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToContinue : MonoBehaviour
{   
    
    // Update is called once per frame
    void Update()
    {   
           if (Input.GetMouseButtonDown(0))
            {
                FindObjectOfType<DialogueManager>().DisplayNextSentence();
            }
             
    }
    
}
