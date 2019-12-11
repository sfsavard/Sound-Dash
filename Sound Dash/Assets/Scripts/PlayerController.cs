using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 15f;
    public bool grounded; //boolean to check if the player is grounded, prevents double jumping
    public LayerMask whatIsGround; //tells whatisground which layer is the ground layer
    public Animator anim;

    private Rigidbody2D rb;
    private bool sliding = false;
    private BoxCollider2D myCollider;
    private CircleCollider2D crouchCollider;
    



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        myCollider = GetComponent<BoxCollider2D>();
        crouchCollider = GetComponent<CircleCollider2D>();

        crouchCollider.enabled = !crouchCollider.enabled;
    }

    // Update is called once per frame
    void Update()
    {
        

        grounded = Physics2D.IsTouchingLayers(myCollider, whatIsGround); //checks if collider touches the whatisground layer

        

        rb.velocity = new Vector2(moveSpeed, rb.velocity.y); //makes the velocity of the character ewual to movespeed on the x and we don't change the y

        

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (grounded) //only jump if grounded
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce); //keeps x constant but changes the y so we jump
                
            }

            
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            sliding = true;
            anim.SetBool("isSliding", sliding);
            myCollider.enabled = false;
            crouchCollider.enabled = true;
            

        }
        else
        {
            sliding = false;
            anim.SetBool("isSliding", sliding);
            
        }

        if (myCollider.enabled == false && sliding == false)
        {
            myCollider.enabled = true;
            crouchCollider.enabled = false;

        }



        anim.SetFloat("Speed", rb.velocity.x); //sets Speed float parameter in the animator to equal your velocity in the x direction
        anim.SetBool("Grounded", grounded); //sets the Grounded parameter in the animator to the true false value of whether we are grounded, set above 

    }
}
