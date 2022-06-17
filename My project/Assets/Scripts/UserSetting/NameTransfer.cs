using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class NameTransfer : MonoBehaviour
{
    public string nameEntered;
    public GameObject inputField;

    public TMP_Text textDisplay;

    // if cannot access, use PlayerPrefs, SetString, GetString, 
    private static NameTransfer instance;

    private void Awake() 
    {
        if (instance != null) 
        {
            Debug.LogWarning("Found more than one Dialogue Manager in the scene");
        }
        instance = this;
    }

    public static NameTransfer GetInstance() 
    {
        return instance;
    }

    public void StoreName()
    { 
        Debug.Log("Store is working");
        nameEntered = inputField.GetComponent<TMP_InputField>().text;
        textDisplay.text = "Welcome" + nameEntered;
    
    }


}
