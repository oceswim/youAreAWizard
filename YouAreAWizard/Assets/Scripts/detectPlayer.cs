/*
 * Oceane Peretti - K1844498 - 3D Games programming Assignment 2
 * I confirm that this project is a product of my own and not the one of someone else.
 */
using UnityEngine;

public class detectPlayer : MonoBehaviour
{
    public AudioSource fight;
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
