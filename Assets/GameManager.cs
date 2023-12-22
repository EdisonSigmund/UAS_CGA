using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour{
    public static int currenScore;
    public static int highscore;

    public static int currentLevel;
    public static int unlockedLevel;

    void CompleteLevel()
    {
        if (currentLevel !== 2)
        {
            currentLevel += 1;
            Application.LoadLevel(currentLevel + 1);
        } else {
            print ("You Win");
        }
    
    }

}
