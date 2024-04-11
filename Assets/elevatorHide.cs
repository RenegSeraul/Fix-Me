using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elevatorHide : MonoBehaviour
{
    public GameObject elevatorPanel;
    // Start is called before the first frame update
    void Start()
    {
        elevatorPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
