using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ball : MonoBehaviour {

    public GameObject goal, notgoal;
    public float speed;
    private bool go;
    private float ran;

    void Start()
    {
        go = false;
        ran = Random.Range(300, 1000);
    }

    void FixedUpdate()
    {
        if(go)
        {
            transform.Translate(0, 0, Time.deltaTime * speed);
        }
    }

 void OnTriggerEnter( Collider col)
    {
        if (col.tag == "ny")
        {
            this.transform.localEulerAngles = new Vector3(0, col.transform.localEulerAngles.y, 0);
            go = true;
            GetComponent<Rigidbody>().AddForce(Vector3.up * ran);
        }

        if(col.tag == "se")
            goal.SetActive(true);
        if(col.tag == "fruit")
            goal.SetActive(false);

    }
}
