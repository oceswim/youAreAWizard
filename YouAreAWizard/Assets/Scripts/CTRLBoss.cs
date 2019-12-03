/*
 * Oceane Peretti - K1844498 - 3D Games programming Assignment 2
 * I confirm that this project is a product of my own and not the one of someone else.
 */
using System.Collections;
using Pathfinding;
using UnityEngine;

public class CTRLBoss : MonoBehaviour
{
    private int single,health;
    public float delay = 0;

    int index;

    IAstarAI agent;
    float switchTime = float.PositiveInfinity;
    public GameObject thePlayer;
    public Transform[] goals;
    public Transform attackSpot;
    public static bool hasArrived;
    public AudioClip aggressive, hurt, attack;
    public AudioSource walkingHorse, dyingHorse, horseHit, horseScream,fight,theme;
    private float shot;
    public GameObject firePoint,vfx,shieldWalk,youWon,winTheme;
    private GameObject effectToSpawn;

    private bool isWalking, isDead;
    public static bool playerSpotted,healthUp;
    private Animator _animator;
    private float _timeTillAttack = 2f;
    private float timer = 0;
  


    void Awake()
    {
        agent = GetComponent<IAstarAI>();
    }

    void Start()
    {
        healthUp = false;
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
                youWon.SetActive(true);
                Destroy(gameObject);
               
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
                if (healthUp)
                {
                    healthUp = false;
                    health += 1;
                }
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
                        shieldWalk.SetActive(false);
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
            fight.Pause();
            theme.Pause();
            winTheme.SetActive(true);
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
   
}
