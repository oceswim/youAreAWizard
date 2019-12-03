/*
 * Oceane Peretti - K1844498 - 3D Games programming Assignment 2
 * I confirm that this project is a product of my own and not the one of someone else.
 */
using UnityEngine;

public class Deactivate : MonoBehaviour
{
    public GameObject[] toDeactivate;
    public GameObject[] toActivate;
    private int single;
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
            Destroy(gameObject);//destroy the object to deactivate 
         
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
