using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneToTransition : MonoBehaviour
{
    private float second = 0f;
    
    public Animator animator;
    
    void Update()
    {   
        animator.SetFloat("Wait", second);
        second++;
    }
}
