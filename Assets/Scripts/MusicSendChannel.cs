using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicSendChannel : MonoBehaviour
{
    private AudioSource[] grumbleSources;
    [SerializeField]
    private AudioMixer mixer;

    void Start()
    {
        Invoke("SetOutputChannel", 0.2f);
    }

    void SetOutputChannel()
    {
        grumbleSources = GetComponents<AudioSource>();
        foreach (AudioSource a in grumbleSources)
        {
            a.outputAudioMixerGroup = mixer.FindMatchingGroups("MUSIC")[0];
        }
    }
}
