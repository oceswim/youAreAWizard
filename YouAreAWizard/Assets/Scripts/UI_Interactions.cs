using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Interactions : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject toActivate;
    public GameObject toDeActivate;

    private void Update()
    {
       
    }
    void OnTriggerEnter(Collider other)
    {
        if (gameObject.name != "wizard_Sword")
        {
            toActivate.SetActive(true);
        }
        toDeActivate.SetActive(false);
        
        if (other.transform.CompareTag("PlayerAttack"))
        {
            Destroy(other.transform);
            Destroy(gameObject);//destroy the object hit
            if(gameObject.name=="wizard_Sword")
            {
                toActivate.SetActive(true);
            }
        }
        else if (other.transform.tag=="Player")
        {
            Destroy(gameObject);//destroy the teleport area
            Debug.Log("ouch");
            
        }


    }
    void OnCollisionEnter(Collision other)
    {
        toActivate.SetActive(true);
        toDeActivate.SetActive(false);

        if (other.transform.CompareTag("PlayerAttack"))
        {
            Destroy(other.transform);
            Destroy(gameObject);//destroy the orb
        }
        else if (other.transform.tag == "Player")
        {
            Destroy(gameObject);//destroy the teleport area

        }


    }
    // Update is called once per frame

}
