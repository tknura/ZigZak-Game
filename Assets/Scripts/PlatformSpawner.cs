using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platform;
    public GameObject diamonds;
    
    float sizeX, sizeZ;
    Vector3 lastPosition;
    float spawnRate;

    void Start() {
        lastPosition = platform.transform.position;
        sizeX = platform.transform.localScale.x;
        sizeZ = platform.transform.localScale.z;
        for(int i = 0; i < 15; i++) {
            SpawnPlatforms();
        }
    }

    public void SpawnPlatforms() {
        if(GameManager.gameOver) {
            return;
        }
        int rand = Random.Range(0, 2);
        if (rand == 0) {
            Spawn("x");
        }
        else {
            Spawn("z");
        }
    }

    void Spawn(string axis) {
        Vector3 pos = lastPosition;
        if (axis == "x") {
            pos.x += sizeX;
        }
        else if (axis == "z") {
            pos.z += sizeZ;
        }
        lastPosition = pos;
        GameObject spawnedPlatform = Instantiate(platform, pos, Quaternion.identity) as GameObject;
        spawnedPlatform.GetComponent<DOMoveAnimation>().PlayY();
        pos.y = spawnedPlatform.GetComponent<DOMoveAnimation>().toValueY;
        SpawnDiamond(pos);
    }

    void SpawnDiamond(Vector3 pos) {
        int rand = Random.Range(0, 7);
        pos.y += 1f;
        if(rand == 0) {
            GameObject spawnedDiamond = Instantiate(diamonds, pos, diamonds.transform.rotation) as GameObject;
        }
    }
}
