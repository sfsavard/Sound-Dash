using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Set in Inspector: Player")]
    public float speed = 10f;      // The speed in m/s
    public float jumpHeight = 10f;

    // fields set dynamically
    [Header("Set Dynamically")]
    public bool check;
    public Rigidbody2D rb;
    public Animator anim;
    //public int duration = 25f;
    
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        
    }

    


    // This is a Property: A method that acts like a field
    public Vector3 pos
    {                                                     
        get
        {
            return (this.transform.position);
        }
        set
        {
            this.transform.position = value;
        }
    }



    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Return))
        {
            check = true;
            anim.SetBool("isRunning", true);

        }

      
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            //anim.SetBool("isJumping", true);
            Jump();

        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            //anim.SetBool("isJumping", true);
            Crouch();

        }

        if (!check) return;

        Move();

        //anim.SetBool("isJumping", false);
    }

    //private void LateUpdate()
    //{
    //    anim.SetBool("isJumping", false);
    //}




    public void Move() // Moving the player automatically
    {
        
            Vector3 tempPos = pos;
            tempPos.x += speed * Time.deltaTime;
            pos = tempPos;

            

    }

    public void Jump() // Jumping
    {

        rb.AddForce(new Vector3(0, jumpHeight, 0), ForceMode2D.Impulse);
        //anim.SetBool("isJumping", false);

    }

    public void Crouch() // Jumping
    {

        //CapsuleCollider2D.size(this.CapsuleCollider2D.size, new Vector2(2.2, 1));
        //CapsuleCollider2D.offset(this.CapsuleCollider2D.offset, new Vector2(0, -1));
        anim.SetBool("isCrouching", true);
        //doneCrouching = Time.time + duration; 
    }
}
