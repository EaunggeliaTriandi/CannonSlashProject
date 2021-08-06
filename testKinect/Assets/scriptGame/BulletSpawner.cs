using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour {
    public static float cooldown;
    public GameObject spawnObject;
    public GameObject[] spawnPoint;

    float timer;

    void Start() {
        timer = 5f;
    }
    
    void Update() {
        if (GameSystem.isPlaying) {
            cooldown = GameSystem.bulletCooldown;

            if (timer <= 0) {
                Instantiate(spawnObject, spawnPoint[Random.Range(0, spawnPoint.Length)].transform.position, new Quaternion());
                timer = cooldown;
            }

            timer -= Time.deltaTime;
        }
    }
}
