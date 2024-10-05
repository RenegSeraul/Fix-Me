using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputSystem : MonoBehaviour
{
    #region  -- Varzz --
    [Header("Movement")]
    public Rigidbody2D bodeh;
    public float Speed = 5f;
    float horizontalMove;

    [Header("Jumping")]
    public float jumpPower = 10f;

    [Header("Animator")]
    public Animator anim;
    private bool isFacingRoight = true;
    #endregion

    // Update is called once per frame
    void Update()
    {
        bodeh.velocity = new Vector2(horizontalMove * Speed, bodeh.velocity.y);

        anim.SetFloat("Speed", bodeh.velocity.magnitude); 

        if (!isFacingRoight && horizontalMove > 0f)
        {
            Flippy();
        }
        else if (isFacingRoight && horizontalMove < 0f)
        {
            Flippy();
        }
    }

    #region -- Flips animation --
    public void Flippy()
    {
        isFacingRoight = !isFacingRoight;
        Vector3 localS = transform.localScale;
        localS.x *= -1f;
        transform.localScale = localS;
    }
    #endregion

    #region -- Movement --
    // -- Movement ref --
    public void Move(InputAction.CallbackContext context) 
    {
        horizontalMove = context.ReadValue<Vector2>().x;
    }
    #endregion

    // -- Jump Ref --
    #region -- Jump --
    public void Jump(InputAction.CallbackContext context) 
    {
        if (context.performed) 
        {
            // -- hold down button = full height  --
            bodeh.velocity = new Vector2(bodeh.velocity.x, jumpPower);
        }
        else if (context.canceled)
        {
            // -- lighter jump button = half the height--
            bodeh.velocity = new Vector2(bodeh.velocity.x, bodeh.velocity.y * 0.5f);
        }
    }
    #endregion
}
