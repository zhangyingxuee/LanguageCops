using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Used for passing the dialogue used to the dialogue manager 

// in order for these var to be editable in the inspector, we have to make it serialisable and public
[System.Serializable]
public class Dialogue 
{
    
    public string name;

    
    // this attribute of (min,max) will make the textbox in the inspector larger 
    [TextArea(3,10)] 
    public string[] sentences;
    

}
