using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DOMoveAnimation : MonoBehaviour
{
    public float toValueY;
    public float toValueYBackwards;
    public float duration = 1f;
    public float durationBackwards = 2f;
    public bool snapping = false;

    public void PlayY() {
        GetComponent<Transform>().DOMoveY(toValueY, duration, snapping);
    }

    //unfinished
    public void PlayYBackwards() {
        GetComponent<Transform>().DOMoveY(toValueYBackwards, durationBackwards, snapping);
    }
}
