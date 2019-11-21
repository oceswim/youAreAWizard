using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkPointActive : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            PlayerPrefs.SetInt("checkpoint", 1);
            
       }
    }
}