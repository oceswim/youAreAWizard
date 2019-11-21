using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject savedMessage;
    public static GameObject tryAgain;

    public static bool displaySave = false;
    private float timer = 2;
    private void Start()
    {
        tryAgain = GameObject.Find("Player/Canvas/Death");
        Debug.Log(tryAgain.name);
    }
    private void Update()
    {
        if(displaySave)
        {
            savedMessage.SetActive(true);
            if (timer < .5f)
            {
                savedMessage.SetActive(false);
                displaySave = false;
                timer = 2;
            }
            else
            {
                timer -= Time.deltaTime;
            }
            
        }
        if(PlayerPrefs.HasKey("checkpoint"))
        {
            SaveSystem.SavePlayer();
            PlayerPrefs.DeleteKey("checkpoint");
            
        }

        
    }
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag =="ennemySpell")
        {
            GameManager.instance.Hurt(1);
        }
    }
}
