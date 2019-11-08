using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Impact : MonoBehaviour
{
    private Animator _animator;
    private CTRLWizard wave;
    private CTRLpatrol patrol;
    private int health;

   

    // Start is called before the first frame update
    void Start()
	{
        wave = GetComponent<CTRLWizard>();
        patrol = GetComponent<CTRLpatrol>();
        _animator = GetComponent<Animator>();
        switch (transform.tag)
		{
			case "Lv1":
                health = 1;

                break;
			case "Lv2":

                health = 2;
             
                break;
			case "Lv3":

                health = 3;

                break;
		}
   
    }

    public void Damage(int damageAmount)
    {

        health -= damageAmount;

        if (health <= 0 )
        {
            _animator.SetTrigger("isDead");
            if (wave != null)
            {
                CTRLWizard.isDead = true;
            }
            else if(patrol!=null)
            {
                CTRLpatrol.isDead = true;
            }
        }
        else if(health>0 )
        {
            //ouch noise
            _animator.SetTrigger("isDamaged");
           
        }
    }
}
   