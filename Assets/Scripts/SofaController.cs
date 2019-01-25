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
		if (Input.GetButton("Drive") && grounded)
        {
            rb.AddForce(Vector3.forward * speed);
        }
        if (Input.GetButtonDown("Jump") && grounded)
        {
            rb.AddForce(Vector3.up * jumpForce);
        }
        if (Input.GetButton("Forward"))
        {
            rb.rotation *= Quaternion.Euler(0, 0, -80 * Time.deltaTime);
        }
        if (Input.GetButton("Backward"))
        {
            rb.rotation *= Quaternion.Euler(0, 0, 80 * Time.deltaTime);
        }


    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.collider.tag == "Ground")
        {
            grounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.tag == "Ground")
        {
            grounded = false;
        }
    }

    void SetUp()
    {
        rb = GetComponent<Rigidbody>();

    }
}
