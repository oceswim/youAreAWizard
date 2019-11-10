using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class CTRLWizard : MonoBehaviour
{




    public GameObject thePlayer;
    public Transform[] goals;
    private int destPoint;


    public GameObject firePoint;
    public GameObject vfx;
    private GameObject effectToSpawn;
    public AudioClip attack;
    private int single;
    public static bool spawnAgain;
    private bool hasArrived;
    public static bool isDead;
    

    public static bool isAttacking;
    private float shot, dead;
    private Animator _animator;
    private float _timeTillAttack;

    private NavMeshAgent agent;
    // Use this for initialization
    void Start()
    {
        spawnAgain = false;

        _timeTillAttack = Random.Range(0, 3);
        thePlayer = GameObject.Find("/Player");
        effectToSpawn = vfx;
        _animator = GetComponent<Animator>();
        shot = dead = single= 0;
        destPoint = Random.Range(0, goals.Length);
        isDead = false;
        isAttacking = false;
        hasArrived = false;

        _animator.SetBool("isMoving", true);


        agent = GetComponent<NavMeshAgent>();
        agent.destination = goals[destPoint].position;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (!hasArrived)
        {
            if(isDead)
            {
                spawnAgain = true;
                Die();
            }
            else
            {

                if (!agent.pathPending && agent.remainingDistance < 0.5f)
                {
                    hasArrived = true;
                    agent.isStopped = true;
                }
            }

        }
        else if (hasArrived)
        {

           
            if(isDead)
            {
                spawnAgain = true;
                Die();
            }
            else
            {
                Attack();
            }
        }
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
