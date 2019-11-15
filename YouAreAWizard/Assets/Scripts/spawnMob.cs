using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnMob : MonoBehaviour
{
    public GameObject mob;
    public int theSpawnAmount;
    public bool canSpawn;
    public bool next;
    private bool spawned;
    // Start is called before the first frame update
    void Start()
    {
        canSpawn = true;
        spawned = false;
        GameManager.instance.AddSpawnToList(this);
        next = false;
        //spawnAmount = RoomManager.spawnAmount;
        theSpawnAmount =Random.Range(1, 3);
        //in game manager create one spawnamount random
        //qd spawn amount atteint, increment count of game manager
        //qd spawn amount des 2 atteint alors gamemanger set next action

    }
    private void Update()
    {
        if (spawned)
        {
            spawned = false;
            theSpawnAmount--;
            //Debug.Log("spw left: "+theSpawnAmount);
            if (theSpawnAmount < 1)
            {
                canSpawn = false;
                GameManager.instance.removeSpawn(this);
                Debug.Log("STOP");
                Destroy(this.gameObject);
            } 
               
        }
        
        

    }

    public void Spawn()
    {
        Instantiate(mob, transform.position, mob.transform.rotation);
        spawned = true;

    }

    // Update is called once per frame

}
