using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnBeam : MonoBehaviour
{
    public GameObject firePoint;
    public GameObject vfx;
    private GameObject effectToSpawn;
    // Start is called before the first frame update
    void Start()
    {
        effectToSpawn = vfx;
    }

    // Update is called once per frame
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
        else
        {
            //player beam
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
