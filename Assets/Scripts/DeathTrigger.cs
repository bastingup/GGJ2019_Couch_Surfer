using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTrigger : MonoBehaviour
{
    private bool wasted = false;
    private Quaternion startRotation;

    void Start()
    {
        SetUp();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ground" && !wasted)
        {
            StartCoroutine(Wasted());
        }
    }

    IEnumerator Wasted()
    {
        wasted = true;
        Vector3 wastedPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
        yield return new WaitForSeconds(1.5f);
        Debug.Log("WAAAASTEEED!");
        GameObject.FindGameObjectWithTag("Player").transform.position = new Vector3(wastedPosition.x, wastedPosition.y + 1, wastedPosition.z);
        GameObject.FindGameObjectWithTag("Player").transform.rotation = startRotation;
    }

    void SetUp()
    {
        GetComponent<BoxCollider>();
        startRotation = GameObject.FindGameObjectWithTag("Player").transform.rotation;
    }
}
