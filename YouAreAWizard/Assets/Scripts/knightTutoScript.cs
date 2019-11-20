using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class knightTutoScript : MonoBehaviour
{
  
    public GameObject thePlayer;
    public Transform goal;
    public GameObject toActivate;


    public GameObject firePoint;
    public GameObject vfx;
    private GameObject effectToSpawn;
    public AudioClip attack;
    private int single;

    private bool hasArrived;
    public static bool isDead;


    public static bool isAttacking;
    private float shot, dead;
    private Animator _animator;
    private float _timeTillAttack;

    private NavMeshAgent agent;
    // Use this for initialization

    protected void Start()
    {
        
        _animator = GetComponent<Animator>();

        //Find the Player GameObject using it's tag and store a reference to its transform component.
        thePlayer = GameObject.FindGameObjectWithTag("Player");
        _timeTillAttack = Random.Range(0, 3);
        effectToSpawn = vfx;

        shot = dead = single = 0;

        isDead = false;
        isAttacking = false;
        hasArrived = false;

        _animator.SetBool("isMoving", true);
        agent = GetComponent<NavMeshAgent>();
        agent.destination = goal.position;
    }


    // Update is called once per frame
    void Update()
    {

        if (!hasArrived)
        {
            if (!isDead)
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


            if (!isDead)
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
                if (shot > .7 && single == 0)
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
    
    void SpawnVFX()
    {

        if (firePoint != null)
        {
            AudioSource.PlayClipAtPoint(attack, transform.position);
            vfx = Instantiate(effectToSpawn, firePoint.transform.position, Quaternion.identity);
            vfx.transform.localRotation = transform.rotation;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag=="PlayerAttack")
        {
            toActivate.SetActive(true);
            Destroy(gameObject);
        }
    }

}
