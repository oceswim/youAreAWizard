using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CTRLBoss : MonoBehaviour
{
	public GameObject thePlayer;
	public Transform[] goals;
    private int destPoint,single;
    public Transform theAttackSpot;
    private Vector3 attackSpot;
	public AudioClip aggressive, hurt, attack;
    public AudioSource walkingHorse;
    private float shot;
	public GameObject firePoint;
	public GameObject vfx;
    private GameObject effectToSpawn;
	private int health;
	//private GameObject effectToSpawn;
	
	private NavMeshAgent agent;
    private bool hasArrived, isWalking, isDead,isFleeing, playerSpotted;

	private Animator _animator;
    private float _timeTillAttack = 2f;

    /*
     *stand is transition
     * relax -> when sees player
     * attack with delay between
     * hit when hit
     * die when die
     * walk around to follow player 
     *
     */




	// Start is called before the first frame update
	void Start()
    {
		_animator = GetComponent<Animator>();
        _animator.SetInteger("toDo", 6);
        walkingHorse.Play();
        isWalking = true;
        agent = GetComponent<NavMeshAgent>();
        GotoNextPoint();
        effectToSpawn = vfx;
        attackSpot = theAttackSpot.position;
        hasArrived = playerSpotted=false;
        shot = single =0;

		switch (PlayerPrefs.GetInt("difficulty"))
		{
			case 1:
				health = Random.Range(4, 6);

				break;
			case 2:

				health = Random.Range(6, 8);

				break;
			case 3:

				health = Random.Range(8, 10);

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
        if (!playerSpotted)
        {
            if (!agent.pathPending && agent.remainingDistance < 0.5f)
            {
               
                GotoNextPoint();
            }
        }
        else // spots the player
        {
            if (!isFleeing)//if not dodging a spell
            {
                if (!hasArrived)//go to attack spot
                {
                    if (!isDead)
                    {
                        agent.destination = attackSpot;

                    }
                    else
                    {
                        agent.isStopped = true;
                    }
                }
                else if (hasArrived)//attacks player
                {
                    agent.isStopped = true;
                    if(!isDead)
                    {
                        Attack();
                    }

                }
                hasArrived |= Mathf.Abs(transform.position.magnitude - attackSpot.magnitude) < .5;

            }
            else
            {
               //choose a fleeing target
            }
        }
    }
    private void Attack()
    {
        _animator.SetInteger("toDo", 1);//idles
        transform.LookAt(thePlayer.transform);

        _timeTillAttack -= Time.deltaTime;
        if(_timeTillAttack<=0)
        {
            _animator.SetInteger("toDo", 3);
            if(shot<1.5f)
            {
                shot += Time.deltaTime;
                if(shot >.7 && single ==0)
                {
                    single++;
                    SpawnVFX();
                        
                }
            }
            else
            {
                _animator.SetInteger("toDo", 1);
                _timeTillAttack = 2f;
                shot = 0;
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
        if(collision.transform.tag.Equals("PlayerAttack"))
        {
            _animator.SetInteger("toDo", 4);
        }
    }
}
