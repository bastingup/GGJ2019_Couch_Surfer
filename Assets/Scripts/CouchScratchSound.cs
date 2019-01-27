using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CouchScratchSound : MonoBehaviour
{

    [SerializeField]
    private Rigidbody rb;

    [SerializeField]
    private AudioClip clip;
    private AudioSource audio;

    void Start()
    {
        SetUp();
    }


    void FixedUpdate()
    {
        Debug.Log(rb.velocity.magnitude);
        if (!audio.isPlaying && rb.GetComponent<SofaController>().Grounded && rb.velocity.magnitude >= 1.0f)
        {
            audio.Play();
        }
        if (audio.isPlaying && !rb.GetComponent<SofaController>().Grounded)
        {
            audio.Stop();
        }
    }

    void SetUp()
    {
        audio = GetComponent<AudioSource>();
        audio.loop = true;
        audio.playOnAwake = false;
    }
}
