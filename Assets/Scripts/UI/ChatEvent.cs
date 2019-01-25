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
    private ChatEntryObject chatEntryPrefab;

    [SerializeField]
    private string partnerName;

    public override void Play(UIRoot uiRoot)
    {
        
    }
}

[Serializable]
public class ChatEntry
{
    public enum Sender { me, other}
    public Sender sender;

    [SerializeField]
    private string message;

}