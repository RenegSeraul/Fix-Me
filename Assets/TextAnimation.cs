using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;
public class TextAnimation : MonoBehaviour
{
    Text _text;
    TMP_Text _tmpProText;
    string writer;

    Animator animator;

    [SerializeField] float delayBeforeStart = 0f;
    [SerializeField] float timeBtwChars = 0.1f;
    [SerializeField] string leadingChar = "";
    [SerializeField] bool leadingCharBeforeDelay = false;

    public bool buttonisPressed = false;

    // Use this for initialization
    void Start()
    {
        _text = GetComponent<Text>()!;
        _tmpProText = GetComponent<TMP_Text>()!;
        animator = GetComponent<Animator>();

        if (_text != null)
        {
            writer = _text.text;
            _text.text = "";

            StartCoroutine("TypeWriterText");
        }

        if (_tmpProText != null)
        {
            writer = _tmpProText.text;
            _tmpProText.text = "";

            StartCoroutine("TypeWriterTMP");
        }
    }
    bool isRunning = false;
    private void Update()
    {
        if (isRunning == false)
        {
            if (buttonisPressed == true)
            {
                StartCoroutine(NextInstruction());
                isRunning = true;
            }
        }
        
    }

    IEnumerator TypeWriterText()
    {
        _text.text = leadingCharBeforeDelay ? leadingChar : "";

        yield return new WaitForSeconds(delayBeforeStart);

        foreach (char c in writer)
        {
            if (_text.text.Length > 0)
            {
                _text.text = _text.text.Substring(0, _text.text.Length - leadingChar.Length);
            }
            _text.text += c;
            _text.text += leadingChar;
            yield return new WaitForSeconds(timeBtwChars);
        }

        if (leadingChar != "")
        {
            _text.text = _text.text.Substring(0, _text.text.Length - leadingChar.Length);
        }
    }

    IEnumerator TypeWriterTMP()
    {
        _tmpProText.text = leadingCharBeforeDelay ? leadingChar : "";

        yield return new WaitForSeconds(delayBeforeStart);

        foreach (char c in writer)
        {
            if (_tmpProText.text.Length > 0)
            {
                _tmpProText.text = _tmpProText.text.Substring(0, _tmpProText.text.Length - leadingChar.Length);
            }
            _tmpProText.text += c;
            _tmpProText.text += leadingChar;
            yield return new WaitForSeconds(timeBtwChars);

        }

        if (leadingChar != "")
        {
            _tmpProText.text = _tmpProText.text.Substring(0, _tmpProText.text.Length - leadingChar.Length);
        }
    }
    public bool clickedOnce = false;
    public void onClick()
    {
        if (clickedOnce == false)
        {
            _tmpProText.text = "";
            buttonisPressed = true;
            clickedOnce = true;
        }
        
        
    }
    int i = 0;
    IEnumerator NextInstruction()
    {
        if (i == 0)
        {
            yield return new WaitForSeconds(4);
            _tmpProText.text = leadingCharBeforeDelay ? leadingChar : "";
            writer = "Great job!";
            foreach (char c in writer)
            {

                _tmpProText.text += c;
                _tmpProText.text += leadingChar;
                yield return new WaitForSeconds(timeBtwChars);

            }
            
            yield return new WaitForSeconds(2);
            writer = "";
            _tmpProText.text = "";
            i = 1;

            writer = "Your character can now roam around!";

            _tmpProText.text = leadingCharBeforeDelay ? leadingChar : "";
            foreach (char c in writer)
            {

                _tmpProText.text += c;
                _tmpProText.text += leadingChar;
                yield return new WaitForSeconds(timeBtwChars);

            }

            yield return new WaitForSeconds(4);
            _tmpProText.text = leadingCharBeforeDelay ? leadingChar : "";
            writer = "Head to the elevator to move to the next level";

            foreach (char c in writer)
            {

                _tmpProText.text += c; 
                _tmpProText.text += leadingChar;
                yield return new WaitForSeconds(timeBtwChars);

            }


            yield return new WaitForSeconds(3);
            writer = "";
            _tmpProText.text = "";
            i = 2;
            animator.SetBool("PlayerIsClose", true);
        }
            


      
        
        
    }

}
