/*
 * Oceane Peretti - K1844498 - 3D Games programming Assignment 2
 * I confirm that this project is a product of my own and not the one of someone else.
 */
using UnityEngine;

public class spawnMob : MonoBehaviour
{
    public GameObject mob;
    public int theSpawnAmount;

    void Start()
    {
  

        GameManager.instance.AddSpawnToList(this);


    }
    private void Update()
    {
        if (theSpawnAmount==0)
        {
           
          GameManager.instance.RemoveSpawn(this);
             
        } 
    }

    public void Spawn()
    {
        Instantiate(mob, transform.position, mob.transform.rotation);
        theSpawnAmount--;

    }



}
