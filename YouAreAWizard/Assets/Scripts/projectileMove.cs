using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileMove : MonoBehaviour
{
    private int speed=20;
    private int theDamage = 1;
    private float timeBullet = 0;
    public GameObject thePlayer;
    public AudioClip hurt;

    // Start is called before the first frame update
    void Start()
    {
        if (transform.tag != "player")
        {
            thePlayer = GameObject.Find("/Player");
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(speed != 0)
        {
            if (transform.tag == "Player")
            {
                transform.position += transform.forward * (speed * Time.deltaTime);
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, thePlayer.transform.position, speed * Time.deltaTime);
            }
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
        if(transform.name == "EnnemySpell")
        {
            if (collision.transform.tag == "Player")
            {
                AudioSource.PlayClipAtPoint(hurt, collision.transform.position);
                speed = 0;
                Destroy(gameObject);
            }
        
        }
        else if(transform.name=="PlayerSpell")
        {
            if (collision.transform.name == "wizard_Sword" || collision.transform.name == "wizard_Wand")
            {
                Impact health = collision.collider.GetComponent<Impact>();

                if (health != null)
                {
                    health.Damage(theDamage);
                }
                Destroy(gameObject);
                speed = 0;
            }
            else if(collision.transform.name == "DungeonGate")
            {
                PlayerDestroy gateLife = collision.collider.GetComponent<PlayerDestroy>();
                if(gateLife != null)
                {
                    gateLife.DoorDamage(theDamage);
                }
                Destroy(gameObject);
                speed = 0;
            }
        }
        else
        {
            Destroy(gameObject);
        }
     
        
        
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
