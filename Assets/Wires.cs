using System.Collections;
using System.Collections.Generic;
//using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;

public class Wires : MonoBehaviour
{
    public static bool grounded;

    // Start is called before the first frame update
    [SerializeField] float _triggerDistance = 15f; // the distance to trigger at
    public GameObject _player;

    public static bool PlayerisClose;

    // Start is called before the first frame update

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
            grounded = value;

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
    }

}
