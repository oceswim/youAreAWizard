using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class CTRLpatrol : MonoBehaviour
{


    public GameObject thePlayer;
    public Transform[] goals;
    private int currentGoal;
    private int destPoint;
    private NavMeshAgent agent;
    public Transform target;


    private Vector3 theTarget;
    public GameObject firePoint;
    public GameObject vfx;
    private GameObject effectToSpawn;

    private bool hasArrived;
    public static bool isDead;
    public static bool isDefending;
    public AudioClip attack;
    private int single;

    public ParticleSystem death;

    private bool isAttacking;
    private float shot, dead;
    private Animator _animator;
    private float _timeTillAttack = 3f;
    // Use this for initialization
    void Start()
    {
        thePlayer = GameObject.Find("Player(Clone)");
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
                    //_animator.SetBool("isMoving", false);
                    Die();
                }
                else
                {
                    Debug.Log("moving");
                    _animator.SetBool("isMoving", true);
                    agent.destination = theTarget;

                }

            }
            else if (hasArrived)
            {
                agent.isStopped = true;
                if (isDead)
                {

                    Die();
                }
                else
                {
                    Debug.Log("attacking");
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
                isAttacking = false;
            }



        }
    }
    private void Die()
    {
        if (dead < 5f)
        {
            dead += Time.deltaTime;
        }
        else
        {
            death.Play();
            Destroy(gameObject);
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

}
