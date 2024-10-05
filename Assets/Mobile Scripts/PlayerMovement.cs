using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    // --| Movement variables |--
    PlayerControls controlz;
    float directionz = 0; // --| This will get the player's input of left/right |--
    public float speedz = 250;
    public Rigidbody2D bodeh;

    // --| Animation variables |--
    public Animator animatorist;
    bool isFacingRoight = true;
    

    // --| This function calls before the Start function |--
    private void Awake()
    {
        // --| It will be called once the move action is performed |--
        controlz = new PlayerControls();
        controlz.Enable();

        // --| Once the move action is performed |--
        controlz.Land.Move.performed += idk =>
        {
            directionz = idk.ReadValue<float>(); // --| e.g., pressing left/right arrow will return -1/1 |--
        };
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bodeh.velocity = new Vector2(directionz * speedz * Time.deltaTime, bodeh.velocity.y);
        
        /*--| 
        Below will add speed value to the parameters 
        of the animation based on left/right value of directionz |--*/
        animatorist.SetFloat("Speed", Mathf.Abs(directionz)); 

        /* --| 
        This will flip the "scale" of the animation, 
        in the other words flipping the animation to the left/right |--*/
        if (isFacingRoight && directionz < 0 || !isFacingRoight && directionz > 0)
        {
            flippy();
        }
    }

    void flippy()
    {
        isFacingRoight = !isFacingRoight; // --| if it is false, return true, & vice versa |--

        // --| Changiing the x-Scale |--
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
    }
}
