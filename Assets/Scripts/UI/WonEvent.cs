using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "WonEvent", menuName = "Surf/WonEvent", order = 141)]
public class WonEvent : SceneEvent
{
    public override string GetGizmoIcon()
    {
        return "cellphone.png";
    }

    public override void Play(SceneEventTrigger sceneEventTrigger)
    {
        sceneEventTrigger.Won();
    }
}
