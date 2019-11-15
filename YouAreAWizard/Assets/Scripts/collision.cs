using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collision : MonoBehaviour
{
    private int theDamage = 1;
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.name == "wizard_Sword(Clone)" || collision.gameObject.name == "wizard_Sword")
        {
            GameObject objectCollided = collision.gameObject;
            CTRLWizard health = objectCollided.GetComponent<CTRLWizard>();

            if (health != null)
            {
                health.DamageWizard(theDamage);
            }
    
        
        }
        else if (collision.gameObject.name == "wizard_Wand(Clone)" || collision.gameObject.name == "wizard_Wand")
        {
            GameObject objectCollided = collision.gameObject;
            CTRLpatrol health = objectCollided.GetComponent<CTRLpatrol>();

            if (health != null)
            {
                health.DamagePatrol(theDamage);
            }
        }
    }
}
