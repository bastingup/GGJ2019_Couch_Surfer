using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMaster : MonoBehaviour
{

    public static UIMaster instance;

    public Transform inCanvasView;

    public static UIMaster Instance {
        get {
            if (instance == null)
                instance = FindObjectOfType<UIMaster>();
            return instance;

        }
    }

    private void Awake()
    {
        if (instance && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
    }
}
