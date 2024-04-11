using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleportThird : MonoBehaviour
{
    public Transform thirdElevator;
    public GameObject player;
    public GameObject panel;
    // Start is called before the first frame update
    void Start()
    {
        thirdElevator = GameObject.FindGameObjectWithTag("Elevator3").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        player.transform.position = new Vector2(thirdElevator.position.x, thirdElevator.position.y);
        panel.SetActive(false);
    }
}
