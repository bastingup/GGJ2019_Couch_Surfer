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

    private ChatDialog currentDialog;
    private ChatDialog nextDialog;

    [SerializeField]
    private ChatEntryObject chatEntryPrefab;

    private ITriggerable waitForTrigger;
    private ChatMission chatMission;
    private float lastDialogTime;

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        canvasGroup.alpha = 0;
        canvasGroup.DOFade(1, fadeDuration);
    }

    public void SetNextDialog(ChatDialog dialog)
    {
        nextDialog = dialog;

        if(waitForTrigger != null)
            waitForTrigger.SetTrigger();
    }

    public void PlayNextChatDialog()
    {
        PlayRandomDialog(chatMission.bonusTimeDialogs);
    }

    public void PlayCoolMoveDialog()
    {
        PlayRandomDialog(chatMission.coolMoveDialogs);
    }


    public void PlayTimeDialog()
    {
        switch (FindObjectOfType<TIMER>().currentState)
        {
            case TIMER.timeState.okay:
                PlayRandomDialog(chatMission.notLateDialog);
                break;
            case TIMER.timeState.late:
                PlayRandomDialog(chatMission.lateDialog);
                break;
            case TIMER.timeState.hurry:
                PlayRandomDialog(chatMission.veryLateDialog);
                break;
            default:
                return;
        }

    }

    private void PlayRandomDialog(ChatDialog[] dialogs)
    {
        lastDialogTime = Time.time;

        int choice = UnityEngine.Random.Range(0, dialogs.Length);
        ChatDialog dialogToShow = dialogs[choice];
        SetNextDialog(dialogToShow);
    }

    public void ShowMission(ChatMission chatEvent)
    {
        lastDialogTime = 999999999;
        StartCoroutine(Show(chatEvent));
    }

    private void Update()
    {
        if(lastDialogTime + 10 < Time.time)
        {
            PlayTimeDialog();
        }

    }

    private IEnumerator Show(ChatMission chatEvent)
    {
        this.chatMission = chatEvent;
        chatHeader.text = "Chat with " + chatEvent.PartnerName;

        currentDialog = chatEvent.startDialog;

        while(true)
        {
            for (int i = 0; i < currentDialog.DialogLines.Length; i++)
            {
                ChatEntry entry = currentDialog.DialogLines[i];

                yield return waitForTrigger = new ChatWaitForTimeOrTrigger(entry.Delay);

                if (waitForTrigger.IsTriggered())
                    break;

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

            if (currentDialog == chatEvent.endDialog)
                break;


            if(nextDialog == null)
            {
                //Have to wait for next dialog
                currentDialog = null;
                yield return waitForTrigger = new ChatWaitForTrigger();
            }
            currentDialog = nextDialog;
            nextDialog = null;
        }


        yield return new WaitForSeconds(chatEvent.TimeToShowUntilLastMessage);

        canvasGroup.DOFade(0, fadeDuration);

        yield return new WaitForSeconds(fadeDuration);

        Destroy(gameObject);
    }
}

public class ChatWaitForTimeOrTrigger : CustomYieldInstruction, ITriggerable
{

    private float endTime;
    private bool wait;

    public ChatWaitForTimeOrTrigger(float secondsToWait)
    {
        endTime = Time.time + secondsToWait;
        wait = true;
    }

    public void SetTrigger()
    {
        wait = false;
    }

    public bool IsTriggered()
    {
        return !wait;
    }

    public override bool keepWaiting {
        get {
            return wait && Time.time < endTime;
        }
    }
}
public class ChatWaitForTrigger : CustomYieldInstruction, ITriggerable
{
    private bool wait;

    public ChatWaitForTrigger()
    {
        wait = true;
    }

    public void SetTrigger()
    {
        wait = false;
    }

    public bool IsTriggered()
    {
        return !wait;
    }

    public override bool keepWaiting {
        get {
            return wait;
        }
    }
}

public interface ITriggerable
{
    void SetTrigger();
    bool IsTriggered();
}