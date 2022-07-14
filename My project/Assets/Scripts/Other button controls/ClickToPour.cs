using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToPour : MonoBehaviour
{
    public string Sound = "a";
    public GameObject selected;
    public bool is_filled;
    private bool is_selected;
    public PourManager manager;

    private void Start()
    {
        is_selected = false;
        selected.SetActive(is_selected);
    }
    public void Pour()
    {
        AudioManager.instance.Play(Sound);
        is_selected = !is_selected;
        selected.SetActive(is_selected);

        if (is_filled)
        {
            if (is_selected)
            {
                manager.fill();
            }
            else
            {
                manager.unfill();
            }
            
        }
        
    }

}
