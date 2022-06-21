using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MouseDialogue : MonoBehaviour, IPointerEnterHandler,IPointerExitHandler
{
    private bool state = true;
    private bool activate;

    void Start()
    {
        GameEvents.current.onStartDialogue += OnStartDialogue;
        GameEvents.current.onDialogueEnd += OnDialogueEnd;
        activate = GetComponent<Button>().interactable;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        activate = GetComponent<Button>().interactable;
        if (state & activate)
        { 
            Debug.Log("OnMouseOver is working");
            MouseControl.GetInstance().Dialogue();
        }        
        
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("OnMouseExit is working");
        MouseControl.GetInstance().Default();
    }

    private void OnStartDialogue()
    {
        state = false;
        MouseControl.GetInstance().Default();
    }
        private void OnDialogueEnd()
    {
        state = true;
    }
}
