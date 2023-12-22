using System.Collections;
using UnityEngine;

public class LevelLoader : MonoBehaviour{
    public int levelToLoad;
    private string loadPrompt;

    private bool canLoadLevel;

    void OnTriggerStay(Collider other)
    {
        canLoadLevel = true;
        loadPrompt = "[E] to load level " + levelToLoad.ToString();
    }

    void OnTriggerEnter ()
    {
        canLoadLevel = false;
        loadPrompt = "";
    }


    void OnGUI()
    {
        GUI.Label (new Rect(30, Screen,height * .9f, 200, 40), loadPrompt);
    }

    void Update()
    {
        if (canLoadLevel && Input.GetButtonDown("Action"))
        {
            Application.LoadLevel("Level " + levelToLoad.ToString());
        }
    }
}
