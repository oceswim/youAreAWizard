using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class des : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "wizard_Sword(Clone)" || collision.gameObject.name == "wizard_Wand(Clone)")
        {
            Impact health = collision.collider.GetComponent<Impact>();

            if (health != null)
            {
                health.Damage(1);
            }
            Destroy(gameObject);
          
        }

    }
}