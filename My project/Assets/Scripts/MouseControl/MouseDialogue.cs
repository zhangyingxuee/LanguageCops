using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseDialogue : MonoBehaviour, IPointerEnterHandler,IPointerExitHandler
{
    private bool state = true;

    void Start()
    {
        GameEvents.current.onStartDialogue += OnStartDialogue;
        GameEvents.current.onDialogueEnd += OnDialogueEnd;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {  
        if (state)
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
