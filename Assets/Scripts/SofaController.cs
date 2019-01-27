using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SofaController : MonoBehaviour {

    private Rigidbody rb;
    [SerializeField]
    private float speed, jumpForce;


    [SerializeField, ReadOnly]
    private bool groundedCollision, groundedRay;
    [SerializeField]
    private Transform[] rayPositions;
    [SerializeField]
    private LayerMask groundedLayerMask;
    [SerializeField]
    private float maxGroundedDistance;
    private bool wantJump;
    private Quaternion startRotation;


    public bool Grounded {
        get {
            return groundedCollision || groundedRay;
        }
    }

	void Start ()
    {
        SetUp();
	}
	

	void Update ()
    {
        if (Input.GetButtonDown("Jump") && Grounded)
        {
            wantJump = true;
        }
    }

    private void FixedUpdate()
    {
        groundedRay = false;

        for (int i = 0; i < rayPositions.Length; i++)
        {
            Debug.DrawRay(rayPositions[i].position, -rayPositions[i].up * maxGroundedDistance,Color.magenta);
            if (Physics.Raycast(rayPositions[i].position, -rayPositions[i].up, maxGroundedDistance, groundedLayerMask.value))
            {
                groundedRay = true;
                break;
            }
        }
        if (wantJump)
        {
            rb.AddForce(Vector3.up * jumpForce);
            wantJump = false;
        }
        if (Input.GetButton("Forward"))
        {
            rb.rotation *= Quaternion.Euler(0, 0, -140 * Time.deltaTime);
        }
        if (Input.GetButton("Backward"))
        {
            rb.rotation *= Quaternion.Euler(0, 0, 80 * Time.deltaTime);
        }
        if (Input.GetButton("Drive") && Grounded)
        {
            rb.AddRelativeForce(-Mathf.Sign(rb.transform.right.z) * Vector3.left * speed);
        }
        if (Input.GetButton("RotateBack"))
        {
            this.transform.SetPositionAndRotation(this.transform.position, startRotation);
        }
    }

    internal void Boost(float boostValue)
    {
        rb.AddRelativeForce(Vector3.forward * speed * boostValue);
    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.collider.tag == "Ground")
        {
            groundedCollision = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.tag == "Ground")
        {
            groundedCollision = false;
        }
    }

    void SetUp()
    {
        rb = GetComponent<Rigidbody>();
        startRotation = GameObject.FindGameObjectWithTag("Player").transform.rotation;
    }
}
