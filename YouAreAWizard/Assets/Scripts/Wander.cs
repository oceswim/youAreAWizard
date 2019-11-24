using UnityEngine;
using System.Collections;
[RequireComponent(typeof(CharacterController))]
public class Wander : MonoBehaviour
{
    private RaycastHit hit;
    public float speed = 5;
    public float directionChangeInterval = 1;
    public float maxHeadingChange = 180;
    private bool spell;
    CharacterController controller;
    float heading;
    Vector3 targetRotation;

    void Awake()
    {
        spell = false;
        controller = GetComponent<CharacterController>();

        // Set random initial rotation
        heading = Random.Range(0, 360);
        transform.eulerAngles = new Vector3(0, heading, 0);

        StartCoroutine(NewHeading());
    }

    void Update()
    {

        if (!spell)
        {
            DetectSpell();
            transform.eulerAngles = Vector3.Slerp(transform.eulerAngles, targetRotation, Time.deltaTime * directionChangeInterval);
            var forward = transform.TransformDirection(Vector3.forward);
            controller.SimpleMove(forward * speed);
        }
        else if(spell)
        {
            CTRLBoss.spellSpotted = true;
            heading =90;
            spell = false;

        }
    }

    /// <summary>
    /// Repeatedly calculates a new direction to move towards.
    /// Use this instead of MonoBehaviour.InvokeRepeating so that the interval can be changed at runtime.
    /// </summary>
    IEnumerator NewHeading()
    {
        while (true)
        {
            NewHeadingRoutine();
            yield return new WaitForSeconds(directionChangeInterval);
        }
    }

    /// <summary>
    /// Calculates a new direction to move towards.
    /// </summary>
    void NewHeadingRoutine()
    {
        var floor = Mathf.Clamp(heading - maxHeadingChange, 0, 360);
        var ceil = Mathf.Clamp(heading + maxHeadingChange, 0, 360);
        heading = Random.Range(floor, ceil);
        targetRotation = new Vector3(0, heading, 0);
    }

    void DetectSpell()
    {
        Vector3 position1 = new Vector3(transform.position.x, transform.position.y + 1.5f, transform.position.z);
        Vector3 position2 = new Vector3(transform.position.x, transform.position.y + 1.75f, transform.position.z);
        Vector3 position3 = new Vector3(transform.position.x, transform.position.y + 2f, transform.position.z);
        Vector3 position4 = new Vector3(transform.position.x, transform.position.y + 2.25f, transform.position.z);
        Vector3 position5 = new Vector3(transform.position.x, transform.position.y + 2.5f, transform.position.z);
        Vector3 position6 = new Vector3(transform.position.x, transform.position.y + 2.75f, transform.position.z);

        if (Physics.Raycast(position1 + (transform.forward * 4), -transform.right * .5f, out hit, 5) ||
        Physics.Raycast(position1 + (transform.forward * 4), transform.right * .5f, out hit, 5))
        {
            if (hit.collider.gameObject.CompareTag("PlayerAttack"))
            {
                Debug.Log(hit.collider.name);
                spell = true;
            }
        }
        else if (Physics.Raycast(position2 + (transform.forward * 4), transform.right * .5f, out hit, 5) ||
      Physics.Raycast(position2 + (transform.forward * 4), -transform.right * .5f, out hit, 5))
        {
            if (hit.collider.gameObject.CompareTag("PlayerAttack"))
            {
                Debug.Log(hit.collider.name);
                spell = true;
            }
        }
        else if (Physics.Raycast(position3 + (transform.forward * 4), -transform.right * .5f, out hit, 5) ||
      Physics.Raycast(position3 + (transform.forward * 4), transform.right * .5f, out hit, 5))
        {
            if (hit.collider.gameObject.CompareTag("PlayerAttack"))
            {
                Debug.Log(hit.collider.name);
                spell = true;
            }
        }
        else if (Physics.Raycast(position4 + (transform.forward * 4), -transform.right * .5f, out hit, 5) ||
     Physics.Raycast(position4 + (transform.forward * 4), transform.right * .5f, out hit, 5))
        {
            if (hit.collider.gameObject.CompareTag("PlayerAttack"))
            {
                Debug.Log(hit.collider.name);
                spell = true;
            }
        }
        else if (Physics.Raycast(position5 + (transform.forward * 4), -transform.right * .5f, out hit, 5) ||
      Physics.Raycast(position5 + (transform.forward * 4), transform.right * .5f, out hit, 5))
        {
            if (hit.collider.gameObject.CompareTag("PlayerAttack"))
            {
                Debug.Log(hit.collider.name);
                spell = true;
            }
        }
        else if (Physics.Raycast(position6 + (transform.forward * 4), -transform.right * .5f, out hit, 5) ||
      Physics.Raycast(position6 + (transform.forward * 4), transform.right * .5f, out hit, 5))
        {
            if (hit.collider.gameObject.CompareTag("PlayerAttack"))
            {
                Debug.Log(hit.collider.name);
                spell = true;
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
}
