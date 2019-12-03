/*
 * Oceane Peretti - K1844498 - 3D Games programming Assignment 2
 * I confirm that this project is a product of my own and not the one of someone else.
 */
using System.Collections;
using UnityEngine;

public class spawnRay : MonoBehaviour
{




    public AudioClip cast;
    public Transform spawner;
    public float range = 100f;
    public float hitForce = 100f;
    public int theDamage = 1;

    public Transform theWand;
    public GameObject vfx;
    private GameObject effectToSpawn;

    void Start()
    {
        effectToSpawn = vfx;
    }

    public void CastSpell()
    {
        StartCoroutine(ShotEffect());

        if (spawner != null)
        {
            vfx = Instantiate(effectToSpawn, spawner.transform.position, Quaternion.identity);
            vfx.transform.localRotation = theWand.rotation;
        }



    }

    private IEnumerator ShotEffect()
    {

        AudioSource.PlayClipAtPoint(cast, transform.position);

        yield return new WaitForSeconds(.5f);

    }



}


