using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MUSIC : MonoBehaviour
{
    [SerializeField]
    private AudioClip referenceClip;
    private grumbleAMP amp;

    void Start()
    {
        SetUp();
        amp.PlaySong(0, 0, 0);
        Invoke("StartMusic", referenceClip.length - 2.0f);
    }

    public void ChangeLayer(int i, float fadeTime)
    {
        amp.CrossFadeToNewLayer(i, fadeTime);
    }

    void StartMusic()
    {
        amp.CrossFadeToNewSong(1, 0, 0.1f);
    }

    void SetUp()
    {
        amp = GetComponent<grumbleAMP>();
    }
}
