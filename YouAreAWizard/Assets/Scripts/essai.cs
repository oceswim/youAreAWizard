using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class essai : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Skull")
        {
            CTRLBoss health = collision.collider.GetComponent<CTRLBoss>();
            if (health != null)
            {
                health.DamageSkull(1);
            }
            gameObject.SetActive(false);
        }
    }

}
