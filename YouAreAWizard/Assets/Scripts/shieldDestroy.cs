using System.Collections;
using System.Collections.Generic;
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
    // Start is called before the first frame update
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
