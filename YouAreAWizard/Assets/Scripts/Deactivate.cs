using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deactivate : MonoBehaviour
{
    public GameObject[] toDeactivate;
    public GameObject[] toActivate;
    private int single;
    // Start is called before the first frame update
    private void Start()
    {
        single = 0;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player")|| transform.CompareTag("orb"))
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
    private void OnCollisionEnter(Collision collision)
    {
        if(transform.tag == "magicStone")
        {
            if (single == 1)
            {
                
                foreach (GameObject t in toActivate)
                {
                    t.SetActive(true);
                }
                foreach (GameObject s in toDeactivate)
                {

                    s.SetActive(false);
                }
            }
            else
            {
                single++;
            }
        }
    }
}
