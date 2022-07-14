using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class EmailSelectionControl : MonoBehaviour
{
    public string Sound = "a";
    public GameObject selected;
    public bool is_correct;
    public bool is_selected = false;
   // public Emailmanager manager;

  //  private bool all_select_state = false;

    private void Start()
    {
        GameEvents.current.onAllSelect += OnAllSelect;
        GameEvents.current.onAllReset += OnAllReset;
        selected.SetActive(false);
    }
    public void ToggleSelection()
    {
        AudioManager.instance.Play(Sound);
        is_selected = !is_selected;
        selected.SetActive(is_selected);
        if (is_selected)
        {
            if (is_correct)
            {
                //manager.CorrectSelect();
                GameEvents.current.Selectbutton(1);
            }
            else
            {
                //manager.IncorrectSelect();
                GameEvents.current.Selectbutton(0);
            }
        }
        else
        {
            if (is_correct)
            {
                //manager.CorrectDeselect();
                GameEvents.current.Deselectbutton(1);
            }
            else
            {
                //manager.IncorrectDeselect();
                GameEvents.current.Deselectbutton(0);
            }
        }
        EventSystem.current.SetSelectedGameObject(null);

    }

    private void OnAllSelect(int state)
    {
        if(!is_selected)
        {
            //Debug.Log("All selected" + this.name);
            if (state == 0)
            {
                GetComponent<Button>().interactable = true;
               // all_select_state = false;
            }
            else
            {
                GetComponent<Button>().interactable = false;
              //  all_select_state = true;

            }
        }
    }

    private void OnAllReset()
    {
        is_selected = false;
       // all_select_state = false;
        selected.SetActive(is_selected);
        GetComponent<Button>().interactable = true;
    }

    private void OnDestroy()
    {
        GameEvents.current.onAllSelect -= OnAllSelect;
        GameEvents.current.onAllReset -= OnAllReset;
 
    }
}
