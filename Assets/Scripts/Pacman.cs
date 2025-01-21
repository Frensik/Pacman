using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pacman : MonoBehaviour
{

    //Allows the movespeed to be edited in the unity editor as well
    [SerializeField] float moveSpeed = 5f;

    //Cached references
    [SerializeField] Rigidbody2D rb2d;
    [SerializeField] Animator anim;
    [SerializeField] CircleCollider2D col;
    //public GameManager gameManager;

    //These allow for audio clips to be played by allowing for the audio clips and audio sources to be assigned in the unity editer
    public AudioSource source;
    public AudioClip clip;


    //states
    bool isAlive = true;

    public PelletManager pm;

    void Update()
    {
        //Calls functions so that they happen every frame
        Rotate();
        ChangeAnimToMove();
        PlayerDeathSequence();
    }


    private void Rotate()
    {
        //This code rotates pacman to face the way he's moving
        //www.youtube.com/watch?v=GxlxZ5q__Tc&t=6850s
        Moving();
        //Checks if up is being pressed every frame since this is called in update
        //Changes the rotation value to face that direction using transform.rotation
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
    }

    private void Moving()
    {
        //If statement prevents any input from the player when they're dead by checking if isAlive is false
        if(!isAlive)
        {
            return;
        }
        //This takes the input from the new input system and moves pacman along the x and y axis depending on what buttons are pressed
        //Time.deltatime makes it dependant on time passing rather than the fps of the system that is running the program
        //Makes it consistent between devices and individual times playing the game
        var xInput = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        //Creates a goal X position by adding to newXPos
        var newXPos = transform.position.x + xInput;

        var yInput = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        var newYPos = transform.position.y + yInput;

        //Transforms the position of pacman to the new coordinates using the constantly updating newXPos and newYPos
        transform.position = new Vector2(newXPos, newYPos);

        ChangeAnimToMove();
    }
    private void ChangeAnimToMove()
    {
        //If the velocity is not equal to 0 then the player is moving and the bool is set to true
        //This triggers the animation to change (in theory)
        bool isPlayerMoving = Mathf.Abs(rb2d.velocity.x) > 0;
        if (isPlayerMoving)
        {
            anim.SetBool("IsMoving", isPlayerMoving);
        }
        /*else if(!isPlayerMoving)
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
            //Sets isAlive to false so that it affects other areas of the script where this is called
            isAlive = false;
            source.volume = 0.1f;
            source.PlayOneShot(clip);
            //Makes the object invisible so that it's not awkwardly sitting and not moving once control is taken away
            //discussions.unity.com/t/make-an-object-invisible-from-script/809531/3
            //gameManager.gameOver();
            gameObject.SetActive(false);
            //Activates game over screen
            //gameOverScreen.Setup();
        }
    }


}
