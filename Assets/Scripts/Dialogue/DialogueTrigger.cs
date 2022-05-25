using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dlg;

    public void TriggerDialouge()
    {
        FindObjectOfType<DialogueManager>().DisplayNextScentence(dlg);
    }
}
