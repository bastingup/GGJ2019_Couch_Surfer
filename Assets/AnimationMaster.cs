using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationMaster : MonoBehaviour
{
    private Animation anim;

    public enum AnimationType { surf, surfFast, fall }
    [SerializeField]
    private string animationSurf, animationSurfFast, animationFall;

    void Awake()
    {
        anim = GetComponent<Animation>();
    }

    [Button]
    public void PlaySurf()
    {
        SetAnimation(AnimationType.surf);
    }

    [Button]
    public void PlayFastSurf()
    {
        SetAnimation(AnimationType.surfFast);
    }

    [Button]
    public void PlayFall()
    {
        SetAnimation(AnimationType.fall, AnimationType.surf);
    }


    public void SetAnimation(AnimationType oneShot, AnimationType loopAfterwards)
    {

        StopAllCoroutines();

        string toPlay;
        switch (oneShot)
        {
            case AnimationType.surf:
                toPlay = animationSurf;
                break;
            case AnimationType.surfFast:
                toPlay = animationSurfFast;
                break;
            case AnimationType.fall:
                toPlay = animationFall;
                break;
            default:
                return;
        }
        anim.CrossFade(toPlay, 0.2f, PlayMode.StopAll);

        string toPlayLater;
        switch (loopAfterwards)
        {
            case AnimationType.surf:
                toPlayLater = animationSurf;
                break;
            case AnimationType.surfFast:
                toPlayLater = animationSurfFast;
                break;
            case AnimationType.fall:
                toPlayLater = animationFall;
                break;
            default:
                return;
        }

        StartCoroutine(DelayPlay(loopAfterwards, anim.GetClip(toPlay).length-0.2f));
    }

    private IEnumerator DelayPlay(AnimationType loopAfterwards, float delay)
    {
        yield return new WaitForSeconds(delay);
        SetAnimation(loopAfterwards);
    }

    public void SetAnimation(AnimationType loop)
    {
        StopAllCoroutines();
        string toPlay;
        switch (loop)
        {
            case AnimationType.surf:
                toPlay = animationSurf;
                break;
            case AnimationType.surfFast:
                toPlay = animationSurfFast;
                break;
            case AnimationType.fall:
                toPlay = animationFall;
                break;
            default:
                return;
        }
        anim.CrossFade(toPlay, 0.2f, PlayMode.StopAll);
    }

}
