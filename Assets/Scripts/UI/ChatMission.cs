using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ChatMission", menuName = "Surf/ChatMission", order = 141)]
public class ChatMission : ScriptableObject
{

    public ChatDialog startDialog;
    public ChatDialog endDialog;
    public ChatDialog[] bonusTimeDialogs;
    public ChatDialog[] coolMoveDialogs;
    public ChatDialog[] lateDialog;
    public ChatDialog[] veryLateDialog;
    public ChatDialog[] notLateDialog;

    [SerializeField]
    private ChatFieldObject chatFieldPrefab;

    [SerializeField]
    private string partnerName;

    [SerializeField]
    private Sprite myFace, partnerFace;

    [SerializeField]
    private float timeToShowUntilLastMessage;

    public string PartnerName {
        get {
            return partnerName;
        }
    }
    public float TimeToShowUntilLastMessage {
        get {
            return timeToShowUntilLastMessage;
        }
    }
    public Sprite MyFace {
        get {
            return myFace;
        }
    }
    public Sprite PartnerFace {
        get {
            return partnerFace;
        }
    }
}

[Serializable]
public class ChatDialog
{
    [SerializeField]
    private ChatEntry[] dialogLines;

    public ChatEntry[] DialogLines {
        get {
            return dialogLines;
        }
    }
}


[Serializable]
public class ChatEntry
{
    public enum Sender { me, other }

    [SerializeField]
    private Sender sender;
    [SerializeField]
    private string message;
    [SerializeField]
    private float delay;

    public Sender SenderType {
        get {
            return sender;
        }
    }
    public string Message{
        get {
            return message;
        }
    }
    public float Delay {
        get {
            return delay;
        }
    }

}