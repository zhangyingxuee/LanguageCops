using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEndDIalogue : MonoBehaviour
{
    public void TriggerEndDialogue()
    {
        GameEvents.current.DialogueEnd();
    }
}
