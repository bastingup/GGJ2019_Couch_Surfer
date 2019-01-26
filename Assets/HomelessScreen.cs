using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Sirenix.OdinInspector;
using System;

public class HomelessScreen : MonoBehaviour
{
    [SerializeField]
    private Image staticScreen, textScreen;
    [SerializeField]
    private AnimationCurve inCurve;
    [SerializeField]
    private Cinemachine.CinemachineVirtualCamera virtualCamera;

    [Button]
    public void ResetScreen()
    {
        StopAllCoroutines();
        SetVisible(false);
    }

    [Button]
    public void FadeIn()
    {
        float fadeTime = 1;

        virtualCamera.m_Lens.FieldOfView = 40;
        DOTween.To((v)=>virtualCamera.m_Lens.FieldOfView=v, virtualCamera.m_Lens.FieldOfView, 20, fadeTime);

        staticScreen.DOFade(1, fadeTime).timeScale = 1;

        Vector3 position = textScreen.transform.localPosition;
        position.x = Screen.currentResolution.width;
        textScreen.transform.localPosition = position;
        textScreen.transform.DOLocalMoveX(0, fadeTime).SetEase(inCurve) .timeScale = 1;

        SetVisible(true);
    }

    [Button]
    public void FadeOut()
    {
        float fadeTime = 1;

        virtualCamera.m_Lens.FieldOfView = 20;
        DOTween.To((v) => virtualCamera.m_Lens.FieldOfView = v, virtualCamera.m_Lens.FieldOfView, 40, fadeTime);
        staticScreen.DOFade(0, fadeTime).timeScale = 1;
        textScreen.transform.DOLocalMoveX(Screen.currentResolution.width, fadeTime).timeScale = 1;

        StartCoroutine(SetVisible(fadeTime, false));

    }

    private IEnumerator SetVisible(float delay, bool visible)
    {
        yield return new WaitForSecondsRealtime(delay);
        SetVisible(visible);
    }

    private void SetVisible(bool visible)
    {
        staticScreen.enabled = visible;
        textScreen.enabled = visible;
    }
}
