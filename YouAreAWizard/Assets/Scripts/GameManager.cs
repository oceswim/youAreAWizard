﻿/*
 * Oceane Peretti - K1844498 - 3D Games programming Assignment 2
 * I confirm that this project is a product of my own and not the one of someone else.
 */
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;       //Allows us to use Lists. 
using UnityEngine.UI;                   //Allows us to use UI.

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;              //Static instance of GameManager which allows it to be accessed by any other script.

    public bool movingOn = false;
                                                          
                                
    private List<CTRLWizard> knights;                            //List of all Enemy units, used to issue them move commands.
    private List<CTRLpatrol> wand;
    private List<spawnMob> spawns;
    private GameObject nextStep;
    public bool knightsDead;                             //Boolean to check if enemies are dead.
    public bool wandDead;
    private int knightsAdded;
    private int wandAdded;
    public static bool sceneLoad;

    public bool GameIsPaused = false;
    public static int theMenu = 0;
    public static int theScene;
    private int count = 0;

    private float tempo = 0;
    public int playerHealth;
    
    //Awake is always called before any Start functions
    void Awake()
    {
        
        if (Game.current==null)
        {
            PlayerPrefs.DeleteAll();
            Debug.Log("new game");
            Game.current = new Game();
            playerHealth = Game.current.thePlayer.health;
            PlayerPrefs.SetInt("firstLoad", 1);//allows to create a new game only at the very first load
        }
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
        sceneLoad = false;
        //Get a component reference to the attached BoardManager script
        //levelImage.SetActive(false); 
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
    public void InitGame()
    {
        //Clear any Enemy objects in our List to prepare for next level.
        nextStep = GameObject.Find("NextStep");
        if (nextStep != null)
        {
            nextStep.SetActive(false);
        }
        spawns.Clear();
        if (knightsAdded > 0)
        {
            knights.Clear();
            knightsAdded = 0;
        }
        else if (wandAdded > 0)
        {

            wand.Clear();
            wandAdded = 0;
        }

    }



    //Update is called every frame.
    void Update()
    {
        if (sceneLoad)
        {
            count = 0;
            sceneLoad = false;
            InitGame();
        }
        if (spawns.Count > 0)
        {
            if (knightsAdded > 0)
            {

                if (knightsDead)
                {
                    knightsDead = false;

                    int index = Random.Range(0, spawns.Count);
                    ReSpawn(index);//respawn active for corresponding spawn
                }
            }
            else if (wandAdded > 0)
            {

                if (wandDead)
                {

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
                    moveOn();


                }
            }
            else if (wandAdded > 0)
            {
                if (wand.Count < 1)
                {

                    movingOn = false;
                    wandDead = false;
                    moveOn();


                }
            }
        }
        
     
        switch (SceneManager.GetActiveScene().name)
        {
            case "TutoLevel":
                if (count == 0)
                {
                    count = 1;
                    Game.current.thePlayer.level = 1;

                }
                break;
            case "WaveLevel":
                if (count == 0)
                {
                    count = 1;
                    PlayerPrefs.SetInt("checkpoint", 1);
                }
                break;
            case "AttackLevel":
                if (count == 0)
                {
                    
                    count = 1;
                    PlayerPrefs.SetInt("checkpoint", 1);
                }
                break;
            case "BossLevel":
                if (count == 0)
                {
                    count = 1;
                    PlayerPrefs.SetInt("checkpoint", 1);
                }
                break;
        }
        if (SaveSystem.isSaving == 1)
        {
            SaveSystem.isSaving = 0;
            Player.displaySave = true;
        }
        if (Game.current.thePlayer.health < 1)
        {
            Pause();
            ResetHealth();
            Player.tryAgain.SetActive(true);
            Player.DeathTheme();
            //stop game and ask if want to quit or go back to latest saved place;
        }
    }

    public void Resume()
    {
        GameIsPaused = false;
        Time.timeScale = 1f;
    }
    public void Pause()
    {
        GameIsPaused = true;
        Time.timeScale = 0f;

    }
    //Call this to add the passed in Enemy to the List of Enemy objects.
    public void AddKnightsToList(CTRLWizard script)
    {

        knights.Add(script);
        if (knightsAdded == 0)
        {
            knightsAdded = 1;
        }

    }
    public void AddWandToList(CTRLpatrol script1)
    {
        //Add Enemy to List enemies.

        wand.Add(script1);
        if (wandAdded == 0)
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
    void moveOn()
    {
        if (nextStep != null)
        {
            knightsAdded = 0;
            wandAdded = 0;
            nextStep.SetActive(true);
        }

    }
    public void KillKnight(CTRLWizard theKnight)
    {
        theKnight.isDead = true;
        StartCoroutine(Die(theKnight));
        knights.Remove(theKnight);
        knightsDead = true;

    }
    public void KillWizard(CTRLpatrol theWizard)
    {
        theWizard.isDead = true;
        StartCoroutine(DieWizard(theWizard));
        wand.Remove(theWizard);
        wandDead = true;
        // Debug.Log("Knight capacity" + knightsAmount);

    }
     IEnumerator Die(CTRLWizard theKilledKnight)
    {
        theKilledKnight.Die();
        yield return new WaitForSeconds(5);
        Destroy(theKilledKnight.gameObject);
    }
    IEnumerator DieWizard(CTRLpatrol theKilledWizard)
    {
        theKilledWizard.Die();
        yield return new WaitForSeconds(5);
        Destroy(theKilledWizard.gameObject);
    }
    public void RemoveSpawn(spawnMob theInstance)
    {
        spawns.Remove(theInstance);
        Destroy(theInstance.gameObject);
        if (spawns.Count < 1)
        {
            movingOn = true;
        }
    }
    public void AttackLevel()
    {
        
        sceneLoad = true;
     
        Game.current.thePlayer.level = 3;
        PlayerPrefs.SetString("changeScene", "AttackLevel");

    }
    public void TutoLevel()
    {
        sceneLoad = true;
        PlayerPrefs.SetInt("CurrentLevel", 1);
        PlayerPrefs.SetString("changeScene", "tutoLevel");
        

    }
    public void WaveLevel()
    {
        sceneLoad = true;
        Game.current.thePlayer.level = 2;
        PlayerPrefs.SetString("changeScene", "WaveLevel");
    }
    public void BossLevel()
    {
        sceneLoad = true;
        Game.current.thePlayer.level = 4;
        PlayerPrefs.SetString("changeScene", "BossLevel");
     

    }
    public void MainMenu()
    {
        sceneLoad = true;
        PlayerPrefs.SetString("changeScene", "MainMenu");
    }
    public void QuitGame()
    {
        //if click on settings
        Application.Quit();
    }
    public void FirstLoad()
    {
       
        theMenu = 1;//first game launch go to tutorial
    
        PlayerPrefs.SetInt("difficulty", 1);
        
    }
    public void Continue()
    {
        SaveSystem.LoadPlayer();
        //playerHealth = Game.current.thePlayer.health;
        switch(Game.current.thePlayer.level)
        {
            case 2:
                WaveLevel();
                break;
            case 3:
                AttackLevel();
                break;
            case 4:
                BossLevel();
                break;
        }
        //once player loaded, load the scene corresponding to latest save
    }
    public void ResetHealth()
    {
        playerHealth = 10;
        Game.current.thePlayer.health = 10;
    }
    public void TryAgain()
    {
       
        switch (Game.current.thePlayer.level)
        {
            case 2:
                WaveLevel();
                break;
            case 3:
                AttackLevel();
                break;
            case 4:
                BossLevel();
                break;
        }
        
       
    }
    public void NewGame()
    {

        Game.current = new Game();
        ResetHealth();
        WaveLevel();
    }
    public void WonThisGame()
    {
        theMenu = 2;
        MainMenu();
    }
    public void setMenu(int index)
    {
        theMenu = index;
    }

}

