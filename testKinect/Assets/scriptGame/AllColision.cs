using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AllColision : MonoBehaviour
{
    public Text textsc;


    // Start is called before the first frame update
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Net_Cube")
        {
            Score.gol = "GOLL!!!";
        }
    }


    void Update()
    {
        textsc.text = Score.gol;

    }

}
