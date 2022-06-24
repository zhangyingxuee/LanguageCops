using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class DragDropSO : ScriptableObject
{
    private int _objectType;
    public int ObjectType
    {
        get { return _objectType; }
        set { _objectType = value; }
    }

    private Vector2 _originalPos;
    public Vector2 OriginalPos
    {
        get { return _originalPos; }
        set { _originalPos = value; }
    }

    private bool[] _placeTaken = new bool[30];
    public bool[] PlaceTaken
    {
        get { return _placeTaken; }
        set { _placeTaken = value; }
    }

    private bool[] _placeConflict;
    public bool[] PlaceConflict
    {
        get { return _placeConflict; }
        set { _placeConflict = value; }
    }


    private int _objectSet;
    public int ObjectSet
    {
        get { return _objectSet; }
        set { _objectSet = value; }
    }

    private int[] _checkCorrectSet;
    public int[] CheckCorrectSet
    { 
        get { return _checkCorrectSet; }
        set { _checkCorrectSet = value; }
        
    }

    private int _correctSetNumber;

    public int CorrectSetNumber
    {
        get { return _correctSetNumber; }
        set { _correctSetNumber = value; }
    }



   
}
