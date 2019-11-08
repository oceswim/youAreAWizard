using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileMove : MonoBehaviour
{
    private int speed=20;
    private int theDamage = 1;
    private float timeBullet = 0;
    public GameObject target;
    public AudioClip hurt;
    public AudioClip shock;

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if(speed != 0)
        {
     
         transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
            
        }
        if (timeBullet>3)
        {
            Destroy(gameObject);
            timeBullet = 0;
        }
        else
        {
            timeBullet += Time.deltaTime;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(transform.tag == "ennemySpell")
        {
            if (collision.transform.tag == "Player")
            {
                
                AudioSource.PlayClipAtPoint(hurt, collision.transform.position);
                speed = 0;
                Destroy(gameObject);
            }
            else if(collision.transform.tag== "PlayerAttack")
            {
                AudioSource.PlayClipAtPoint(shock, collision.transform.position);
            }

        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
