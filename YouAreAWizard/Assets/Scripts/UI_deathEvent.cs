using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_deathEvent : MonoBehaviour
{
    public GameObject toActivate;
    // Start is called before the first frame update
    private void Update()
    {
        if (transform.name == "goTodungeon")
        {
            if (knightTutoScript.isDead)
            {
                toActivate.SetActive(true);
            }
        }
        else if (transform.name=="destroyGate")
        {
            if (contact.activate)
            {
                toActivate.SetActive(true);
                gameObject.SetActive(false);
            }
        }
    }
   
}
