﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pacman : MonoBehaviour
{

//The numbers
    [SerializeField] float moveSpeed = 5f;

    public PelletManager pm;

    void Start()
    {
        
    }

    void Update()
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
    }

    private void Moving()
    {
        //Movement script taken from schmup lecture 1
        var xInput = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        var newXPos = transform.position.x + xInput;

        var yInput = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        var newYPos = transform.position.y + yInput;

        transform.position = new Vector2(newXPos, newYPos);
    }

    //This code destroys any pellets that are touched and adds to a score counter
    //www.youtube.com/watch?v=5GWRPwuWtsQ
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Pellet"))
        {
            Destroy(other.gameObject);
            pm.pelletScore++;
        }
    }
}
