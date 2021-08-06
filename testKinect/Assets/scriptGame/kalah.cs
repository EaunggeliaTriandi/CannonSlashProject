using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class kalah : MonoBehaviour
{
    public Text textsc1;

    void OnCollisionEnter(Collision col)
    {
        
            if (col.gameObject.name == "miss")
            {
                NotGoal.ungol = "LOSE!!";
            }
       
    }
    void Update()
    {
        textsc1.text = NotGoal.ungol;

    }

}
