﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableSparks : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rb;
    private ParticleSystem sparks;
    private bool sparksGrounded;

    void Start()
    {
        SetUp();
    }

    private void Update()
    {
        // Enable particle sparks if rigidbody over certain velocity on z axis
        if (rb.velocity.z < 0.5 || sparksGrounded == false)
        {
            sparks.enableEmission = false;
        }
        else
        {
            sparks.enableEmission = true;
        }

        // Set the speed for the spark particles
        if (sparksGrounded == true)
        {
            if (rb.velocity.z > 10)
            {
                sparks.startSpeed = 10;
            }
            else
            {
                sparks.startSpeed = rb.velocity.z;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ground" && rb.velocity.z > 1)
        {
            sparks.enableEmission = true;
            sparksGrounded = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Ground")
        {
            sparksGrounded = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Ground")
        {
            sparks.enableEmission = false;
        }
    }

    void SetUp()
    {
        sparks = GetComponent<ParticleSystem>();
        GetComponent<BoxCollider>();
    }
}