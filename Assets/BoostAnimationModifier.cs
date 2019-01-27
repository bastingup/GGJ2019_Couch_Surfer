using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostAnimationModifier : MonoBehaviour
{

    [SerializeField]
    private Material material;
    [SerializeField]
    private float speed = 0.6f;

    void Update()
    {
        Vector2 offset = new Vector2(0,-speed * Time.time%1);
        material.SetTextureOffset("_BaseColorMap", offset);
        material.SetTextureOffset("_EmissiveColorMap", offset);
    }
}
