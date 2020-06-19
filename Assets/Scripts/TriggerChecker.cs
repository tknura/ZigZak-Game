using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerChecker : MonoBehaviour
{
    [SerializeField] PlatformSpawner spawner;
    public GameObject particle;
    public float fallDelay;

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Platform") {
            spawner.SpawnPlatforms();
            ScoreManager.instance.IncScore();
        }
        if(other.gameObject.tag == "Diamond") {
            Destroy(other.gameObject);
            ScoreManager.instance.IncScoreByInt(10);

        }
    }
    private void OnTriggerExit(Collider other) {
        if(other.gameObject.tag == "Platform") {
            GameObject platform = other.gameObject.transform.parent.gameObject;
            if(platform != null) {
                platform.GetComponent<PlatformController>().FallDown(fallDelay);
                Destroy(platform, fallDelay + 1);
            }
        }
    }
}
