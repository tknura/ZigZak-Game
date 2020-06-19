using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{
    public GameObject ball;
    Vector3 offset;
    [SerializeField] float lerpRate;

    void Start()
    {
        offset = ball.transform.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(!GameManager.gameOver) {
            Follow();
        }
    }

    void Follow() {
        Vector3 pos = transform.position;
        Vector3 targetPos = ball.transform.position - offset;
        pos = Vector3.Lerp(pos, targetPos, lerpRate * Time.deltaTime);
        transform.position = pos;
    }
}
