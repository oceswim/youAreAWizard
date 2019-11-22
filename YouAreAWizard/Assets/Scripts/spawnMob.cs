using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnMob : MonoBehaviour
{
    public GameObject mob;
    public int theSpawnAmount;



    // Start is called before the first frame update
    void Start()
    {
  

        GameManager.instance.AddSpawnToList(this);
      
        //spawnAmount = RoomManager.spawnAmount;
        
        //in game manager create one spawnamount random
        //qd spawn amount atteint, increment count of game manager
        //qd spawn amount des 2 atteint alors gamemanger set next action

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

    // Update is called once per frame

}
