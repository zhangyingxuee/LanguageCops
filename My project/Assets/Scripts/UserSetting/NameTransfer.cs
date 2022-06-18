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

    public GameObject textDisplayBox;

    public GameObject continueButton;

    public GameObject newMsgButton;

    public GameObject messagePage;

    public GameObject messageContent;

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

    void Start()
    {
        inputField.SetActive(true);
        textDisplayBox.SetActive(false);
        newMsgButton.SetActive(false);
        messagePage.SetActive(false);
        messageContent.SetActive(false);

    }

    public void StoreName()
    {   

        Debug.Log("Store is working");
        nameEntered = inputField.GetComponent<TMP_InputField>().text;
        if (nameEntered == "")
        { 
            nameEntered = "Detective";
        }
        textDisplayBox.SetActive(true);
        textDisplay.text = "Welcome! " + nameEntered + "!";
        inputField.SetActive(false);
        continueButton.SetActive(false);
        newMsgButton.SetActive(true);

    
    }


}
