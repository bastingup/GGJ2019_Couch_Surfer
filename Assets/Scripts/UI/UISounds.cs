using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISounds : MonoBehaviour
{
    [SerializeField]
    private AudioClip homelessClip;
    private AudioSource audioSource;

    void Start()
    {
        SetUp();
    }

    public void PlayHomelessSound()
    {
        audioSource.PlayOneShot(homelessClip);
    }

    void SetUp()
    {
        audioSource = GetComponent<AudioSource>();
    }


}
