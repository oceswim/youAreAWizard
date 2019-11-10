using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    // Start is called before the first frame update
  
    public static RoomManager instance;
    public int nextStep;
    public static int spawnAmount;

    private void Awake()//allows to check if there is only a single instance of the game object. 
    {
     
        spawnAmount = Random.Range(2, 5);
        Debug.Log(spawnAmount);
        if (instance == null)//game object is a singleton, there can be only one.
        {
            instance = this;

        }
        else if (instance != this)//if not destroy the additional instance.
        {
            Destroy(gameObject);
        }
    }
    public static RoomManager Instance
    {
        get
        {
            if (instance == null)//if awake found no instance, a new one is created.
            {
                instance = new RoomManager();
            }
            return instance;
        }
    }

    public void Update()
    {
        if (spawnMob.next)
        {
            Debug.Log(spawnMob.next);
            nextStep++;
        }
        if(nextStep==2)
        {
            //nextStepAction
            nextStep = 0;
        }
    }

   


    

}
