using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3 : MonoBehaviour
{
    public Animator animator;
    bool clicked;
    // Start is called before the first frame update
    void Start()
    {
        animator.SetTrigger("DialogueIn");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onClick()
    {
        StartCoroutine(DiagUt());
    }

    IEnumerator DiagUt()
    {
        yield return new WaitForSeconds(1);
        animator.SetTrigger("DialogueOut");
        yield return new WaitForSeconds(2);
    }
}
