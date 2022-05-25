using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevelButtonHider : MonoBehaviour
{
    [SerializeField] DialogueManager dialogueManager;
    [SerializeField] GameObject button;


    private void OnEnable() {
        dialogueManager.OnDialogueFinished += UnHideButton; 
    }

    private void OnDisable() {
        dialogueManager.OnDialogueFinished -= UnHideButton; 
    }

    private void UnHideButton()
    {
        button.gameObject.SetActive(true); 
    }

    void HideButton()
    {
        button.gameObject.SetActive(false);
    }

    private void Start()
    {
        HideButton();
    }
}
