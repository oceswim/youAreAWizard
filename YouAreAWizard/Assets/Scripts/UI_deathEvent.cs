/*
 * Oceane Peretti - K1844498 - 3D Games programming Assignment 2
 * I confirm that this project is a product of my own and not the one of someone else.
 */
using UnityEngine;

public class UI_deathEvent : MonoBehaviour
{
    public GameObject toActivate;//the object to activate once ennemy dies
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
