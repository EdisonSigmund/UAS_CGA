using System.Collections;
using UnityEngine;

public class MainMenu : MonoBehaviour{
    public GUISkin skin;

    void OnGUI ()
    {
        GUI.skin = skin;
        GUI.Label (new Rect(10,10,400,45), "Go Home");
        if (GUI.Button(new Rect(10,10,100,45), "Play");)
        {
            Application.LoadLevel(0);
        }
        if (GUI.Button(new Rect(10,120,100,45), "Quit");)
        {
            Application.Quit ();
        }    
    }

}
