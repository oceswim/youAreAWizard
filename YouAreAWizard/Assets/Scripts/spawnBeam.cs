/*
 * Oceane Peretti - K1844498 - 3D Games programming Assignment 2
 * I confirm that this project is a product of my own and not the one of someone else.
 */
using UnityEngine;

public class spawnBeam : MonoBehaviour
{
    public GameObject firePoint;
    public GameObject vfx;
    private GameObject effectToSpawn;
    void Start()
    {
        effectToSpawn = vfx;
    }

    void Update()
    {
        if (gameObject.tag != "Player")
        {
            if (CTRLWizard.isAttacking==true)
            {
                SpawnVFX();
                vfx.SetActive(false);
            }
        }
    }
    void SpawnVFX()
    {

        if(firePoint!= null)
        {
            vfx.SetActive(true);

        }
        else
        {
            Debug.Log("no fire point");
        }
    }
}
