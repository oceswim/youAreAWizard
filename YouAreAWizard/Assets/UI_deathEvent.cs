using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_deathEvent : MonoBehaviour
{
    public GameObject toActivate;
    // Start is called before the first frame update
    private void Update()
    {
        if (CTRLWizard.isDead)
        {
            toActivate.SetActive(true);
        }
    }
   
}
