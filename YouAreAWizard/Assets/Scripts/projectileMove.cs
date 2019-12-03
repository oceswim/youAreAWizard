/*
 * Oceane Peretti - K1844498 - 3D Games programming Assignment 2
 * I confirm that this project is a product of my own and not the one of someone else.
 */
using UnityEngine;

public class projectileMove : MonoBehaviour
{
    private int speed = 20;
    private float timeBullet = 0;
    public GameObject target;
    public AudioClip hurt,shock,impactShield;

    private void Start()
    {

       target = GameObject.Find("Player");
    }
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
                Player.hurt = true;
                Destroy(gameObject);
                break;
            case "PlayerAttack":
                AudioSource.PlayClipAtPoint(shock, collision.transform.position);
                Destroy(gameObject);
                Destroy(collision.gameObject);
                break;
            case "Shield":
                AudioSource.PlayClipAtPoint(impactShield, collision.transform.position);
                Destroy(gameObject);
                break;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
      
        Destroy(gameObject);
    }
}
