using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEventTest : MonoBehaviour
{

    public SceneEvent eventToTest;

    [Button]
    void ShowEvent()
    {
        eventToTest.Play();
    }
}
