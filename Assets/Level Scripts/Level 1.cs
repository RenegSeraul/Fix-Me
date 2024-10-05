using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;
public class Level1 : MonoBehaviour
{

    //Text _text;
    public TMP_Text _tmpProText;
    //string writer;

    public Animator animator;
    public Animator _animator;

    public bool buttonisPressed = false;

    AudioManager audioManager;

    public Button buttonInteract;

    public static bool isLevel1;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        animator.SetTrigger("DialogueIn");
    }

    // Use this for initialization
    void Start()
    {
        /*animator = GetComponent<Animator>();
        _animator = GetComponent<Animator>();*/

    }
    bool isRunning = false;
    int i = 0;
    private void Update()
    {
        if (isRunning == false)
        {
            if (buttonisPressed == true)
            {
                
                StartCoroutine(NextInstruction());
                isRunning = true;
                if (isRunning == true)
                {
                    isLevel1 = true;
                }
            }
        }

    }
    
    public bool clickedOnce = false;
    public void onClick()
    {
        if (clickedOnce == false)
        {
            buttonisPressed = true;
            clickedOnce = true;
        }


    }

    // public void onElevatorClick()
    // {
    //     if (isPlayerClose.playerisClose)
    //     {
    //         SceneManager.LoadSceneAsync("Level2");
    //     }
        
    // }
    
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

            _animator.SetBool("PlayerIsClose", true);
            audioManager.PlaySFX(audioManager.elevatorsound);
        }

        




    }

}
