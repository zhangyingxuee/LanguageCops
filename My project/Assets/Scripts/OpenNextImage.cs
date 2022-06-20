using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenNextImage : MonoBehaviour
{
    public GameObject NextImage;
    public GameObject CurrentImage;

    public void ChangeImage()
    {
        NextImage.SetActive(true);
        CurrentImage.SetActive(false);
    }
}
