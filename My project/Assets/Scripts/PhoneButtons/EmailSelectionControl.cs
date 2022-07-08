using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EmailSelectionControl : MonoBehaviour
{
    public GameObject selected;
    public bool is_correct;
    public bool is_selected = false;
    public Emailmanager manager;

    public void ToggleSelection()
    {
        is_selected = !is_selected;
        selected.SetActive(is_selected);
        if (is_selected)
        {
            if (is_correct)
            {
                manager.CorrectSelect();
            }
            else
            {
                manager.IncorrectSelect();
            }
        }
        else
        {
            if (is_correct)
            {
                manager.CorrectDeselect();
            }
            else
            {
                manager.IncorrectDeselect();
            }
        }
        EventSystem.current.SetSelectedGameObject(null);

    }
}
