using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileMove : MonoBehaviour
{
    public float speed;
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
        Debug.Log(thePlayer.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if(speed !=0)
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
        if(collision.transform.tag == "Player")
        {
            AudioSource.PlayClipAtPoint(hurt, collision.transform.position);
        }
        else if(collision.transform.name == "wizard_Sword" || collision.transform.name == "wizard_Wand")
        {
            Impact health = collision.collider.GetComponent<Impact>();

            if (health != null)
            {
                health.Damage(theDamage);
            }
          
        }
        speed = 0;
        Destroy(gameObject);
    }
}
