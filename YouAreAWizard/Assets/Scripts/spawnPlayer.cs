using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnPlayer : MonoBehaviour
{
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        GameObject go = Instantiate(Player, transform.position, Quaternion.identity) as GameObject;
        go.transform.rotation = transform.rotation;
        go.transform.parent = GameObject.Find("/Spawner").transform;
        //Instantiate(Player);
    }
}
