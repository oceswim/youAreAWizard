using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class essai : MonoBehaviour
{
    public void loadascene()
    {
        GameManager.instance.loadTry();
    }
    public void loadother()
    {
        GameManager.instance.loadOther();
    }

}
