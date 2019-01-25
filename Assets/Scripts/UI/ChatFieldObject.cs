using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.UI;

public class ChatFieldObject : MonoBehaviour
{

    [SerializeField]
    private Transform chatFieldRoot;
    [SerializeField]
    private TextMeshProUGUI chatHeader;

    private CanvasGroup canvasGroup;
    private float fadeDuration = 0.1f;

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        canvasGroup.alpha = 0;
        canvasGroup.DOFade(1, fadeDuration);
    }

    [SerializeField]
    private ChatEntryObject chatEntryPrefab;

    public void ShowEvent(ChatEvent chatEvent)
    {
        StartCoroutine(Show(chatEvent));
    }


    private IEnumerator Show(ChatEvent chatEvent)
    {
        chatHeader.text = "Chat with " + chatEvent.PartnerName;

        for (int i = 0; i < chatEvent.ChatEntries.Length; i++)
        {
            ChatEntry entry = chatEvent.ChatEntries[i];

            yield return new WaitForSeconds(entry.Delay);

            ChatEntryObject chatEntryObject = Instantiate(chatEntryPrefab, chatFieldRoot);
            if (entry.SenderType == ChatEntry.Sender.other)
            {
                chatEntryObject.FadeIn(entry.Message, true, chatEvent.PartnerFace);
            }
            else
            {
                chatEntryObject.FadeIn(entry.Message, false, chatEvent.MyFace);
            }

        }

        yield return new WaitForSeconds(chatEvent.TimeToShowUntilLastMessage);

        canvasGroup.DOFade(0, fadeDuration);

        yield return new WaitForSeconds(fadeDuration);

        Destroy(gameObject);
    }

    private void AddChatBubble(ChatEntry chatEntry)
    {

    }



}
