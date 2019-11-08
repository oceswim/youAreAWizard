using System.Collections;
using UnityEngine;

public class spawnRay : MonoBehaviour
{
    /*
     *
     *
     *
     * DEAL LINE RENDERER HERE
     */


    
 
    public AudioClip cast;
    public Transform spawner;
    public float range = 100f;
    public float hitForce = 100f;
    public int theDamage = 1;
    private LineRenderer laserLine;

    public Transform theWand;
    public GameObject vfx;
    private GameObject effectToSpawn;
    //private float speed = 5f;
    //can add bonus array
    void Start()
    {
		effectToSpawn = vfx;
        laserLine = GetComponent<LineRenderer>();
    }

    public void CastSpell()
    {
        StartCoroutine(ShotEffect());

        /*RaycastHit hit;
        laserLine.SetPosition(0, spawner.position);
        Ray theRay = new Ray(spawner.position, spawner.forward);

        if (Physics.Raycast(theRay, out hit, range))
        {
            if (hit.collider.gameObject.tag == "RayDetect")
            {
                Destroy(laserLine);
            }
            else
            {
                AudioSource.PlayClipAtPoint(touch, transform.position, 1f);

                laserLine.SetPosition(1, hit.point);
                Impact health = hit.collider.GetComponent<Impact>();

                if (health != null)
                {
                    health.Damage(theDamage);
                }
                if (hit.rigidbody != null)
                {
                    hit.rigidbody.AddForce(-hit.normal * hitForce);
                }
            }
        }
        else
        {
            AudioSource.PlayClipAtPoint(miss, transform.position, 1f);

            laserLine.SetPosition(1, spawner.forward * 500);
        }*/
     
            if (spawner != null)
            {
                vfx = Instantiate(effectToSpawn, spawner.transform.position, Quaternion.identity);
                vfx.transform.localRotation = theWand.rotation;
            }

       

    }

    private IEnumerator ShotEffect()
    {
        // Turn on our line renderer
        // laserLine.enabled = true;
        AudioSource.PlayClipAtPoint(cast,transform.position);
        //Wait for 1 seconds
        yield return new WaitForSeconds(.5f);

        // Deactivate our line renderer after waiting
        laserLine.enabled = false;
    }
    


}


