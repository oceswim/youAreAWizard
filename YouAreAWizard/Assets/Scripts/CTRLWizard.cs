using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class CTRLWizard : MonoBehaviour
{

    private float move = 5;
    private float rotationSpeed = 6;
    public GameObject thePlayer;
    public Transform goal;

    public GameObject firePoint;
    public GameObject vfx;
    private GameObject effectToSpawn;
    public AudioClip attack;
    public Vector3 theTarget;
    private int single;

    private bool hasArrived;
    public static bool isDead;


    public static bool isAttacking;
    private float shot, dead;
    private Animator _animator;
    private float _timeTillAttack = 3f;
    // Use this for initialization
    void Start()
    {
        
        effectToSpawn = vfx;
        _animator = GetComponent<Animator>();

        shot = dead = single= 0;

        isDead = false;
   
        isAttacking = false;
        hasArrived = false;
        theTarget = goal.position;

    }

    // Update is called once per frame
    void Update()
    {

        if (!hasArrived)
        {

            if(isDead)
            {
                Die();
            }
            else
            {
                _animator.SetBool("isMoving", true);

                transform.rotation = Quaternion.Slerp(transform.rotation,
                    Quaternion.LookRotation(theTarget - transform.position),
                    rotationSpeed * Time.deltaTime);
                transform.position += transform.forward * move * Time.deltaTime;

            }

        }
        else if (hasArrived)
        {
         
               
            if(isDead)
            {
                Die();
            }
            else
            {
                Attack();
            }
        }

        hasArrived |= Mathf.Abs(transform.position.magnitude - theTarget.magnitude) < .5;

    }

    private void Attack()
    {
        _animator.SetBool("isMoving", false);
        
        transform.LookAt(thePlayer.transform);
        if (!isAttacking)
        {

            isAttacking = true;
        }
        else
        {
            _timeTillAttack -= Time.deltaTime;
        }
        if (_timeTillAttack <= 0)
        {
            _animator.SetBool("isAttacking", true);
            
            //play attack sounds
            //attack script
            if (shot < 1.5f)
            {
                shot += Time.deltaTime;
                if(shot>.7 && single==0)
                {
                    single++;

                    SpawnVFX();
                }
            }
            else
            {
               
                _animator.SetBool("isAttacking", false);
                _timeTillAttack = 3.0f;
                shot = 0;
                single = 0;
                isAttacking = false;
            }



        }
    }
    private void Die()
    {
        if(dead <5f)
        {
            dead += Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void SpawnVFX()
    {
        
        if(firePoint!=null)
        {
            AudioSource.PlayClipAtPoint(attack, transform.position);
            vfx = Instantiate(effectToSpawn, firePoint.transform.position, Quaternion.identity);
            vfx.transform.localRotation = transform.rotation;
        }
  
    }

}
