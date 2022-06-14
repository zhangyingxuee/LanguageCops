using System.Collections;  
using System.Collections.Generic;  
using UnityEngine;

public class Movement2 : MonoBehaviour
{
   public Transform player; 
   public Vector3 offset;

   public GameObject textBox;
   private bool AllowMovement = true;

    void Start()
    {
        GameEvents.current.onCloseCafe += toggleAllowance;
    }
    private void toggleAllowance()
    {
        AllowMovement = !AllowMovement;
        //Debug.Log(AllowMovement);
    }
    // Update is called once per frame
    void Update()
    {
        
        if (textBox.activeSelf==false & AllowMovement == true)
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                player.position += offset;
            }
        
            if (Input.GetKey(KeyCode.LeftArrow))
            { 
                player.position -= offset;
            }
        }
        
    }

}
