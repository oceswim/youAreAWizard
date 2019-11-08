using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Interactions : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject toActivate;
    public GameObject toDeActivate;
    void OnTriggerEnter(Collider other)
    {
            Debug.Log("Ouch");
            toActivate.SetActive(true);
            toDeActivate.SetActive(false);
        if (other.transform.CompareTag("Player"))
        {
            Destroy(other.transform);
        }
        
        
    }
    private void OnTriggerStay(Collider other)
    {
        Debug.Log("Ouch" + other.transform.tag);
        toActivate.SetActive(true);
        toDeActivate.SetActive(false);
        if (other.transform.CompareTag("Shield"))
        {

            Destroy(gameObject);
        }
    }

    // Update is called once per frame

}
