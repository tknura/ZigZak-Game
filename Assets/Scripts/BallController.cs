using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;

    Rigidbody rb;

    bool isStarted;

    public float ballSpeed {
        get {
            return speed;
        }
        set {
            speed = value;
        }
    }

    public void StartGame() {
        rb.velocity = new Vector3(speed, 0, 0);
        isStarted = true;
    }

    void Awake() {
        rb = GetComponent<Rigidbody>();
    }

    void Start() {
        isStarted = false;
    }

    void Update() {
        if(!Physics.Raycast(transform.position, Vector3.down, 1f)){
            HandleGameOver();
        }
        if(Input.GetMouseButtonDown(0) && !GameManager.gameOver) {
            SwitchDirection();
        }
        
    }

    void SwitchDirection() {
        if (rb.velocity.z > 0) {
            rb.velocity = new Vector3(speed, 0, 0);
        }
        else if (rb.velocity.x > 0) {
            rb.velocity = new Vector3(0 , 0, speed);
        }
    }

    void HandleGameOver() {
        if(!GameManager.gameOver) {
            rb.velocity = new Vector3(0, -10f, 0);
            GameManager.instance.GameOver();
            Destroy(transform.gameObject, 3f);
        }
    }
}
