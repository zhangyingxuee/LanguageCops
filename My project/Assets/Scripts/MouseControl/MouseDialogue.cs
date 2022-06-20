using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseDialogue : MonoBehaviour, IPointerEnterHandler,IPointerExitHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {  
        Debug.Log("OnMouseOver is working");
        MouseControl.GetInstance().Dialogue();
        
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("OnMouseExit is working");
        MouseControl.GetInstance().Default();
    }
}
