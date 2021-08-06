using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    public static float speed;
    public int score = 50; 
    public string targetName;
    Vector3 targetPos;

    void Start() {
        GameObject target = GameObject.Find(targetName);
        targetPos = target.transform.position;
        Vector3 targetSize = target.GetComponent<SpriteRenderer>().bounds.size;
        Vector3 maxPoint = targetPos + (targetSize / 2);
        Vector3 minPoint = targetPos - (targetSize / 2);

        Vector3 targetPoint = new Vector3(Random.Range(minPoint.x, maxPoint.x), Random.Range(minPoint.y, maxPoint.y), targetPos.z);
        transform.LookAt(targetPoint);

        speed = GameSystem.bulletSpeed;
    }

    void Update() {
        transform.position += transform.forward * speed * Time.deltaTime;

        if (transform.position.z <= targetPos.z) {
            GameSystem.Damage(1);
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider col) {
        if (col.gameObject.layer == LayerMask.NameToLayer("katana")) {
            GameSystem.AddScore(score);
            Destroy(gameObject);
        }
    }

}
