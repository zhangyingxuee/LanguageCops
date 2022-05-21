using System.Collections;  
using System.Collections.Generic;  
using UnityEngine;

public class Movement2 : MonoBehaviour
{
   public Transform player; 
   public Vector3 offset;

   public GameObject textBox;


    // Update is called once per frame
    void Update()
    {
        if (textBox.activeSelf==false)
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
