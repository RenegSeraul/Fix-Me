using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class exit : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float _triggerDistance = 1f; // the distance to trigger at
    public Animator _animator; // the Animator component to set "bool" of
    public GameObject _player;
    public GameObject door;

    public Button btnExecute;

    public Animator transition;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    float _distance;
    public float distance
    {
        get { return _distance; }
        set
        {
            if (value != _distance) // prevents triggering things when value doesn't really change
            {
                _distance = value; // update value
                playerIsClose = _distance <= _triggerDistance; // compare distance and assign bool value
            }
        }
    }

    bool _playerIsClose;
    public bool playerIsClose
    {
        get { return _playerIsClose; }
        set
        {
            if (value == _playerIsClose)
                return; // return if value hasn't changed
            _playerIsClose = value;
            _animator.SetBool("PlayerIsClose", _playerIsClose); // trigger animator bool parameter

        }
    }
    void Awake()
    {
        _player = GameObject.FindWithTag("Player"); // make sure you tagged the Player with proper tag
    }
    void Update()
    {
        // updating the distance from player, eventually triggering the animation
        distance = Vector3.Distance(transform.position, _player.transform.position);
        // catch input if playerIsClose is true


        if (playerIsClose)
        {
            btnExecute.interactable = true;
        }
        else 
        {
            btnExecute.interactable = false;
        }
    
    }

    public void OnClick()
    {
        if (playerIsClose)
        {
            SceneManager.UnloadSceneAsync("Main");
            SceneManager.LoadSceneAsync("Menu");
        }

    }
}
