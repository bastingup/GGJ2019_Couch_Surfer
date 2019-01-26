using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SceneEvent : ScriptableObject
{
    public abstract void Play();
    public abstract string GetGizmoIcon();
}
