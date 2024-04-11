using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class teleportFirst : MonoBehaviour
{
    public Transform firstElev;
    public GameObject player;
    public GameObject panel;
    public Animator transition;
    // Start is called before the first frame update
    void Start()
    {
        firstElev = GameObject.FindGameObjectWithTag("Elevator1").GetComponent<Transform>();
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OnClick()
    {
            player.transform.position = new Vector2(firstElev.position.x, firstElev.position.y);
            StartCoroutine(Starting());
            //transition.SetTrigger("Ending");
            //transition.SetTrigger("Begin");
            panel.SetActive(false);
        



    }

    IEnumerator Starting()
    {
        //transition.SetTrigger("Starting");
        yield return new WaitForSecondsRealtime(1f);
        player.transform.position = new Vector2(firstElev.position.x, firstElev.position.y);
        yield return new WaitForSecondsRealtime(1f);
    }
}
