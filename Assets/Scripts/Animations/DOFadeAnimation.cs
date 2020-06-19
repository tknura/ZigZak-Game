using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(CanvasGroup))]
public class DOFadeAnimation : MonoBehaviour
{
    public float toValue;
    public float backwardsValue;
    public float duration = 1f;
    public float backwardsDuration = 1f;
    [HideInInspector] public bool animationCompleted = false;

    public void Play() {
        if(GetComponent<CanvasGroup>().DOFade(toValue, duration).IsComplete()) {
            animationCompleted = true;
        }
    }

    public void Play(GameObject o) {
        o.GetComponent<CanvasGroup>().DOFade(toValue, duration);
        animationCompleted = true;
    }

    public void PlayBackwards() {
        if(GetComponent<CanvasGroup>().DOFade(backwardsValue, backwardsDuration).IsComplete()) {
            animationCompleted = true;
        }
    }
}
