using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    private void Start()
    {
        FindObjectOfType<OpeningAnimation>().Play();
    }
    public void Continue()
    {
        LoadingScreen.TransiteTo("TextAdventure");
    }
    public void NewGame()
    {
        LoadingScreen.TransiteTo("TextAdventure");
    }
    public void Preferences()
    {

    }
}
