using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class ItemSlot : MonoBehaviour, IDropHandler
{
    private Vector2 originalPosition;

    private bool correctObject;

    private int typeOnDrag;

    public DragDropSO dataSO;

    [SerializeField] private int slotName;

    void Start()
    { 
        Debug.Log("slotName" + slotName);
        Debug.Log("PlaceTaken bool" + dataSO.PlaceTaken[slotName]);
        correctObject = false;
        dataSO.PlaceTaken[slotName] = false;
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            //Debug.Log("placeTaken before Snap =" + dataSO.PlaceTaken[slotName]);
            
            if (correctObject == true)

            {   

                 //Debug.Log("placeTaken first if =" + dataSO.PlaceTaken[slotName]);
                if (dataSO.PlaceTaken[slotName] == false)
                {
                    eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
                    correctObject = false;
                    dataSO.PlaceTaken[slotName] = true;
                    Debug.Log("Conflict second if =" + dataSO.PlaceConflict[slotName]);

                    dataSO.CheckCorrectSet[slotName] = dataSO.ObjectSet;
                    Debug.Log("slotName "+ slotName + "store object of type " +  dataSO.ObjectSet);
                    AudioManager.instance.Play("g");

                }
                else
                {
                    Debug.Log("Go back is trigger inside");

                    originalPosition = dataSO.OriginalPos;
                    eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = originalPosition;
                }
                


            }
            else
            { 
                //Debug.Log("Go back is trigger outside");

                originalPosition = dataSO.OriginalPos;
                eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = originalPosition;
            }
        
        }

    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        typeOnDrag = dataSO.ObjectType;

        //Debug.Log("Trigger!");
       
        if (slotName == typeOnDrag)
        {   
            //Debug.Log("Object is correct type");
            Debug.Log("objectType = "+typeOnDrag+"slotName = " + slotName + " in triggerEnter");
            correctObject = true;
        }
        else
        { 
            correctObject = false;
        }
     
    }

    /*private void OnTriggerExit2D(Collider2D collider)
    {
        dataSO.PlaceTaken[slotName] = false;
        //dataSO.PlaceConflict[slotName] = false;
        Debug.Log("placeTaken in TriggerExit =" + dataSO.PlaceTaken[slotName]);
    }*/



}
