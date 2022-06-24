using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseControl : MonoBehaviour
{
    public Texture2D defaultCursor, clickableCursor, dialogueCursor;
    
    public static MouseControl instance;

    private void Awake()
    { 
        if (instance == null)
        { 
            instance = this;
            //DontDestroyOnLoad(gameObject);
        }
        else
        {
            //Destroy(gameObject);
        
        }
            

    }

    public static MouseControl GetInstance()
    {
        return instance;
    }
    
    void Start()
    { 
        Default();
    }
    
    public void Clickable()
    { 
        Cursor.SetCursor(clickableCursor, Vector2.zero, CursorMode.Auto);
    }

    public void Default()
    { 
        Cursor.SetCursor(defaultCursor, Vector2.zero, CursorMode.Auto);
    }

    public void Dialogue() 
    {
        Cursor.SetCursor(dialogueCursor, Vector2.zero, CursorMode.Auto);
    }


}
