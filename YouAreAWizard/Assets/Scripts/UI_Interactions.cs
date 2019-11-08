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
        if(OVRTrackedRemote.ShieldActive)
        {
            Debug.Log("Shield");
            toActivate.SetActive(true);
            toDeActivate.SetActive(false);

        }
    }
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
    // Update is called once per frame

}
