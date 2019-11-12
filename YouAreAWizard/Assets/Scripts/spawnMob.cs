using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnMob : MonoBehaviour
{
    public GameObject mob;
    public GameObject[] spawns;
    public GameObject[] jails;
    public GameObject nextStep;
    public int spawnAmount;
    private int theSpawnAmount;
    private int index;
    public static bool next;
    // Start is called before the first frame update
    void Start()
    {
        next = false;
        theSpawnAmount = Random.Range(2, spawnAmount);
        //in game manager create one spawnamount random
        //qd spawn amount atteint, increment count of game manager
        //qd spawn amount des 2 atteint alors gamemanger set next action
        index = Random.Range(0, (spawns.Length-1));
        if(index>1)
        {
            mob.tag = "Lv3";
        }
        spawn(spawns[index]);
    }
    private void Update()
    {
        if(CTRLWizard.isDead && theSpawnAmount>0)
        {
            index = Random.Range(0, (spawns.Length - 1));
            if (index > 1)
            {
                mob.tag = "Lv3";
            }
            spawn(spawns[index]);
        }
        else if(theSpawnAmount<=0)
        {
            foreach (GameObject s in jails)
            {
                s.SetActive(true);
            }
            nextStep.SetActive(true);
        }
    }
    void spawn(GameObject thespawn)
    {

        theSpawnAmount--;
        Instantiate(mob, thespawn.transform.position, mob.transform.rotation);
          

    }

    // Update is called once per frame

}
