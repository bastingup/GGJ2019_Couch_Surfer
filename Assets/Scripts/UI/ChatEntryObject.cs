using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using DG;
using TMPro;
using UnityEngine.UI;

public class ChatEntryObject : MonoBehaviour
{

    [SerializeField]
    private CanvasGroup movingBelow;

    [SerializeField]
    private GameObject rightBubble, leftBubble;
    [SerializeField]
    private TextMeshProUGUI rightMessage, leftMessage;
    [SerializeField]
    private Image myFace, partnerFace;

    internal void FadeIn(string message, bool fromLeft, Sprite face, float delay = 0)
    {
        float width = movingBelow.GetComponent<RectTransform>().rect.width;

        float fadeDuration = 0.2f;

        //Set to start Position
        Vector3 localPosition = movingBelow.transform.localPosition;
        localPosition.x = fromLeft ? (-width) : (width);
        movingBelow.transform.localPosition = localPosition;
        //Ease to defaultPosition
        movingBelow.transform.DOLocalMoveX(0, fadeDuration).SetEase(Ease.InExpo).SetDelay(delay);
        //Fade canvas alpha
        movingBelow.alpha = 0;
        movingBelow.DOFade(1, fadeDuration).SetDelay(delay);

        rightBubble.SetActive(!fromLeft);
        leftBubble.SetActive(fromLeft);
        if (fromLeft)
        {
            leftMessage.text = message;
            partnerFace.sprite = face;
        }
        else
        {
            rightMessage.text = message;
            myFace.sprite = face;
        }
    }
}
