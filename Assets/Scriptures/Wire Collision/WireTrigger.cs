using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WireTrigger : MonoBehaviour
{
    public GameObject wire;
    public Button InteractB;
    public static bool playerDetected;    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            playerDetected = true;
            //wire.SetActive(true);
            InteractB.interactable = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            playerDetected = false;
            InteractB.interactable = false;
        }
    }

    public void Update()
    {
        if (playerDetected )
        {
            InteractB.interactable = true;
        }
    }

    public void Activate() 
    {
        if (playerDetected && InteractB.interactable == true)
        {
            wire.SetActive(true);
        }
        
    }
}
