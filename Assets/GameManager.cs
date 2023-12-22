using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour{
    public static int currentScore;
    public static int highscore;

    public static int currentLevel = 0;
    public static int unlockedLevel;
    public Rect timerRect;
    public Color warningColorTimer;
    public Color defaultColorTimer;


    public GUISkin skin;

    public float startTime;
    private string currentTime;

    void Update()
    {
        startTime -= Time.deltaTime;
        currentTime = string.Format("{0:0.0}", startTime,);
        print (startTime <= 0);
        {
            startTime = 0;
            Application.LoadLevel(3);
        }
    }


    void start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public static void CompleteLevel()
    {
        if (currentLevel < 2)
        {
            currentLevel += 1;
            Application.LoadLevel(currentLevel);
        } else {
            print ("You Win!");
        }
    }
    void OnGUI ()
    {
        GUI.skin = skin;
        if (startTime < 5f)
        {
            skin.GetStyle("Timer").Normal.textColor = warningColorTimer;
        } else {
            skin.GetStyle("Timer").Normal.textColor = defaultColorTimer;
        }
        GUI.Label (timerRect, currentTime, skin.GetStyle ("Timer"));
    }
}

