using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneToTransition : MonoBehaviour
{
    private float second = 0f;
    
    public Animator animator;

    
    void Update()
    {   
        if (this.animator.GetCurrentAnimatorStateInfo(0).IsName("Animation_messagePopUp") && second < 300f)
        {
            animator.SetFloat("Wait", second);
            second++;
        }



    }
}
