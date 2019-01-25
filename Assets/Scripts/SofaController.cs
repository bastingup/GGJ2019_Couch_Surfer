using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SofaController : MonoBehaviour {

    private Rigidbody rb;
    [SerializeField]
    private float speed, jumpForce;
    private bool grounded;

	void Start ()
    {
        SetUp();
	}
	

	void Update ()
    {
		if (Input.GetButton("Fire1") && grounded)
        {
            rb.AddForce(Vector3.forward * speed);
        }
        if (Input.GetButtonDown("Fire2") && grounded)
        {
            rb.AddForce(Vector3.up * jumpForce);
        }
	}

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Ground")
        {
            grounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        grounded = false;
    }

    void SetUp()
    {
        rb = GetComponent<Rigidbody>();

    }
}
