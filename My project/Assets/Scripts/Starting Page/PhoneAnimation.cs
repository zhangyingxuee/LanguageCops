using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneAnimation : MonoBehaviour
{
    public Animator animator;
    // Start is called before the first frame update
    
    void Start()
    { 
        animator.SetBool("OnClick", false);
    
    }

    public void Test()
    { 
        Debug.Log("Testing");
    }
    
    public void ClickToOff()
    {
        Debug.Log("The Button is Clicked");
        animator.SetBool("OnClick", true);
    
    }
}
