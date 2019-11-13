using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activate : MonoBehaviour
{
    public GameObject toActivate;
    public static bool activation;
    private void Start()
    {
        activation = false;

    }
    private void Update()
    {
        if(gameObject.tag=="magicStone")
        {
            if (activation)
            {
                toActivate.SetActive(false);//desactive magic barrier
                activation = false;
            }
        }
    }
    // Start is called before the first frame update
    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {

        toActivate.SetActive(true);
        Destroy(gameObject);

    }
}