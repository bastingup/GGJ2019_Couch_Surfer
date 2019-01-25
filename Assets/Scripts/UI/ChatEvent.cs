using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ChatEvent", menuName = "Surf/ChatEvent", order = 141)]
public class ChatEvent : SceneEvent
{

    [SerializeField]
    private ChatEntry[] chatEntries;

    [SerializeField]
    private ChatFieldObject chatFieldPrefab;

    [SerializeField]
    private string partnerName;

    [SerializeField]
    private Sprite myFace, partnerFace;

    [SerializeField]
    private float timeToShowUntilLastMessage;

    public override void Play(Transform spawnRoot)
    {
        Instantiate(chatFieldPrefab, spawnRoot).ShowEvent(this);
    }

    public ChatEntry[] ChatEntries {
        get {
            return chatEntries;
        }
    }
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