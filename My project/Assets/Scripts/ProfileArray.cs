using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ProfileArray : MonoBehaviour
{
    public RawImage profilePic; 

    public Texture[] heads;

    public void GetImage(int index)
    { 
        profilePic.texture = heads[index];

    }
    
}
