/*
 * Oceane Peretti - K1844498 - 3D Games programming Assignment 2
 * I confirm that this project is a product of my own and not the one of someone else.
 */
using UnityEngine;
using UnityEngine.AI;

public class CTRLpatrol : MonoBehaviour
{


    public GameObject thePlayer;
    public Transform[] goals;
    private int currentGoal;
    private int destPoint;
    private NavMeshAgent agent;
    public Transform target;

    public AudioClip roar, moan;

    private Vector3 theTarget;
    public GameObject firePoint;
    public GameObject vfx;
    private GameObject effectToSpawn;

    private bool hasArrived;
    public bool isDead;
    public static bool isDefending;
    public AudioClip attack;
    private int single;

    public ParticleSystem death;

    private bool isAttacking;
    private float shot, dead;
    private Animator _animator;
    private float _timeTillAttack = 2f;
    private int health;

    protected void Start()
    {
        GameManager.instance.AddWandToList(this);
        thePlayer = GameObject.Find("Player");
        effectToSpawn = vfx;
        isDefending = false;
        _animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = false;
        GotoNextPoint();
        shot = dead = single = 0;
        isDead = false;
        isAttacking = false;
        hasArrived = false;

        theTarget = target.position;

        switch (PlayerPrefs.GetInt("difficulty"))
        {
            case 1:
                health = Random.Range(1,2);

                break;
            case 2:

                health = Random.Range(2, 3);

                break;
            case 3:

                health = Random.Range(3, 4);

                break;
        }




    }
    void GotoNextPoint()
    {

        // Returns if no points have been set up
        if (goals.Length == 0)
            return;

        // Set the agent to go to the currently selected destination.
        agent.destination = goals[destPoint].position;

        // Choose the next point in the array as the destination,
        // cycling to the start if necessary.
        destPoint = (destPoint + 1) % goals.Length;
    }

    // Update is called once per frame
    void Update()
    {

        // Choose the next destination point when the agent gets
        // close to the current one.
        if (!isDefending)
        {
            if (!agent.pathPending && agent.remainingDistance < .5f)
            {
                GotoNextPoint();
            }
        }
        else
        {

            if (!hasArrived)
            {

                if (isDead)
                {
                    agent.isStopped = true;
                   
                }
                else
                {
             
                    _animator.SetBool("isMoving", true);
                    agent.destination = theTarget;

                }

            }
            else if (hasArrived)
            {
                agent.isStopped = true;
                if (!isDead)
                {
               
                   
                    Attack();
                }
              
                
            }
            hasArrived |= Mathf.Abs(transform.position.magnitude - theTarget.magnitude) < .5;

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
    public void DamagePatrol(int damageAmount)
    {
        health -= damageAmount;

        if (health <= 0)
        {
            
            GameManager.instance.KillWizard(this);
        }
        else if (health > 0)
        {
            AudioSource.PlayClipAtPoint(roar, thePlayer.transform.position, .3f);
            _animator.SetTrigger("isDamaged");

        }
    }
    public void Die()
    {
        _animator.SetTrigger("isDead");
        AudioSource.PlayClipAtPoint(moan, thePlayer.transform.position, .5f);
    }

}
