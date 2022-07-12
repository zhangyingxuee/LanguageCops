using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public SaveDataSO dataSO;

    public TextMeshProUGUI nameText;

    public TextMeshProUGUI dialogueText;

    //Using class Queue with type string for dialogue, like an array, 5-fold collection, 1st in, 1st out 
    private Queue<string> sentences; 
    
    public GameObject textBox;
    public GameObject nameBox;


    public GameObject dialogueBox;

    public GameObject image;

    public GameObject popUp;

    public GameObject player;

    public string nameWithGrammar;

    private bool specialDialogue;


    // Start is called before the first frame update
   
    void Start()
    {
        //initiate an instance "sentence" using the constructor 
        sentences = new Queue<string>(); 
        
        //set everything as default 
        nameBox.SetActive(false);
        dialogueBox.SetActive(false);
        textBox.SetActive(false);
        image.SetActive(false);
        popUp.SetActive(false);
        specialDialogue = false;
        
    }

    public void StartDialogue (Dialogue dialogue)
    { 
        nameBox.SetActive(true);
        dialogueBox.SetActive(true);
        textBox.SetActive(true);
        image.SetActive(true);
        popUp.SetActive(false);
        
        if (dialogue.name == "Detective")
        {
            if (dataSO.PlayerName == "")
            {
                nameText.text = "Povas Lirras";
            }
            else
            {
                nameText.text = dataSO.PlayerName;
            }
            
        }
        else
        {
            nameText.text = dialogue.name;
        }
        
        
        

        // Make a empty queue 
        sentences.Clear();

        // Add every sentence in the dialogue object 
        foreach (string sentence in dialogue.sentences)
        { 
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();

    }

     public void DisplayNextSentence() 
     {
        if (sentences.Count == 0)
        { 
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        
        dialogueText.text = sentence;
     }

     
    
     void EndDialogue() 
     {
        nameBox.SetActive(false);
        dialogueBox.SetActive(false);
        textBox.SetActive(false);
        image.SetActive(false);
        if (specialDialogue)
        {
            Vector2 player_location = player.transform.position;
            Vector2 popup_location = popUp.transform.position;
            popUp.transform.position = new Vector2(player_location.x, popup_location.y);
            popUp.SetActive(true);
        }
        specialDialogue = false;
        GameEvents.current.DialogueEnd();
    }

 
     public void SpecialDialogue()
     {
            specialDialogue = true;
        
     }

    
}
