using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    public void FallDown(float fallDelay) {
        StartCoroutine(FallDownCourotine(fallDelay));
    }

    IEnumerator FallDownCourotine(float fallDelay) {
        yield return new WaitForSeconds(fallDelay);
        GetComponent<DOMoveAnimation>().PlayYBackwards();
    }
}
