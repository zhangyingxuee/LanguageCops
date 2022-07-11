using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class VMachineButton : MonoBehaviour
{
    public Button[] colour;
    public Button[] number;
    public int CorrectColour;
    public int CorrectNumber;
    public int checkpt;
    public GameObject Correct;
    public GameObject Incorrect;
    public GameObject this_scene;
    private bool colour_state;
    private bool number_state;
    private int current_colour;
    private int current_number;

    public void ResetPage()
    {
        for(int i = 0; i < colour.Length; i++)
        {
            colour[i].interactable = true;
            number[i].interactable = true;
        }
        colour_state = false;
        number_state = false;
        Incorrect.SetActive(false);
    }

    public void SelectColour(int id)
    {
        for (int i = 0; i < colour.Length; i++)
        {
            if (i != id)
            {
                colour[i].interactable = colour_state;
            }
        }
        if (!colour_state)
        {
            current_colour = id;
        }
        colour_state = !colour_state;
        EventSystem.current.SetSelectedGameObject(null);
    }
    public void SelectNumber(int id)
    {
        for (int i = 0; i < number.Length; i++)
        {
            if (i != id)
            {
                number[i].interactable = number_state;
            }
        }
        if (!number_state)
        {
            current_number = id;
        }
        number_state = !number_state;
        EventSystem.current.SetSelectedGameObject(null);
    }
    public void Submit()
    {
        if(colour_state == true & number_state == true & current_colour == CorrectColour & current_number == CorrectNumber )
        {
            Correct.SetActive(true);
            Invoke("ClosePage", 1f);
        } else
        {
            Incorrect.SetActive(true);
            Invoke("ResetPage", 0.5f);
            EventSystem.current.SetSelectedGameObject(null);
        }
    }

    private void ClosePage()
    {
        this_scene.SetActive(false);
        GameEvents.current.Checkpoint(checkpt);
    }
}
