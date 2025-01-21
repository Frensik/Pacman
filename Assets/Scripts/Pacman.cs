using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pacman : MonoBehaviour
{

    //The numbers
    [SerializeField] float moveSpeed = 5f;


    [SerializeField] Rigidbody2D rb2d;
    [SerializeField] Animator anim;
    [SerializeField] CircleCollider2D col;

    //These allow for audio clips to be played
    public AudioSource source;
    public AudioClip clip;

    //states
    bool isAlive = true;

    public PelletManager pm;

    void Start()
    {
        
    }

    void Update()
    {
        Rotate();
        ChangeAnimToMove();
        PlayerDeathSequence();
    }


    private void Rotate()
    {
        //This code rotates pacman to face the way he's moving
        //www.youtube.com/watch?v=GxlxZ5q__Tc&t=6850s
        Moving();
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 90f);
        }
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            transform.rotation = Quaternion.Euler(0f, 0f, -90f);
        }
        else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 180f);
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
        ChangeAnimToMove();
    }

    private void Moving()
    {
        //If statement prevents any input from the player when they're dead by checking if isAlive is false
        if(!isAlive)
        {
            return;
        }
        //This takes the input from the new input system and moves pacman along the x and y axis depending on what buttons are pressed
        //Movement script taken from schmup lecture 1
        var xInput = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        var newXPos = transform.position.x + xInput;

        var yInput = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        var newYPos = transform.position.y + yInput;

        transform.position = new Vector2(newXPos, newYPos);

        ChangeAnimToMove();
    }
    private void ChangeAnimToMove()
    {
        // Moving chack taken from discussions.unity.com/t/boolean-if-moving-turn-true/676224/5
        bool isPlayerMoving = rb2d.velocity.magnitude > Mathf.Epsilon;
        if (isPlayerMoving)
        {
            anim.SetBool("IsMoving", true);
        }
        /*if(!isPlayerMoving)
        {
            anim.SetBool("IsMoving", false);
        }*/
    }

    
    //This code destroys any pellets that are touched and adds to a score counter
    //www.youtube.com/watch?v=5GWRPwuWtsQ
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Pellet"))
        {
            pm.pelletScore++;
            Destroy(other.gameObject);
        }
    }
    //Toggles isAlive to false when touching an enemy
    private void PlayerDeathSequence()
    {
        if(col.IsTouchingLayers(LayerMask.GetMask("Enemy")))
        {
            isAlive = false;
            source.volume = 0.1f;
            source.PlayOneShot(clip);
            gameObject.SetActive(false);
        }
    }


}
