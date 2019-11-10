using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnMob : MonoBehaviour
{
    public GameObject player;
    public int spawnAmount;
    public static bool next;
    // Start is called before the first frame update
    void Start()
    {
        next = false;
        spawnAmount = RoomManager.spawnAmount-1;
        //in game manager create one spawnamount random
        //qd spawn amount atteint, increment count of game manager
        //qd spawn amount des 2 atteint alors gamemanger set next action
        spawn();
    }
    private void Update()
    {
        if(CTRLWizard.spawnAgain)
        {
            if (spawnAmount > 0)
            {
				CTRLWizard.spawnAgain = false;
                spawn();
                spawnAmount--;
            }
            else
            {
                next = true;
            }
        }
    }
    void spawn()
    {
    
            Instantiate(player, transform.position, player.transform.rotation);
          

    }

    // Update is called once per frame

}
