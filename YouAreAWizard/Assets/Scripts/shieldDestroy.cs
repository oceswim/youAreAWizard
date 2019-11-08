using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shieldDestroy : MonoBehaviour
{
    public AudioClip shield;
    private void Start()
    {
        AudioSource.PlayClipAtPoint(shield, transform.position);
    }
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collsion)
    {
        if(collsion.transform.tag == "ennemySpell")
        {
            Destroy(gameObject);
        }
    }
}
