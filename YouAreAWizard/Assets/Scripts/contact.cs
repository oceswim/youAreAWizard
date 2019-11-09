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
    // Start is called before the first frame update
    // Update is called once per frame
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
        if (collision.gameObject.name == "wizard_Sword" || collision.gameObject.name == "wizard_Wand")
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
                CTRLpatrol.isDefending = true;
                single++;
            }

            PlayerDestroy gateLife = collision.collider.GetComponent<PlayerDestroy>();
            if (gateLife != null)
            {
                gateLife.DoorDamage(theDamage);
            }
            Destroy(gameObject);
            speed = 0;
        }
        else if (collision.gameObject.tag == "ennemySpell")
        {
            AudioSource.PlayClipAtPoint(shock, collision.transform.position);

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}

