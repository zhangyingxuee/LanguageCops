using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private Canvas canvas;

    private RectTransform rectTransform;

    //disable the item from capturing event 
    // let the slot to capture even instead
    private CanvasGroup canvasGroup;

    public int objectType;

    public int objectSet; // 0 means not correct, 123 is three sets respectively

    private Vector2 originalPosition;

    
    public DragDropSO dataSO;

    private bool updateDataSO;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        updateDataSO = true;
        originalPosition = gameObject.GetComponent<RectTransform>().anchoredPosition;
        
        Debug.Log(originalPosition);
        
    }

    private void Start()
    {
        GameEvents.current.onSubmit += OnSubmit;
    }


    public void OnPointerDown(PointerEventData eventData)
    { 
        //Debug.Log("OnPointDown");
        

    
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        //Debug.Log("OnBeginDrag");
        canvasGroup.blocksRaycasts = false;
        canvasGroup.alpha = 0.6f;
        /*if (updateDataSO)
        { 
            dataSO.OriginalPos = originalPosition;
            updateDataSO = false;
        }*/
        
    }

    public void OnDrag(PointerEventData eventData)
    { 
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        dataSO.ObjectType = objectType;
        if (dataSO.PlaceTaken[objectType])
        {
            dataSO.PlaceConflict[objectType] = true;
        }
        dataSO.OriginalPos = originalPosition;
        dataSO.ObjectSet = objectSet;
        
    }

    public void OnEndDrag(PointerEventData eventData)
    { 

        if (dataSO.PlaceConflict[objectType] == true)
        { 
            //originalPosition = dataSO.OriginalPos;
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = originalPosition;
            dataSO.PlaceConflict[objectType] = false;
        }


        //Debug.Log("OnEndDrag");
        canvasGroup.blocksRaycasts = true;
        canvasGroup.alpha = 1f;
       // Debug.Log(dataSO.ObjectType);
        Debug.Log(dataSO.PlaceTaken[objectType] + "on End Drag");
        
    }

    private void OnSubmit(int id)
    {
        if (dataSO.CheckCorrectSet[0] == dataSO.CheckCorrectSet[1] & dataSO.CheckCorrectSet[0] == dataSO.CheckCorrectSet[2])
        {
            if(id == objectSet)
            {
                Destroy(gameObject);
            } 

            if(id != objectSet)
            {
                gameObject.GetComponent<RectTransform>().anchoredPosition = originalPosition;
            }
        } 
        else 
        {
            if(id != objectSet)
            {
                gameObject.GetComponent<RectTransform>().anchoredPosition = originalPosition;
            }
        }

    }

    void OnDestroy()
    {
        GameEvents.current.onSubmit -= OnSubmit;
    }

}
