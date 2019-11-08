using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class essai : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("ouch");
        CTRLpatrol.isDefending = true;
        Destroy(gameObject);
    }

}
