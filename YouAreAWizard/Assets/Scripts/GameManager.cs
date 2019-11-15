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


    // private Text playerLife;                                 //Text to display current playerLife
    public GameObject levelImage;                          //Image to block out level as levels are being set up, background for levelText.
                                                            //private int life = 1;                                  //Current life of player, expressed in game
    private List<CTRLWizard> knights;                            //List of all Enemy units, used to issue them move commands.
    private List<CTRLpatrol> wand;
    private List<spawnMob> spawns;
    private GameObject nextStep;
    private GameObject jails;
    public static int spawnAmount;
    private int spawnCapa;
    public static int knightsAmount;
    private int knightsCapa;
    public static int patrolAmount;
    private int patrolCapa;
    private bool enemiesDead;                             //Boolean to check if enemies are dead.
    private int whichSpawn;
    private bool doingSetup = true;                         //Boolean to check if we're setting up board, prevent Player from moving during setup.



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
        jails = GameObject.Find("Jails");
        nextStep = GameObject.Find("nextStep");
        if (jails != null)
        {
            jails.SetActive(false);
        }
        if (nextStep != null)
        {
            nextStep.SetActive(false);
        }
        knights = new List<CTRLWizard>();
        wand = new List<CTRLpatrol>();
        spawns = new List<spawnMob>();
        Debug.Log("FIRST" + spawns.Capacity);
        enemiesDead = false;
        //Get a component reference to the attached BoardManager script

        //Call the InitGame function to initialize the first level 
        InitGame();
    }

    //this is called only once, and the paramter tell it to be called only after the scene was loaded
    //(otherwise, our Scene Load callback would be called the very first load, and we don't want that)
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
    static public void CallbackInitialization()
    {
        //register the callback to be called everytime the scene is loaded
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    //This is called each time a scene is loaded.
    static private void OnSceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        instance.InitGame();
    }


    //Initializes the game for each level.
    void InitGame()
    {
        //While doingSetup is true the player can't move, prevent player from moving while title card is up.
        doingSetup = true;

        //Get a reference to our image LevelImage by finding it by name.
        //levelImage = GameObject.Find("Canvas/LevelImage");

        //Set levelImage to active blocking player's view of the game board during setup.
        levelImage.SetActive(true);

        //Call the HideLevelImage function with a delay in seconds of levelStartDelay.
        Invoke("HideLevelImage", levelStartDelay);

        //Clear any Enemy objects in our List to prepare for next level.
        knights.Clear();
        wand.Clear();
        spawns.Clear();
        knightsAmount = spawnAmount = patrolAmount = 0;

    }


    //Hides black image used between levels
    void HideLevelImage()
    {
        //Disable the levelImage gameObject.
        levelImage.SetActive(false);

        //Set doingSetup to false allowing player to move again.
        doingSetup = false;
    }

    //Update is called every frame.
    void Update()
    {
        //Check that doingSetup is not currently true.
        if (doingSetup)

            //If any of these are true, return and do not start MoveEnemies.
            return;

        if(spawns.Count<1)//plus de knights and plus de spawns
        {
            if (knights.Count < 1)
            {
                print("movingOn");
                moveOn();
            }
            
        }
        if(spawns.Count>0)
        {
            if(enemiesDead)
            {
               int index = Random.Range(0,spawns.Count);
               ReSpawn(index);//respawn active for corresponding spawn
            }
        }
        

    }

    //Call this to add the passed in Enemy to the List of Enemy objects.
    public void AddKnightsToList(CTRLWizard script)
    {
        //Add Enemy to List enemies.
        knights.Add(script);
        knightsAmount++;
    }
    public void AddWandToList(CTRLpatrol script1)
    {
        //Add Enemy to List enemies.
        patrolAmount++;
        wand.Add(script1);
    }
    public void AddSpawnToList(spawnMob script2)
    { 
        //Add Enemy to List enemies.

        spawns.Add(script2);
        spawnAmount++;
        Debug.Log("spawnAdded with index"+ spawns.IndexOf(script2));
        Debug.Log("count"+spawns.Count);
        script2.Spawn();
    }
    public void ReSpawn(int index)
    {
     
      spawns[index].Spawn();
        
        
    }
 
    /*public void Refresh()
    {
        if (knights.Capacity > 0)
        {
            knights.Clear();
        }
        if (wand.Capacity > 0)
        {
            wand.Clear();
        }
        if(spawns.Capacity>0)
        {
            spawns.Clear();
        }
    }*/
    //GameOver is called when the player reaches 0 food points
    public void GameOver()
    {
        //Set levelText to display number of levels passed and game over message
        //levelText.text = "After " + level + " days, you starved.";

        //Enable black background image gameObject.
        levelImage.SetActive(true);

        //Disable this GameManager.
        enabled = false;
    }
    void moveOn()
    {
        if (jails != null)
        {
            jails.SetActive(true);
        }
        if (nextStep != null)
        {
            nextStep.SetActive(true);
        }
        print("OK");
    }
    public void KillKnight(CTRLWizard theKnight)
    {
        theKnight.Die();
        Destroy(theKnight.gameObject);
        knightsAmount--;
        knights.Remove(theKnight);
        enemiesDead = true;
       // Debug.Log("Knight capacity" + knightsAmount);

    }
    public void removeSpawn(spawnMob theInstance)
    {
        spawnAmount--;
        spawns.Remove(theInstance);
        Debug.Log("new spawnCapacity" + spawns.Count);
        
    }

}

