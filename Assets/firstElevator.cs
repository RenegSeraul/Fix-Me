using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class firstElevator : MonoBehaviour
{

    [SerializeField] float _triggerDistance = 1f; // the distance to trigger at
    public Animator _animator; // the Animator component to set "bool" of
    public GameObject _player;
    public GameObject firstFloor;
    public GameObject secondFloor;
    public GameObject thirdFloor;

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
    
    }

}
