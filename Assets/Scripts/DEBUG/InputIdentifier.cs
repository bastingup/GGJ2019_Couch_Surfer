using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputIdentifier : MonoBehaviour
{
    void Update()
    {
        if (Input.anyKey)
        {
            Debug.Log(Input.inputString);
        }
    }
}
