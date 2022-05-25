using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public TMPro.TextMeshProUGUI text;

    Queue<string> scentences;

    public float timeBtChars = 0.05f;
    float timeBtCharsUsed;
    private float nextCharDisplayTime;

    private bool firstRun = true;

    bool isTyping;

    AudioSource audio;


    [SerializeField] AudioClip dialogueSound;


    public event Action OnDialogueFinished;

    // Start is called before the first frame update
    void Start()
    {
        scentences = new Queue<string>();
        nextCharDisplayTime = Time.time + timeBtChars;
        audio = GetComponent<AudioSource>();
        timeBtCharsUsed = timeBtChars;
            audio.clip = dialogueSound;
    }

     void Update()
     {
        if(Input.GetKey(KeyCode.Space))
            timeBtCharsUsed = timeBtChars / 100;    
        else
            timeBtCharsUsed = timeBtChars;
     }

    public void RestartDialogue(Dialogue dlg)
    {
            scentences.Clear();

            foreach(string scent in dlg.scentences)
                scentences.Enqueue(scent);

            firstRun = false;

            if(scentences.Count == 0)
        {
            firstRun = true;
            return;
        }

        var scentence = scentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(SlowlyAddChars(scentence));
    }

    public void DisplayNextScentence(Dialogue dlg)
    {
        if(firstRun)
        {
          RestartDialogue(dlg);
        }
        
        if(scentences.Count == 0)
        {
            firstRun = true;
            OnDialogueFinished?.Invoke();
            return;
        }

        var scentence = scentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(SlowlyAddChars(scentence));
    }


    IEnumerator SlowlyAddChars(string scentence)
    {
        text.text = "";
        foreach (var chr in scentence)
        {
            yield return new WaitForSeconds(timeBtCharsUsed);
            text.text+=chr;
            audio.Play();
        }
    }
}
