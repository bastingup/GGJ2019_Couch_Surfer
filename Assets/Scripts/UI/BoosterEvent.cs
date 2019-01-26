using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BoosterEvent", menuName = "Surf/BoosterEvent", order = 141)]
public class BoosterEvent : SceneEvent
{

    public FloatReference boostValue;

    public override string GetGizmoIcon()
    {
        return "speedup.png";
    }

    public override void Play()
    {
        FindObjectOfType<SofaController>().Boost(boostValue);
    }
}
