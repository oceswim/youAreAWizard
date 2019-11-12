using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activate : MonoBehaviour
{
    public GameObject toActivate;
    // Start is called before the first frame update
    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {

        toActivate.SetActive(true);
        Destroy(gameObject);

    }
}