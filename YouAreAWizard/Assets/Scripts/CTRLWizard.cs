using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class CTRLWizard : MonoBehaviour
{


    private float rotationSpeed = 6;
    public GameObject thePlayer;
    public Transform[] goals;

    public GameObject firePoint;
    public GameObject vfx;
    private GameObject effectToSpawn;
    public AudioClip attack;
    private int single;
    private NavMeshAgent agent;
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
        agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = false;
        agent.destination = goals[wichGoal()].position;
        _animator.SetBool("isMoving", true);

    }
    private int wichGoal()
    {
        int index = Random.Range(0, goals.Length);
        return index;
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

       if(!agent.pathPending && agent.remainingDistance < .5f)
        {
            agent.isStopped = true;
            hasArrived = true;
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
