using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class CTRLWizard : MonoBehaviour
{
   // public ParticleSystem death;


    public GameObject thePlayer;
    public Transform[] goals;
    private int destPoint;
    public AudioClip roar, moan;

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

    private int health;
    // Use this for initialization

    protected void Start()
    {
        //Register this enemy with our instance of GameManager by adding it to a list of Enemy objects. 
        //This allows the GameManager to issue movement commands.
      
        GameManager.instance.AddKnightsToList(this);

        //Get and store a reference to the attached Animator component.
        _animator = GetComponent<Animator>();

        //Find the Player GameObject using it's tag and store a reference to its transform component.
        thePlayer = GameObject.FindGameObjectWithTag("Player");



        _timeTillAttack = Random.Range(0, 3);

        effectToSpawn = vfx;

        shot = dead = single = 0;
        destPoint = Random.Range(0, goals.Length);
        Debug.Log("dest"+destPoint);
        isDead = false;
        isAttacking = false;
        hasArrived = false;

        _animator.SetBool("isMoving", true);


        agent = GetComponent<NavMeshAgent>();
        agent.destination = goals[destPoint].position;


        switch (PlayerPrefs.GetInt("difficulty"))
        {
            case 1:
                health = Random.Range(1, 3);
        
                break;
            case 2:

                health = Random.Range(2, 4);

                break;
            case 3:

                health = Random.Range(3, 5);
   
                break;
        }
      
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
                    Debug.Log("arrived");
                    hasArrived = true;
                    agent.isStopped = true;

                }

            }
            else
            {
                agent.isStopped = true;
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

    public void DamageWizard(int damageAmount)
    {

        health -= damageAmount;

        if (health <= 0)
        {
            AudioSource.PlayClipAtPoint(moan, thePlayer.transform.position, .5f);
            GameManager.instance.KillKnight(this);

        }
        else if (health > 0)
        {
            //ouch noise
            AudioSource.PlayClipAtPoint(roar, thePlayer.transform.position, .3f);
            _animator.SetTrigger("isDamaged");

        }
    }

}

