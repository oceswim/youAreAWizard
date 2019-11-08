using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rayDetect : MonoBehaviour
{

    public Transform theShield;
    private bool shield;
    string directionHit;
    private void Start()
    {
        shield = false;
    }
    private void Update()
    {
        if(shield)
        {

            
        }
    }
    private void OnTriggerEnter(Collider other)
    {
    
            switch (transform.tag)
        {
            case "RayDetect":
                shield = true;
                directionHit = "middle";
                break;
            case "RayDetectL":

                directionHit = "left";

                break;
            case "RayDetectR":

                directionHit = "right";

                break;
        }
    }



}
