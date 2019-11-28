using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detectPlayer : MonoBehaviour
{
    public AudioSource fight;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag.Equals("Player"))
        {
            CTRLBoss.playerSpotted = true;
            fight.Play();
            gameObject.SetActive(false);
        }
    }
}
