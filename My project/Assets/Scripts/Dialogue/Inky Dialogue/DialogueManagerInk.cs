using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime; 
using UnityEngine.EventSystems;

public class DialogueManagerInk : MonoBehaviour
{
    public SaveDataSO dataSO;
   [SerializeField] private GameObject dialoguePanel;
   [SerializeField] private TextMeshProUGUI dialogueTextDisplay;

   [SerializeField] private GameObject textBox;

   [SerializeField] private GameObject nameBox;

   [SerializeField] private TextMeshProUGUI nameTextDisplay;

   [SerializeField] private GameObject spriteProfile;

   [SerializeField] private GameObject[] converInitialisor;

   [SerializeField] private GameObject popUp;

   [SerializeField] private GameObject player;

   [Header("Choices UI")]
   [SerializeField] private GameObject[] choices;
   private TextMeshProUGUI[] choiceText;

   private int currentThreshold;

    private bool specialDialoguePop;

    private Story currentStory;

    public bool dialogueIsPlaying;

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
        popUp.SetActive(false);
        specialDialoguePop = false;
        foreach (GameObject converButton in converInitialisor)
        {
           // converButton.SetActive(true);
        }
        


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
        
        GameEvents.current.onCheckpoint += DialogueAtCheckpoint;

    }

    private int checkPoint;

    private void DialogueAtCheckpoint(int progress)
    { 
        checkPoint = progress;
        Debug.Log("current progress = "+ checkPoint );
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

    public void EnterDialogueMode(TextAsset inkJSON, int threshold)
    { 
        popUp.SetActive(false);
        currentThreshold = threshold;

        // make the inkJSON file into a story 
        currentStory = new Story(inkJSON.text);
        nameTextDisplay.text = currentStory.TagsForContentAtPath("main")[0];
        currentStory.variablesState["player_name"] = dataSO.PlayerName;
        dialogueIsPlaying = true;
        dialoguePanel.SetActive(true);
        textBox.SetActive(true);
        nameBox.SetActive(true);
        spriteProfile.SetActive(true);
        foreach (GameObject converButton in converInitialisor)
        {
            //converButton.SetActive(false);
        }
        
        
        ChooseStory();
        
    }

    private void ExitDialogueMode()
        {
            dialogueIsPlaying = false;
            dialoguePanel.SetActive(false);
            textBox.SetActive(false);
            nameBox.SetActive(false);
            spriteProfile.SetActive(false);
            dialogueTextDisplay.text = "";
            foreach (GameObject converButton in converInitialisor)
            {
               // converButton.SetActive(true);
            }

            // check if there is special dialogue
            
            string specialLabel = currentStory.TagsForContentAtPath("main")[1];
            //Debug.Log(specialLabel);
            if (specialLabel == "Special" && specialDialoguePop )
            {
                //Debug.Log("The popup function is working.");
                Vector2 player_location = player.transform.position;
                Vector2 popup_location = popUp.transform.position;
                popUp.transform.position = new Vector2(player_location.x, popup_location.y);
                popUp.SetActive(true);
                specialDialoguePop = false;
            }
        GameEvents.current.DialogueEnd();
    }

    public void ChooseStory()
    { 
        Debug.Log("checkPoint = "+ checkPoint );
        //Debug.Log("currentThreshold = "+ currentThreshold);
        
        if (checkPoint < currentThreshold)
            { 
                //Debug.Log("pre is playing");
                currentStory.ChoosePathString("pre");
            }

        if (checkPoint > currentThreshold)
            { 
                //Debug.Log("post is playing");
                currentStory.ChoosePathString("post");
            }
        
        if (checkPoint == currentThreshold)
            { 
                //Debug.Log("main is playing");
                currentStory.ChoosePathString("main");
            specialDialoguePop = true;
            }
        ContinueStory();
        
    }

     public void ContinueStory()
     {
        if (currentStory.canContinue)
        {
            dialogueTextDisplay.text = currentStory.Continue();
            
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
        //Debug.Log("choose choice " + choiceIndex);
        // to allow the ink script to continue after you make the choice
        currentStory.ChooseChoiceIndex(choiceIndex); 
        ContinueStory();
        //Debug.Log("text after choice is displayed");
    }


    

    




}
