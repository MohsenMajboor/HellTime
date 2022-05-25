using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dlg;

    public void NextDialogue()
    {
        FindObjectOfType<DialogueManager>().DisplayNextScentence(dlg);
    }

    public void RestartDialogue()
    {
        FindObjectOfType<DialogueManager>().RestartDialogue(dlg);
    }
}
