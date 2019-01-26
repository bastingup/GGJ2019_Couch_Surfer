using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ChatEvent", menuName = "Surf/ChatEvent", order = 141)]
public class ChatEvent : SceneEvent
{
    public override string GetGizmoIcon()
    {
        return "cellphone1.png";
    }

    public override void Play()
    {
        FindObjectOfType<ChatFieldObject>().PlayNextChatDialog();
    }
}
