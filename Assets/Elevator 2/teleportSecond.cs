using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleportSecond : MonoBehaviour
{
    public Transform secondElevator;
    public GameObject player;
    public GameObject panel;
    // Start is called before the first frame update
    void Start()
    {
        secondElevator = GameObject.FindGameObjectWithTag("Elevator2").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        player.transform.position = new Vector2(secondElevator.position.x, secondElevator.position.y);
        panel.SetActive(false);
    }
}
