using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3 : MonoBehaviour
{
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator.SetTrigger("DialogueIn");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
