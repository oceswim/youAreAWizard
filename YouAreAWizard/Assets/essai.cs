using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class essai : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "wizard_Sword(Clone)" || collision.gameObject.name == "wizard_Sword")
        {
            CTRLWizard health = collision.collider.GetComponent<CTRLWizard>();
            Debug.Log("ouch");
            if (health != null)
            {
                health.DamageWizard(1);
            }
            //Destroy(gameObject);
            
        }
    }
}
