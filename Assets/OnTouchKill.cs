﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTouchKill : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag.Equals("Player"))
            FindObjectOfType<TIMER>().Kill();
    }

}
