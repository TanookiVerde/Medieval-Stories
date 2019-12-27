using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ExitPanel : MonoBehaviour
{
    [SerializeField] private CanvasGroup group;

    public void Open()
    {
        group.DOFade(1, 0.5f);
        group.interactable = true;
        group.blocksRaycasts = true;
    }
    public void Close()
    {
        group.DOFade(0, 0.5f);
        group.interactable = false;
        group.blocksRaycasts = false;
    }
    public void ExitToMenu()
    {
        LoadingScreen.TransiteTo("Menu");
        PlayerPrefs.SetInt("skipMenuIntro", 1);
    }
}
