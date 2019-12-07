﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public static PlayerMovement playerInstance;
    public float speed;
    public bool dead;
    public Rigidbody rb;

    private Vector3 movement;

    // Start is called before the first frame update
    void Awake()
    {
        if(playerInstance != null && playerInstance != this)
        {
            Debug.LogError("Player Instance does not exist");
        }
        else
        {
            playerInstance = this;
        }
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0) {
            rb.velocity = Vector3.zero;
        }
        movement = transform.position;
        movement += new Vector3((float)Input.GetAxis("Horizontal"), 0.0f, (float)Input.GetAxis("Vertical")) * speed * Time.deltaTime;

        rb.MovePosition(movement);
        //rb.velocity = movement * Time.deltaTime;

    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Enemy") {
            // Ouch
        }
    }
}
