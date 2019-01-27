using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WonJingle : MonoBehaviour
{
    [SerializeField]
    private AudioClip jingle;
    private AudioSource audio;

    void Start()
    {
        SetUp();
        audio.PlayOneShot(jingle);
    }

    void SetUp()
    {
        audio = GetComponent<AudioSource>();
    }
}
