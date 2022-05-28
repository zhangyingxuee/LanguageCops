using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ProfileArray : MonoBehaviour
{
    public RawImage profilePic; 

    public Texture[] heads = new Texture[3];

    public int[] names = {0, 1, 2};

    public void GetImage(int index)
    { 
        profilePic.texture = heads[index];

    }
    
}
