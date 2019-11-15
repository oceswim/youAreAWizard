using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class refreshManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        Debug.Log("refreshed Count" + GameManager.instance.spawns.Count);
       Debug.Log("refreshed Knights"+ GameManager.instance.knights.Count);

        GameManager.instance.whichSpawn = 1;
        Debug.Log("WHICHSPAWN" + GameManager.instance.whichSpawn+ "AND :"+GameManager.instance.movingOn);
        
    }

   
}
