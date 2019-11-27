using UnityEngine;
using System.Collections;

public class spellSpotter : MonoBehaviour
{
    private RaycastHit hit;
    private bool spell;
    public GameObject vfx;
    void Awake()
    {
       
        spell = false;

    }

    void Update()
    {

        if (!spell)
        {
            DetectSpell();
        }
        else if(spell)
        {
            
            spell = false;
            vfx.SetActive(false);
        }
    }

    /// <summary>
    /// Repeatedly calculates a new direction to move towards.
    /// Use this instead of MonoBehaviour.InvokeRepeating so that the interval can be changed at runtime.
    /// </summary>


    void DetectSpell()
    {
        Vector3 position1 = new Vector3(transform.position.x, transform.position.y + 1.9f, transform.position.z);
        Vector3 position2 = new Vector3(transform.position.x, transform.position.y + 2f, transform.position.z);
        Vector3 position3 = new Vector3(transform.position.x, transform.position.y + 2.1f, transform.position.z);
        Vector3 position4 = new Vector3(transform.position.x, transform.position.y + 2.2f, transform.position.z);
        Vector3 position5 = new Vector3(transform.position.x, transform.position.y + 2.3f, transform.position.z);
        Vector3 position6 = new Vector3(transform.position.x, transform.position.y + 2.4f, transform.position.z);

        if (Physics.Raycast(position1 + (transform.forward * 4), -transform.right * .5f, out hit, 5) ||
        Physics.Raycast(position1 + (transform.forward * 4), transform.right * .5f, out hit, 5))
        {
            if (hit.collider.gameObject.CompareTag("PlayerAttack"))
            {
                Debug.Log(hit.collider.name);
                spell = true;
                DestroySpell(hit);
            }
        }
        else if (Physics.Raycast(position2 + (transform.forward * 4), transform.right * .5f, out hit, 5) ||
      Physics.Raycast(position2 + (transform.forward * 4), -transform.right * .5f, out hit, 5))
        {
            if (hit.collider.gameObject.CompareTag("PlayerAttack"))
            {
                Debug.Log(hit.collider.name);
                spell = true;
                DestroySpell(hit);
            }
        }
        else if (Physics.Raycast(position3 + (transform.forward * 4), -transform.right * .5f, out hit, 5) ||
      Physics.Raycast(position3 + (transform.forward * 4), transform.right * .5f, out hit, 5))
        {
            if (hit.collider.gameObject.CompareTag("PlayerAttack"))
            {
                Debug.Log(hit.collider.name);
                spell = true;
                DestroySpell(hit);
            }
        }
        else if (Physics.Raycast(position4 + (transform.forward * 4), -transform.right * .5f, out hit, 5) ||
     Physics.Raycast(position4 + (transform.forward * 4), transform.right * .5f, out hit, 5))
        {
            if (hit.collider.gameObject.CompareTag("PlayerAttack"))
            {
                Debug.Log(hit.collider.name);
                spell = true;
                DestroySpell(hit);
            }
        }
        else if (Physics.Raycast(position5 + (transform.forward * 4), -transform.right * .5f, out hit, 5) ||
      Physics.Raycast(position5 + (transform.forward * 4), transform.right * .5f, out hit, 5))
        {
            if (hit.collider.gameObject.CompareTag("PlayerAttack"))
            {
                Debug.Log(hit.collider.name);
                spell = true;
                DestroySpell(hit);
            }
        }
        else if (Physics.Raycast(position6 + (transform.forward * 4), -transform.right * .5f, out hit, 5) ||
      Physics.Raycast(position6 + (transform.forward * 4), transform.right * .5f, out hit, 5))
        {
            if (hit.collider.gameObject.CompareTag("PlayerAttack"))
            {
                //Debug.Log(hit.collider.name);
                spell = true;
                DestroySpell(hit);
            }
        }


       


        Debug.DrawRay(position1 + (transform.forward * 4), -transform.right * .5f, Color.yellow);
        Debug.DrawRay(position1 + (transform.forward * 4), transform.right * .5f, Color.yellow);
        Debug.DrawRay(position2 + (transform.forward * 4), -transform.right * .5f, Color.red);
        Debug.DrawRay(position2 + (transform.forward * 4), transform.right * .5f, Color.red);
        Debug.DrawRay(position3 + (transform.forward * 4), -transform.right * .5f, Color.yellow);
        Debug.DrawRay(position3 + (transform.forward * 4), transform.right * .5f, Color.yellow);
        Debug.DrawRay(position4 + (transform.forward * 4), -transform.right * .5f, Color.red);
        Debug.DrawRay(position4 + (transform.forward * 4), transform.right * .5f, Color.red);
        Debug.DrawRay(position5 + (transform.forward * 4), -transform.right * .5f, Color.yellow);
        Debug.DrawRay(position5 + (transform.forward * 4), transform.right * .5f, Color.yellow);
        Debug.DrawRay(position6 + (transform.forward * 4), -transform.right * .5f, Color.red);
        Debug.DrawRay(position6 + (transform.forward * 4), transform.right * .5f, Color.red);
    }

    void DestroySpell(RaycastHit theSpell)
    {
        int random = Random.Range(0,2);

        if (random != 0)
        {
            Destroy(theSpell.collider.gameObject);
            vfx.SetActive(true);
        }
     
    }
}
