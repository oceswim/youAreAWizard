using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class contact : MonoBehaviour
{
    private int speed = 20;
    private int theDamage = 1;
    private float timeBullet = 0;
    public AudioClip hurt;
    public AudioClip shock;
    private int single = 0;
    public static bool activate;
    // Start is called before the first frame update
    // Update is called once per frame
    private void Start()
    {
        activate = false;
    }
    void Update()
    {
        if (speed != 0)
        {

            transform.position += transform.forward * (speed * Time.deltaTime);

        }
        if (timeBullet > 3)
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
        if (collision.gameObject.name == "wizard_Sword(Clone)" || collision.gameObject.name == "wizard_Wand(Clone)" || collision.gameObject.name == "wizard_Sword" || collision.gameObject.name == "wizard_Wand")
        {
            Impact health = collision.collider.GetComponent<Impact>();

            if (health != null)
            {
                health.Damage(theDamage);
            }
            Destroy(gameObject);
            speed = 0;
        }
        else if (collision.gameObject.name == "DungeonGate")
        {
           
            if (single == 0)
            {
                activate = true;
                CTRLpatrol.isDefending = true;
                single++;
            }

            PlayerDestroy gateLife = collision.collider.GetComponent<PlayerDestroy>();
            if (gateLife != null)
            {
                gateLife.theDamage(theDamage);
            }
            Destroy(gameObject);
            speed = 0;
        }
        else if (collision.gameObject.tag == "ennemySpell")
        {
            AudioSource.PlayClipAtPoint(shock, collision.transform.position);

        }
        else if(collision.gameObject.tag == "magicStone")
        {

            if (single == 0)
            {
                activate = true;
                CTRLpatrol.isDefending = true;
                single++;
            }

            PlayerDestroy stoneLife = collision.collider.GetComponent<PlayerDestroy>();
            if (stoneLife != null)
            {
                stoneLife.theDamage(theDamage);
            }
            Destroy(gameObject);
            speed = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}

