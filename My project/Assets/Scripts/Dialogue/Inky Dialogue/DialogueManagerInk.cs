using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime; 
using UnityEngine.EventSystems;

public class DialogueManagerInk : MonoBehaviour
{
   [SerializeField] private GameObject dialoguePanel;
   [SerializeField] private TextMeshProUGUI dialogueTextDisplay;

   [SerializeField] private GameObject textBox;

   [SerializeField] private GameObject nameBox;

   [SerializeField] private TextMeshProUGUI nameTextDisplay;

   [SerializeField] private GameObject spriteProfile;

   [SerializeField] private GameObject continueButton;

   [Header("Choices UI")]
   [SerializeField] private GameObject[] choices;
   private TextMeshProUGUI[] choiceText;


    private Story currentStory;

    private bool dialogueIsPlaying;

    private static DialogueManagerInk instance;

    private void Awake() 
    {
        if (instance != null) 
        {
            Debug.LogWarning("Found more than one Dialogue Manager in the scene");
        }
        instance = this;
    }

    public static DialogueManagerInk GetInstance() 
    {
        return instance;
    }

    private void Start() 
    {
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        textBox.SetActive(false);
        nameBox.SetActive(false);
        spriteProfile.SetActive(false);
        continueButton.SetActive(false);

        foreach (GameObject choice in choices)
        { 
            choice.SetActive(false);
        }

        // initialise choices text, make the index match

        choiceText = new TextMeshProUGUI[choices.Length];
        int index = 0;
        foreach (GameObject choice in choices)
        {
            choiceText[index] = choice.GetComponentInChildren<TextMeshProUGUI>(); //get the text on the button 
            index++;
        }

    }

    /*private void update() 
    { 
        if (!dialogueIsPlaying)
        { 
            return;
        }

        else
        {
            ContinueStory();
        }
    }*/

    public void EnterDialogueMode(TextAsset inkJSON)
    { 
        // make the inkJSON file into a story 
        currentStory = new Story(inkJSON.text);
        nameTextDisplay.text = currentStory.TagsForContentAtPath("main")[0];
        continueButton.SetActive(true);
        dialogueIsPlaying = true;
        dialoguePanel.SetActive(true);
        textBox.SetActive(true);
        nameBox.SetActive(true);
        spriteProfile.SetActive(true);
        continueButton.SetActive(true);
        
        
        ContinueStory();
        
    }

    private void ExitDialogueMode()
        {
            dialogueIsPlaying = false;
            dialoguePanel.SetActive(false);
            textBox.SetActive(false);
            nameBox.SetActive(false);
            spriteProfile.SetActive(false);
            continueButton.SetActive(false);
            dialogueTextDisplay.text = "";

        }

    public void ContinueStory()
    {
        if (currentStory.canContinue)
        {
            // .Continue() gives the next line 
            dialogueTextDisplay.text = currentStory.Continue();

            // display the choices, if any
            DisplayChoices();
        }
        else 
        {
            ExitDialogueMode();
        }

    }

    // Choice options 

    private void DisplayChoices()
    { 
        continueButton.SetActive(false);
        List<Choice> currentChoices = currentStory.currentChoices; // list of choices in the script
        if (currentChoices.Count > choices.Length) 
        {
            Debug.LogError("More choices were given than the UI can support.");

        }
        
        
        //display the necessary buttons for our choices 
        int index = 0;
        foreach (Choice choice in currentChoices)
        { 
            choices[index].gameObject.SetActive(true); //choose the number of button we need 
            choiceText[index].text = choice.text;
            index++;
        }
        //hide the remaining unused buttons 
        for (int i = index; i < choices.Length; i++)
        {
            choices[i].gameObject.SetActive(false);
        }

        //StartCoroutine(SelectFirstChoice());

    }


    /*private IEnumerator SelectFirstChoice()
        {   
            //event system need to clear the options and declare again to use the choice button 
            EventSystem.current.SetSelectedGameObject(null);
            yield return new WaitForEndOfFrame();
            EventSystem.current.SetSelectedGameObject(choices[0].gameObject);
        }*/
    
    public void MakeChoice(int choiceIndex)
    {
        continueButton.SetActive(true);
        Debug.Log(choiceIndex);
        // to allow the ink script to continue after you make the choice
        currentStory.ChooseChoiceIndex(choiceIndex); 
        ContinueStory();
        Debug.Log("continue story is working");
    }


}
