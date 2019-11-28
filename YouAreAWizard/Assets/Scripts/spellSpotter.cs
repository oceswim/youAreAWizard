using UnityEngine;
using System.Collections;

public class spellSpotter : MonoBehaviour
{
    private RaycastHit hit;
    private bool spell;
    public GameObject particle;
    private ParticleSystem vfx;
    private float timer;
    public AudioSource shield;
    void Awake()
    {
        timer = 0; 
        vfx = particle.GetComponent<ParticleSystem>();
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
            if (timer > 1.2f)
            {
                timer = 0;
                spell = false;
                vfx.Pause();
                particle.SetActive(false);
            }
            else
            {
                timer += Time.deltaTime;
            }
        }
    }

    /// <summary>
    /// Repeatedly calculates a new direction to move towards.
    /// Use this instead of MonoBehaviour.InvokeRepeating so that the interval can be changed at runtime.
    /// </summary>


    void DetectSpell()
    {
        Vector3 position1 = new Vector3(transform.position.x, transform.position.y + 1.9f, transform.position.z);
        Vector3 position11 = new Vector3(transform.position.x, transform.position.y + 1.95f, transform.position.z);

        Vector3 position2 = new Vector3(transform.position.x, transform.position.y + 2f, transform.position.z);
        Vector3 position22 = new Vector3(transform.position.x, transform.position.y + 2.05f, transform.position.z);

        Vector3 position3 = new Vector3(transform.position.x, transform.position.y + 2.1f, transform.position.z);
        Vector3 position33 = new Vector3(transform.position.x, transform.position.y + 2.15f, transform.position.z);

        Vector3 position4 = new Vector3(transform.position.x, transform.position.y + 2.2f, transform.position.z);
        Vector3 position44 = new Vector3(transform.position.x, transform.position.y + 2.25f, transform.position.z);

        Vector3 position5 = new Vector3(transform.position.x, transform.position.y + 2.3f, transform.position.z);
        Vector3 position55 = new Vector3(transform.position.x, transform.position.y + 2.35f, transform.position.z);

        Vector3 position6 = new Vector3(transform.position.x, transform.position.y + 2.4f, transform.position.z);
        Vector3 position66 = new Vector3(transform.position.x, transform.position.y + 2.45f, transform.position.z);


        if (Physics.Raycast(position1 + (transform.forward * 4), -transform.right * .5f, out hit, 5) ||
        Physics.Raycast(position1 + (transform.forward * 4), transform.right * .5f, out hit, 5))
        {
            if (hit.collider.gameObject.CompareTag("PlayerAttack"))
            {
                Debug.Log(hit.collider.name);
                spell = true;
                DestroySpell(hit);
                return;
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
                return;

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
                return;

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
                return;

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
                return;

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
                return;

            }
        }
        else if (Physics.Raycast(position11 + (transform.forward * 4), -transform.right * .5f, out hit, 5) ||
        Physics.Raycast(position11 + (transform.forward * 4), transform.right * .5f, out hit, 5))
        {
            if (hit.collider.gameObject.CompareTag("PlayerAttack"))
            {
                Debug.Log(hit.collider.name);
                spell = true;
                DestroySpell(hit);
                return;

            }
        }
        else if (Physics.Raycast(position22 + (transform.forward * 4), transform.right * .5f, out hit, 5) ||
      Physics.Raycast(position22 + (transform.forward * 4), -transform.right * .5f, out hit, 5))
        {
            if (hit.collider.gameObject.CompareTag("PlayerAttack"))
            {
                Debug.Log(hit.collider.name);
                spell = true;
                DestroySpell(hit);
                return;

            }
        }
        else if (Physics.Raycast(position33 + (transform.forward * 4), -transform.right * .5f, out hit, 5) ||
      Physics.Raycast(position33 + (transform.forward * 4), transform.right * .5f, out hit, 5))
        {
            if (hit.collider.gameObject.CompareTag("PlayerAttack"))
            {
                Debug.Log(hit.collider.name);
                spell = true;
                DestroySpell(hit);
                return;

            }
        }
        else if (Physics.Raycast(position44 + (transform.forward * 4), -transform.right * .5f, out hit, 5) ||
     Physics.Raycast(position44 + (transform.forward * 4), transform.right * .5f, out hit, 5))
        {
            if (hit.collider.gameObject.CompareTag("PlayerAttack"))
            {
                Debug.Log(hit.collider.name);
                spell = true;
                DestroySpell(hit);
                return;

            }
        }
        else if (Physics.Raycast(position55 + (transform.forward * 4), -transform.right * .5f, out hit, 5) ||
      Physics.Raycast(position55 + (transform.forward * 4), transform.right * .5f, out hit, 5))
        {
            if (hit.collider.gameObject.CompareTag("PlayerAttack"))
            {
                Debug.Log(hit.collider.name);
                spell = true;
                DestroySpell(hit);
                return;

            }
        }
        else if (Physics.Raycast(position66 + (transform.forward * 4), -transform.right * .5f, out hit, 5) ||
      Physics.Raycast(position66 + (transform.forward * 4), transform.right * .5f, out hit, 5))
        {
            if (hit.collider.gameObject.CompareTag("PlayerAttack"))
            {
                //Debug.Log(hit.collider.name);
                spell = true;
                DestroySpell(hit);
                return;

            }
        }





        Debug.DrawRay(position11 + (transform.forward * 4), -transform.right * .5f, Color.yellow);
        Debug.DrawRay(position11 + (transform.forward * 4), transform.right * .5f, Color.yellow);
        Debug.DrawRay(position22 + (transform.forward * 4), -transform.right * .5f, Color.red);
        Debug.DrawRay(position22 + (transform.forward * 4), transform.right * .5f, Color.red);
        Debug.DrawRay(position33 + (transform.forward * 4), -transform.right * .5f, Color.yellow);
        Debug.DrawRay(position33 + (transform.forward * 4), transform.right * .5f, Color.yellow);
        Debug.DrawRay(position44 + (transform.forward * 4), -transform.right * .5f, Color.red);
        Debug.DrawRay(position44 + (transform.forward * 4), transform.right * .5f, Color.red);
        Debug.DrawRay(position55 + (transform.forward * 4), -transform.right * .5f, Color.yellow);
        Debug.DrawRay(position55 + (transform.forward * 4), transform.right * .5f, Color.yellow);
        Debug.DrawRay(position66 + (transform.forward * 4), -transform.right * .5f, Color.red);
        Debug.DrawRay(position66 + (transform.forward * 4), transform.right * .5f, Color.red);
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
        int random = Random.Range(0,3);
        Debug.Log(random);
        if (random != 1)
        {
            Debug.Log("YES"+random);
            Destroy(theSpell.collider.gameObject);
            particle.SetActive(true);
            shield.Play();
            vfx.Play();
            CTRLBoss.healthUp = true;//increases the life of Skull if spell destroyed.

            
        }
        else
        {
            Debug.Log("NO"+random);
        }
     
    }
}
