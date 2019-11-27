using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;
using UnityEngine.AI;

public class CTRLBoss : MonoBehaviour
{
    private int single,health;
    /// <summary>Time in seconds to wait at each target</summary>
    public float delay = 0;

    /// <summary>Current target index</summary>
    int index;

    IAstarAI agent;
    float switchTime = float.PositiveInfinity;
    public GameObject thePlayer;
    public Transform[] goals;
    public Transform attackSpot;
    public static bool hasArrived;
    public AudioClip aggressive, hurt, attack;
    public AudioSource walkingHorse, dyingHorse, horseHit, horseScream;
    private float shot;
    public GameObject firePoint;
    public GameObject vfx;
    private GameObject effectToSpawn;

    //private GameObject effectToSpawn;

    private bool isWalking, isDead;
    public static bool playerSpotted;
    private Animator _animator;
    private float _timeTillAttack = 2f;
    private float timer = 0;
    public GameObject youWon;
    /*
     *stand is transition
     * relax -> when sees player
     * attack with delay between
     * hit when hit
     * die when die
     * walk around to follow player 
     *
     */


    void Awake()
    {
        agent = GetComponent<IAstarAI>();
    }

    // Start is called before the first frame update
    void Start()
    {
       
        _animator = GetComponent<Animator>();
        _animator.SetInteger("toDo", 6);
        walkingHorse.Play();
        isWalking = true;
        effectToSpawn = vfx;

        playerSpotted = isDead = false;
        shot = single = 0;

        switch (PlayerPrefs.GetInt("difficulty"))
        {
            case 1:
                Debug.Log("health");
                health = Random.Range(4, 6);

                break;
            case 2:
                Debug.Log("health");
                health = Random.Range(6, 8);

                break;
            case 3:
                Debug.Log("health");
                health = Random.Range(8, 10);

                break;
        }
        Debug.Log("health");
        health = 2;
        Debug.Log(health);
    }
    void GotoPoint()
    {
        bool search = false;
        if (agent.reachedEndOfPath && !agent.pathPending && float.IsPositiveInfinity(switchTime))
        {
            switchTime = Time.time + delay;
        }

        if (Time.time >= switchTime)
        {
            index = index + 1;
            search = true;
            switchTime = float.PositiveInfinity;
        }

        index %= goals.Length;
        agent.destination = goals[index].position;

        if (search) agent.SearchPath();

    }
    // Update is called once per frame
    void Update()
    {


        if (goals.Length == 0) return;

        if (isDead)
        {
            if (timer < 3)
            {
                Debug.Log("indeath");
                timer += Time.deltaTime;

            }
            else
            {
                Destroy(gameObject);
                GameManager.instance.Pause();
                youWon.SetActive(true);
            }

        }
        else
        {
            if (!playerSpotted)
            {

                GotoPoint();

            }
            else
            {
                if (isWalking)
                {
                    //horse stops and heads towards attack point
                    StartCoroutine(horseSurprised());
                    GoToAttackPoint();
                }
                else//if not dodging a spell goes to attackpoint
                {
                 
                    if (hasArrived)
                    {

                        walkingHorse.Pause();
                        if (!isDead)
                        {
                           Attack();
                           
                            
                        }
                    }
                    else if (!hasArrived)
                    {
                        if (agent.reachedEndOfPath && !agent.pathPending && float.IsPositiveInfinity(switchTime))
                        {
                            Debug.Log("arrived");
                            single = 0;
                            hasArrived = true;
                        }
                    }

                }
               

            }

        }
    }
    IEnumerator horseSurprised()
    {
        Debug.Log("heyYou!");
        walkingHorse.Pause();
        _animator.SetInteger("toDo", 2);
        horseScream.Play();
        yield return new WaitForSeconds(2);
        _animator.SetInteger("toDo", 6);
        walkingHorse.Play();
        isWalking = false;

    }
    private void Attack()
    {
        Debug.Log("attacking");
        _animator.SetInteger("toDo", 1);//idles
        transform.LookAt(thePlayer.transform);

        _timeTillAttack -= Time.deltaTime;
        if (_timeTillAttack <= 0)
        {
            _animator.SetInteger("toDo", 3);
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
                _animator.SetInteger("toDo", 1);
                _timeTillAttack = 3f;
                shot = 0;
                single = 0;
            }
        }

    }
    
    private void PauseSkull()
    {
        Debug.Log("PAUSE");
        walkingHorse.Pause();
        agent.isStopped = true;
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
    public void DamageSkull(int theDamage)
    {

        health -= theDamage;

        if (health <= 0)
        {
            PauseSkull();
            isDead = true;
            _animator.SetTrigger("isDead");
            dyingHorse.Play();
        }
        else if (health > 0)
        {
            //ouch noise
            Debug.Log("ouch");
            horseHit.Play();
            _animator.SetTrigger("isHit");

        }
    }

    void GoToAttackPoint()
    {
        bool search = false;


        if (Time.time >= switchTime)
        {
            search = true;
            switchTime = float.PositiveInfinity;
        }
        if (single == 1)
        {
            single++;
            agent.isStopped = false;
        }
        agent.destination = attackSpot.position;

        if (search) agent.SearchPath();

    }
    void goToNewTarget()
    {
        bool search = false;
        float diff1 = Mathf.Abs(goals[0].position.magnitude - transform.position.magnitude);
        int theIndex = 0;
        foreach (Transform t in goals)
        {
            float diff = Mathf.Abs(t.position.magnitude - transform.position.magnitude);
            if (diff < diff1)
            {
                theIndex++;
            }
        }

        if (agent.reachedEndOfPath && !agent.pathPending && float.IsPositiveInfinity(switchTime))
        {
            Debug.Log("i'm done fleeing");
            single = 0;
            hasArrived = true;
        }

        if (Time.time >= switchTime)
        {
            search = true;
            switchTime = float.PositiveInfinity;
        }
        if (single == 2)
        {
            single++;
            agent.isStopped = false;
        }
        agent.destination = goals[theIndex].position;
        Debug.Log("going to" + agent.destination);

        if (search) agent.SearchPath();

    }
}
