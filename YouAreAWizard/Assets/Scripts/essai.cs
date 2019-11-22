using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class essai : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        PlayerLife.UpdateLifeBar(1); 
    }
}
