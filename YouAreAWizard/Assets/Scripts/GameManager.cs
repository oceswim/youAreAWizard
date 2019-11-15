using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;       //Allows us to use Lists. 
using UnityEngine.UI;                   //Allows us to use UI.

public class GameManager : MonoBehaviour
{
    public float levelStartDelay = 2f;                      //Time to wait before starting level, in seconds.
                                                   //public int playerFoodPoints = 100;                      //Starting value for Player food points.
    public static GameManager instance = null;              //Static instance of GameManager which allows it to be accessed by any other script.

    public bool movingOn = false;
    // private Text playerLife;                                 //Text to display current playerLife
    //public GameObject levelImage;                          //Image to block out level as levels are being set up, background for levelText.
                                                            //private int life = 1;                                  //Current life of player, expressed in game
    private List<CTRLWizard> knights;                            //List of all Enemy units, used to issue them move commands.
    private List<CTRLpatrol> wand;
    private List<spawnMob> spawns;
    private GameObject nextStep;
    public bool knightsDead;                             //Boolean to check if enemies are dead.
    public bool wandDead;
    private int knightsAdded;
    private int wandAdded;
                       //Boolean to check if we're setting up board, prevent Player from moving during setup.



    //Awake is always called before any Start functions
    void Awake()
    {

        //Check if instance already exists
        if (instance == null)

            //if not, set instance to this
            instance = this;

        //If instance already exists and it's not this:
        else if (instance != this)

            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);

        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);

        //Assign enemies to a new List of Enemy objects.
        knights = new List<CTRLWizard>();
        wand = new List<CTRLpatrol>();
        spawns = new List<spawnMob>();
      
        knightsDead = false;
        wandDead = false;
        //Get a component reference to the attached BoardManager script
        //levelImage.SetActive(false); 
        //Call the InitGame function to initialize the first level 
        InitGame();
    }

    //this is called only once, and the paramter tell it to be called only after the scene was loaded
    //(otherwise, our Scene Load callback would be called the very first load, and we don't want that)
   /* [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
    static public void CallbackInitialization()
    {
        //register the callback to be called everytime the scene is loaded
        if (changeScene.sceneload)
        {
            changeScene.sceneload = false;
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
    }

    //This is called each time a scene is loaded.
    static private void OnSceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        instance.InitGame();
    }
    */

    //Initializes the game for each level.
    public void InitGame()
    {
        //While doingSetup is true the player can't move, prevent player from moving while title card is up.
       

        //Get a reference to our image LevelImage by finding it by name.


        //Set levelImage to active blocking player's view of the game board during setup.
        /*if (levelImage != null)
        {
           
            levelImage.SetActive(true);
        }*/

        //Call the HideLevelImage function with a delay in seconds of levelStartDelay.
        // Invoke("HideLevelImage", levelStartDelay);

        //Clear any Enemy objects in our List to prepare for next level.
        nextStep = GameObject.Find("NextStep");
        nextStep.SetActive(false);
        knights.Clear();
        wand.Clear();
        spawns.Clear();
        knightsAdded = 0;
        wandAdded = 0;


    }



    //Update is called every frame.
    void Update()
    {
       
        if(spawns.Count>0)
        {
            Debug.Log("after wand is dead");
            if(knightsAdded>0)
            {
               
                if (knightsDead)
                {
                    knightsDead = false;
                   
                    int index = Random.Range(0, spawns.Count);
                    ReSpawn(index);//respawn active for corresponding spawn
                }
            }
            else if(wandAdded>0)
            {
                Debug.Log("after wand added");
                if (wandDead)
                {
                    Debug.Log("spawning after death");
                    wandDead = false;
                    int index = Random.Range(0, spawns.Count);
                    ReSpawn(index);
                }

            }
        }
        if (movingOn)//plus de knights and plus de spawns
        {
            if (knightsAdded > 0)
            {
                if (knights.Count < 1)
                {

                    movingOn = false;
                    knightsDead = false;

                    print("movingOn");

                    moveOn();


                }
            }
            else if (wandAdded > 0)
            {
                if (wand.Count < 1)
                {

                    movingOn = false;
                    wandDead = false;

                    print("movingOn");

                    moveOn();


                }
            }
        }


        }

        //Call this to add the passed in Enemy to the List of Enemy objects.
        public void AddKnightsToList(CTRLWizard script)
    {
      
        knights.Add(script);
        if(knightsAdded==0)
        {
            Debug.Log("knights added");
            knightsAdded = 1;
        }

    }
    public void AddWandToList(CTRLpatrol script1)
    {
        //Add Enemy to List enemies.

        wand.Add(script1);
        if(wandAdded==0)
        {
            wandAdded = 1;
        }
    }
    public void AddSpawnToList(spawnMob script2)
    { 
        //Add Enemy to List enemies.

        spawns.Add(script2);
      
        script2.Spawn();

    }
    public void ReSpawn(int index)
    {
     
      spawns[index].Spawn();
       
    } 
    
    //GameOver is called when the player reaches 0 food points
    public void GameOver()
    {
        //Set levelText to display number of levels passed and game over message
        //levelText.text = "After " + level + " days, you starved.";

        //Enable black background image gameObject.
        //levelImage.SetActive(true);

        //Disable this GameManager.
        enabled = false;
    }
    void moveOn()
    {
        if (nextStep != null)
        {
            Debug.Log("found next step");
            knightsAdded=0;
            wandAdded = 0;
            nextStep.SetActive(true);
        } 
        
    }
    public void KillKnight(CTRLWizard theKnight)
    {
        theKnight.Die();
        Destroy(theKnight.gameObject);

        knights.Remove(theKnight);
        knightsDead = true;
        Debug.Log("kill the knight"+ spawns.Count);
       // Debug.Log("Knight capacity" + knightsAmount);

    }
    public void KillWizard(CTRLpatrol theWizard)
    {
        theWizard.Die();
        Destroy(theWizard.gameObject);

        wand.Remove(theWizard);
        wandDead = true;
        // Debug.Log("Knight capacity" + knightsAmount);

    }
    public void removeSpawn(spawnMob theInstance)
    {
        spawns.Remove(theInstance);
        Destroy(theInstance.gameObject);
        if(spawns.Count<1)
        {
            movingOn = true;
        }
    }

}

