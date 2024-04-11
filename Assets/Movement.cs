using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEditor.Tilemaps;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody2D rb;
    public CharacterController controller;
    public float jumpAmount = 5f;
    public float castDistance;
    public float maxSpeed = 0.06f;
    public Vector2 boxSize;
    public LayerMask groundLayer;
    public float horizontalMove = 0f;
    public float gravity;
    Vector3 velocity;

    public Animator animator;

    public bool isFacingRight = true;


    // Start is called before the first frame update
    void Start()
    {
        rb= GetComponent<Rigidbody2D>();
        animator= GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {
        float horizontalMove = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));


        if (Input.GetKeyDown(KeyCode.Space) && isGrounded())
            {
            rb.AddForce(Vector2.up * jumpAmount, ForceMode2D.Impulse);
        }
        
        else if (Input.GetKey(KeyCode.D) == true)
        {
            rb.AddForce(Vector2.right * maxSpeed, ForceMode2D.Impulse);
        }
        else if (Input.GetKey(KeyCode.A) == true)
        {
            rb.AddForce(Vector2.left * maxSpeed, ForceMode2D.Impulse);
        }
        

        if (horizontalMove < 0 && isFacingRight)
        {
            Flip();
        }
        else if (horizontalMove > 0 && !isFacingRight)
        {
            Flip();
        }

        if (isGrounded() == true)
        {
            animator.SetBool("isJumping", false);
        }
        else if (isGrounded() == false)
        {
            animator.SetBool("isJumping", true);
        }

    }

    private void Flip()
    {

        isFacingRight = !isFacingRight;
        transform.Rotate(0f, 180f, 0f);    
    }
    public bool isGrounded()
    {
        
        if (Physics2D.BoxCast(transform.position, boxSize, 0, -transform.up, castDistance, groundLayer))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position - transform.up * castDistance, boxSize);

    }


}
