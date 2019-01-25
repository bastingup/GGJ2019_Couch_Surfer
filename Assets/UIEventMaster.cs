using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEventMaster : MonoBehaviour
{

    public SceneEvent eventToTest;
    public Transform root;

    [Button]
    void ShowEvent()
    {
        eventToTest.Play(root);
    }

    // Update is called once per frame
    void Start()
    {
        ShowEvent();
    }
}
