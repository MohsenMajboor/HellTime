using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public TMPro.TextMeshProUGUI text;

    Queue<string> scentences;

    public float timeBtChars = 0.05f;
    private float nextCharDisplayTime;

    private bool firstRun = true;

    bool isTyping;

    // Start is called before the first frame update
    void Start()
    {
        scentences = new Queue<string>();
        nextCharDisplayTime = Time.time + timeBtChars;
    }

    public void DisplayNextScentence(Dialogue dlg)
    {
        if(firstRun)
        {
            scentences.Clear();

            foreach(string scent in dlg.scentences)
                scentences.Enqueue(scent);

            firstRun = false;
        }

        
        if(scentences.Count == 0)
            return;

        var scentence = scentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(SlowlyAddChars(scentence));
    }


    IEnumerator SlowlyAddChars(string scentence)
    {
        text.text = "";
        foreach (var chr in scentence)
        {
            yield return new WaitForSeconds(timeBtChars);
            text.text+=chr;
        }
    }
}
