using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deactivate : MonoBehaviour
{
    public GameObject[] toDeactivate;
    public GameObject[] toActivate;
  
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            foreach (GameObject t in toActivate)
            {
                t.SetActive(true);
            }
            foreach (GameObject s in toDeactivate)
            {
                
                    s.SetActive(false);
                
                
            }
            
            Destroy(gameObject);//destroy the teleport area
         
        }
    }
}
