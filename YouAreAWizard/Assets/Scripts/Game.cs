/*
 * Oceane Peretti - K1844498 - 3D Games programming Assignment 2
 * I confirm that this project is a product of my own and not the one of someone else.
 */
[System.Serializable]
public class Game 
{
    public static Game current;
    public PlayerData thePlayer;
    public Game()
    {
        thePlayer = new PlayerData();
    }

}
