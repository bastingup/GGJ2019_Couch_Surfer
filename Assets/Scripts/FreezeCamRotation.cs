using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeCamRotation : MonoBehaviour
{
    private Camera mainCam;

    void Start()
    {
        SetUp();
        FreezeRotation();
    }

    private void Update()
    {
        FreezeRotation();
    }

    void SetUp()
    {
        mainCam = GetComponent<Camera>();
    }

    void FreezeRotation()
    {
        mainCam.transform.eulerAngles = new Vector3(0, -90, 0);
    }
}
