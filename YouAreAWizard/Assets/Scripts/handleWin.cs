﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class handleWin : MonoBehaviour
{
    // Start is called before the first frame update
   public void YouWon()
	{
        GameManager.instance.WonThisGame();
	}
}
