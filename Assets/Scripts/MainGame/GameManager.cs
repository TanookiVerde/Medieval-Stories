using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private void Start()
    {
        LoadingScreen.TransiteFrom();
        print("SELECTED_BOOK::" + PlayerPrefs.GetInt("SELECTED_BOOK",-1));
    }
}
