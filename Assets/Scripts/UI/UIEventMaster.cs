using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEventMaster : MonoBehaviour
{

    public SceneEvent eventToTest;

    [Button]
    void ShowEvent()
    {
        eventToTest.Play();
    }

    // Update is called once per frame
    void Start()
    {
        ShowEvent();
    }
}
