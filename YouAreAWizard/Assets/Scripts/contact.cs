/*
 * Oceane Peretti - K1844498 - 3D Games programming Assignment 2
 * I confirm that this project is a product of my own and not the one of someone else.
 */

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
        if (collision.gameObject.name == "wizard_Sword(Clone)" || collision.gameObject.name == "wizard_Sword")
        {
            CTRLWizard health = collision.collider.GetComponent<CTRLWizard>();

            if (health != null)
            {
                health.DamageWizard(theDamage);
            }
            Destroy(gameObject);
            speed = 0;
        }
        else if(collision.gameObject.name == "wizard_Wand" || collision.gameObject.name == "wizard_Wand(Clone)"|| collision.gameObject.name == "wizard_Wand1(Clone)" || collision.gameObject.name == "wizard_Wand2(Clone)")
        {
            CTRLpatrol health = collision.collider.GetComponent<CTRLpatrol>();

            if (health != null)
            {
                health.DamagePatrol(theDamage);
            }
            Destroy(gameObject);
            speed = 0;
        }
        else if(collision.gameObject.name=="Skull")
        {
            CTRLBoss health = collision.collider.GetComponent<CTRLBoss>();
            if(health!=null)
            {
                health.DamageSkull(theDamage);
            }
            Destroy(gameObject);
            speed = 0;
        }
       
        else if (collision.gameObject.name == "destroyGate")
        {
           
            if (single == 0)
            {
                activate = true;
                patrolTutoScript.isDefending = true;
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
        else if(collision.gameObject.tag == "finalBoss")
        {

        }
    }

   
}

