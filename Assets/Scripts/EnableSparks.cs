using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableSparks : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rb;
    private ParticleSystem sparks;

    void Start()
    {
        SetUp();
    }

    private void Update()
    {
        // Enable particle sparks if rigidbody over certain velocity on z axis
        if (rb.velocity.z < 0.5)
        {
            sparks.enableEmission = false;
        }
        else
        {
            sparks.enableEmission = true;
        }

        // Set the speed for the spark particles
        if (rb.velocity.z > 10)
        {
            sparks.startSpeed = 10;
        }
        else
        {
            sparks.startSpeed = rb.velocity.z;
        }
 
        Debug.Log(rb.velocity.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ground" && rb.velocity.z > 1)
        {
            sparks.enableEmission = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        sparks.enableEmission = false;
    }

    void SetUp()
    {
        sparks = GetComponent<ParticleSystem>();
        GetComponent<BoxCollider>();
    }
}
