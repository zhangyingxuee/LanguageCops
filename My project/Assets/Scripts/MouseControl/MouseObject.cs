using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseObject : MonoBehaviour, IPointerEnterHandler,IPointerExitHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {  
        Debug.Log("OnMouseOver is working");
        MouseControl.GetInstance().Clickable();
        
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("OnMouseExit is working");
        MouseControl.GetInstance().Default();
    }
}
