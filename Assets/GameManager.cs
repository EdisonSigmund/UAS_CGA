using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    //Count
    public int currentScore;
    public int highscore;
    public int tokenCount;
    private int totalTokenCount;
    public int currentLevel = 0;
    public int unlockedLevel;
    public Rect timerRect;

    //Time variable
    public Color warningColorTimer;
    public Color defaultColorTimer;
    public float startTime;
    private string currentTime;

    //GUI Skin
    public GUISKin skin;

    //Refrences
    public GameObject tokenParent;
    
    private bool completed = false;
    private bool showWinScreen = false;
    public int winScreenWidth, winScreenHeight;

    void Update()
    {
        if(!completed)
        {
            startTime -= Time.deltaTime,
            currentTime = string.Format("(0:0.0)", startTime);
            if (startTime <= 0)
            {
                startTime = 0;
                //Application.LoadLevel("main_menu");
            }
        }
    }
    
    void Start()
    {
        totalTokenCount = tokenParent.transform.childCount;
        if (PlayerPrefs.GetInt("Level Completed") > 0)
        {
            currentLevel = PlayerPrefs.GetInt("Level Completed");
        } else {
                currentLevel = 0;
            }
    }
    
    public void CompleteLevel()
    {
        showWinScreen = true;
        completed = true;
    }

    void LoadNextLevel()
    {
        Time.timeScale = 1f;
        if (currentLevel < 2)
        {
            currentLevel += 1;
            print(currentLevel);
            SaveGame();
            Application.LoadLevel(currentLevel);
        } else {
            print("You Win");
        }
    }

    void SaveGame()
    {
        PlayerPrefs.SetInt("Level Completed", currentLevel);
        PlayerPrefs.SetInt("Level " + currentLevel.ToString() + "score", currentScore);
    }

    public void AddToken()
    {
        tokenCount += 1;
    }
    
    void OnGUI()
    {
        GUI.skin = skin;
        if (startTime < 5f)
        {
            skin.GetStyle("Timer").normal.textColor = warningColorTimer;
        } else { 
            skin.GetStyle("Timer").normal.textColor = defaultColorTimer;
            
        }
        GUI.Label (timeRect, currentTime, skin.GetStyle ("Timer"));
        GUI.Label (new Rect(45, 100, 200, 200), totalCount.ToString() + "/" , totalTokenCount.ToString());        

        if (showWinScreen)
        {
            Rect winScreenRect = new Rect(Screen.width/2 - (Screen.width *.5f/2), Screen.height/2 - (Screen.height*.5f/2), Screen.Width *.5f, Screen.Height *.5f);
            GUI.Box(winScreenRect, "ok");
            
            int gameTime = (int)startTime;
            currentScore = tokenCount * startTime;
            if(Gui.Button(new Rect (winScreenRect.x + winScreenRect.width - 170, winScreenRect.y + winScreenRect.height - 60, 150, 40), "Continue"))
            {
                LoadNextLevel();
            }
            if(Gui.Button(new Rect (winScreenRect.x + 20, winScreenRect.y + winScreenRect.height - 60, 100, 40), "Quit"))
            {
                Application.LoadNextLevel("main_menu");
                Time.timeScale = 1f;

            }

            Gui.Label(new Rect (winScreenRect.x + 20, winScreenRect.y + 40, 300, 50), currentScore.ToString() + " Score");
            Gui.Label(new Rect (winScreenRect.x + 20, winScreenRect.y + 90, 300, 50), "Completed Level " + currentScore.ToString());

        }
    }
}

