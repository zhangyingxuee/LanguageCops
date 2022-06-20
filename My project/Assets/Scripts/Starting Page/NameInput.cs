using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NameInput : MonoBehaviour
{

    [SerializeField] private float delayInput;
    
    [SerializeField] private GameObject[] userInputField;

    public void DoDelayAction()
    {
        Debug.Log("delay(button) is working");
        StartCoroutine(DelayAction(delayInput));
        foreach (GameObject thing in userInputField)
        {
            thing.SetActive(true);
            Debug.Log("setting active");
        }

    }
 
    IEnumerator DelayAction(float delayTime)
    {
        Debug.Log("delay(function) is working");
        Debug.Log(delayTime);
        //Wait for the specified delay time before continuing.
        yield return new WaitForSeconds(delayTime);
        
        //Do the action after the delay time has finished.
    }
}
