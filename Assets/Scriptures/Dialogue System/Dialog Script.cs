using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogScript : MonoBehaviour
{
    // -- All Fields Below --

    // -- Window --
    public GameObject window;

    // -- Text component --
    public TMP_Text dialogueText;

    // -- Indicator --
    public GameObject indicator;

    // -- Dialogue list --
    public List<string> dialogues;

    // -- Writing Speed --
    public float writingSpeed;

    // -- Button Interact --
    public Button Buttn;

    // -- Index on dialogue --
    private int index;

    // -- Character index --
    private int charIndex;

    // -- Started Boolean --
    private bool started;

    // -- Waits for next Boolean --
    private bool waitForNext;

    // -- The initialization of the script --
    private void Awake()
    {
        ToggleIndicator(false);
        ToggleWindow(false);
    }


    // -- Easier way of showing a window using caller method --
    private void ToggleWindow(bool show)
    {
        window.SetActive(show);
    }
    public void ToggleIndicator(bool show)
    {
        indicator.SetActive(show);
    }
    
    // -- Start Dialogue --
    public void StartDialogue() 
    {
        // -- Prevents the player from starting the dialogue again --
        if (started) 
            return;

        NewBehaviourScript.pressed = false;
        // -- Boolean which indicates that it has started --
        started = true;
        // -- Show the window --
        ToggleWindow(true);
        // -- Hide the indicator --
        ToggleIndicator(false);
        // -- Start with first dialogue --
        GetDialogue(0);
        
    }

    // -- Starts at the very beginning of the text character --
    private void GetDialogue(int i)
    {
        // -- Start index at zero --
        index = i;
        // -- Resets the character index --
        charIndex = 0;
        // -- Clears the dialogue component text --
        dialogueText.text = string.Empty;
        // -- Start writing --
        StartCoroutine(Writing());
    }

    // -- End Dialogue --
    public void EndDialogue() 
    {
        // -- Disable Started --
        started = false;
        // -- Disable waitForNext --
        waitForNext = false;
        // -- It makes sure that everything is halted or stopped | Stopping all IEnumerators --
        StopAllCoroutines();
        // -- Hide the window --
        ToggleWindow(false);
    }



    // -- Writing Logic --
    IEnumerator Writing() 
    {
        // -- This will make the writing seem more natural ish --
        yield return new WaitForSeconds(writingSpeed);

        string currentDialogue = dialogues[index];
        // -- Write the character | It takes the first dialogue of "Hello" and writes "H" first --
        dialogueText.text += currentDialogue[charIndex];
        // -- Increase the character index --
        charIndex++;
        // -- Makes sure that it has reached the end of the sentence --
        if (charIndex < currentDialogue.Length) 
        {
            // -- Wait x seconds | Based on user input properties --
            yield return new WaitForSeconds(writingSpeed);
            // -- Restart the same process --
            StartCoroutine(Writing());
        }
        else
        {
            // -- End this sentence and wait for the next one --
            waitForNext = true;
        }
        
    }

    public void Update()
    {
        // -- This ensures that it will not go through what is below this return condition --
        if (!started)
            return;

        if (waitForNext && NewBehaviourScript.pressed == true) // NewBehaviorScript.pressed
        {
            NewBehaviourScript.pressed = false;
            waitForNext = false;
            // -- Increased value instead of 0 it becomes 1 --
            index++;

            // -- Checks if we are in the scope of dialogue lists --
            if (index < dialogues.Count)
            {
                // -- If so, fetch the next dialogue --
                // -- Same process of writing the characters --
                GetDialogue(index);
            }
            else 
            {
                // -- Toggles the indicator once more | This will make it talk again --
                ToggleIndicator(true);
                // -- If not, end dialogue process --
                EndDialogue();
            }
            
        }
    }

}
