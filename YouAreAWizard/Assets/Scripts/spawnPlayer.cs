using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnPlayer : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        spawn();
    }
    private void Update()
    {
        if(CTRLWizard.spawnAgain)
        {
            spawn();
        }
    }
    void spawn()
    {
        Instantiate(player, transform.position, player.transform.rotation);

    }

    // Update is called once per frame

}
