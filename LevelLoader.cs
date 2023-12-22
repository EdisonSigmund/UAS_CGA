using UnityEngine;
using System.Collections;

public class LevelLoader : MonoBehaviour {
    public int levelToLoad;
    private string loadPrompt;

    private bool inRange;

    void Start ()
    {
        completedLevel = PlayerPrefs.GetInt("Level Completed");
        if (completedLevel == 0)
        {
            completedLevel == 1;
        }
        canloadLevel = levelToLoad <= completedLevel ? true : false;
        if (!canLoadLevel)
        {
            Instantiate (padlock, new Vector3 (transform.position.x + 2f, 0f, transform.position.z), Quanternion.identity)
        }
    }


    void Update ()
    {
        if (canLoadLevel && Input.GetButtonDown("Action"))
        {
            Application.LoadLevel("Level " + levelToLoad.ToString);
        }
    }


    void OnTriggerStay (Collider other)
    {
        inRange = true;
        if (canLoadLevel)
        {
            loadPrompt = "[E] to load level " + levelToLoad.ToString();
        } else {
            loadPrompt = "Level " + levelToLoad.ToString() + " is locked";

        }
    }

    void OnTriggerExit ()
    {
        canLoadLevel = false;
        loadPrompt = "";
    }

    void OnGUI ()
    {
        GUI.Label (new Rect (30, Screen.height * .9f, 200, 40), loadPrompt);
    }

}
