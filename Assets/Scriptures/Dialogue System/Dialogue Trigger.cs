using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    // -- References the Dialog Script.cs --
    public DialogScript dialogueScript;
    // -- Interact Button --
    //public Button buttoh;

    // -- Bool pressed button --
    public static bool pressed = false;

    public static bool playerDetected;    

    // -- Detect trigger with player --
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // -- If triggered with the player, enable playerDetected and show indicator --
        if(collision.tag == "Player")
        {
            playerDetected = true;
            //buttoh.interactable = true;
            // -- If detected, show the indicator --
            dialogueScript.ToggleIndicator(playerDetected);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // -- If it losts trigger with the player, disable playerDetected and hide indicator --
        if(collision.tag == "Player")
        {
            playerDetected = false;
            //buttoh.interactable = false;
            // -- If not detected, hide the indicator --
            dialogueScript.ToggleIndicator(playerDetected);
            // -- Ends the dialogue when Player moves away from collision --
            dialogueScript.EndDialogue();
        }
    }
    
    
    // -- While detected, if we interact, start the dialogue --
    public void ButtonPressed()
    {
        // Input.GetKeyDown(KeyCode.E)
        pressed = !pressed;
        if (playerDetected && pressed == true) 
        {
            dialogueScript.StartDialogue();
            
        }
        // else
        // {
        //     pressed = false;
        // }
        //pressed = false;
    }


    // public void ButtonPressed()
    // {
    //     if (playerDetected == true) 
    //     {
    //         pressed = true;
    //     }
    // }
}
