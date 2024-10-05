using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level2 : MonoBehaviour
{

    public static bool clickedOnce = false;
    //Text _text;
    public TMP_Text _tmpProText;
    public GameObject subtitle;
    public GameObject elevator;
    //string writer;

    public Animator animator;
    public Animator _animator;

    public bool buttonisPressed = false;

    public static bool isLevel2;

    AudioManager audioManager;

    public Button btnInteract;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        try 
        {
            animator.SetTrigger("DialogueIn");
        }
        catch (UnassignedReferenceException ex)
        {
            Console.WriteLine($"UnAssigned Ref exce.: {ex}");
        }
    }

    private void Start()
    {
        //btnInteract.interactable = true;
    }

    
    //bool isRunning = false;
    private void Update()
    {
        /*
        if (isRunning == false)
        {
            if (buttonisPressed == true)
            {

                StartCoroutine(NextInstruction());
                isRunning = true;
            }
        }
        */

    }

    bool clickedtwice;
    public void onClick()
    {
        if (clickedOnce == false)
        {
            buttonisPressed = true;
            clickedOnce = true;
            StartCoroutine(DialogueOne());
            Level1.isLevel1 = false;
            isLevel2 = true;
            
            
        }

        else if (clickedOnce == true && clickedtwice == false)
        {
            clickedtwice = true;
            StartCoroutine(DialogueTwo());
        }
        
    }
    int i = 0;
    IEnumerator DialogueOne()
    {
        if (i == 0)
        {
            animator.SetTrigger("DialogueOut");
            yield return new WaitForSeconds(2);
            subtitle.SetActive(false);
            _tmpProText.text = "Find something to interact with and press interact button.";
            animator.SetTrigger("DialogueIn");
            i = 1;
            btnInteract.interactable = false;

        }
    }
    IEnumerator DialogueTwo()
    {
        animator.SetTrigger("DialogueOut");
        yield return new WaitForSeconds(2);
        _tmpProText.text = "Good! You can now interact with the objects.";
        animator.SetTrigger("DialogueIn");

        yield return new WaitForSeconds(3);
        animator.SetTrigger("DialogueOut");
        yield return new WaitForSeconds(2);
        _tmpProText.text = "Interactable objects will enable the interact button and vice versa to those who aren't.";
        animator.SetTrigger("DialogueIn");

        yield return new WaitForSeconds(5);
        animator.SetTrigger("DialogueOut");
        yield return new WaitForSeconds(2);
        _tmpProText.text = "Head to the elevator to proceed to the next level.";
        animator.SetTrigger("DialogueIn");

        yield return new WaitForSeconds(3);
        elevator.GetComponent<isPlayerClose>().enabled = true;
        _animator.SetBool("PlayerIsClose", true);
        audioManager.PlaySFX(audioManager.elevatorsound);
    }

    /*
    IEnumerator NextInstruction()
    {
        yield return new WaitForSeconds(6);
        animator.SetTrigger("DialogueOut");
        i = 1;
        yield return new WaitForSeconds(1.5f);
        _tmpProText.text = "Great job! Your character can now roam around!";
        animator.SetTrigger("DialogueIn");
        if (i == 1)
        {
            yield return new WaitForSeconds(6);
            animator.SetTrigger("DialogueOut");
            yield return new WaitForSeconds(2);
            _tmpProText.text = "Head to the elevator to move to the next level.";
            animator.SetTrigger("DialogueIn");



            yield return new WaitForSeconds(4);

            LevelOne.animator.SetBool("PlayerIsClose", true);
            LevelOne.ElevatorisOpen = true;
            audioManager.PlaySFX(audioManager.elevatorsound);
        }

    */




}



