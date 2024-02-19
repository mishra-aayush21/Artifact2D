using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 3.0f;

    private Vector2 moveVector;
    
    private Rigidbody2D rb;

    private SpriteRenderer sr;
    private Animator animator;

    private float harvestTimer;
    private bool isHarvesting = false;
    private GameObject artifact;


    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        
    }
    private void Update()
    {
        FlipSide();
        if(Time.time > harvestTimer)
        {
            isHarvesting=false;
        }
    }


    void FixedUpdate()
    {
        //We need to call the movent and physics functionalities inside the fixed update 
        if (isHarvesting)
        {
            rb.velocity = Vector2.zero;
        }
        else
        {
            //move input is normalised so as to actually get raw input from the input scheme
            //raw input can actuly help in simplifying the animations in 2d space


            moveVector = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            if(moveVector.sqrMagnitude >1) 
            {
                moveVector = moveVector.normalized;
            }
            rb.velocity = new Vector2(moveVector.x*moveSpeed, moveVector.y*moveSpeed);
        }
    }
    public void HarvestStopMovement(float time)
    {
         isHarvesting=true;
        harvestTimer = Time.time+time;
        
        
    }
    //Flip side function to mimic the flipping of moving directions visually
    void FlipSide()
    {
        if (Input.GetAxisRaw("Horizontal") == 1)
        {
            sr.flipX = false;
            animator.SetBool("Walk", true);
        }

        else if (Input.GetAxisRaw("Horizontal") == -1)
        {
            sr.flipX = true;
            animator.SetBool("Walk", true);
        }
        else animator.SetBool("Walk", false);
    }
    
}
