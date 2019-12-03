/*
 * Oceane Peretti - K1844498 - 3D Games programming Assignment 2
 * I confirm that this project is a product of my own and not the one of someone else.
 */
using UnityEngine;

public class shieldDestroy : MonoBehaviour
{
    public AudioClip shield;
    public AudioClip brokenShield;
    private int health = 3;
    void OnEnable()
    {
        AudioSource.PlayClipAtPoint(shield, transform.position);
        
    }
    private void OnCollisionEnter(Collision collsion)
    {
        if(collsion.transform.tag == "ennemySpell")
        {
            if (health == 0)
            {
                //broken shield sound
                health = 3;
                gameObject.SetActive(false);
                AudioSource.PlayClipAtPoint(brokenShield, transform.position);
                OVRTrackedRemote.active = false;
            }
            else
            {
                health--;
            }
        }
    }
}
