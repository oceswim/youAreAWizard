using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileMove : MonoBehaviour
{
    private int speed = 20;
    private float timeBullet = 0;
    public GameObject target;
    public AudioClip hurt,shock,impactShield;

    // Start is called before the first frame update
    private void Start()
    {
       target = GameObject.Find("Player");
    }
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
        switch (collision.transform.tag)
        {
            case "Player":
                AudioSource.PlayClipAtPoint(hurt, collision.transform.position);
                speed = 0;
                //ennemy impacts playerHealth;
                Destroy(gameObject);
                break;
            case "PlayerAttack":
                AudioSource.PlayClipAtPoint(shock, collision.transform.position);
                break;
            case "Shield":
                AudioSource.PlayClipAtPoint(impactShield, collision.transform.position);
                Destroy(gameObject);
                break;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
