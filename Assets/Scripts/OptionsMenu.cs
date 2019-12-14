using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class OptionsMenu : MonoBehaviour
{
    public void OpenMenu()
    {
        var canvasGroup = GetComponent<CanvasGroup>();
        canvasGroup.DOFade(1, 0.25f);
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
    }
    public void CloseMenu()
    {
        var canvasGroup = GetComponent<CanvasGroup>();
        canvasGroup.DOFade(0, 0.25f);
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
    }
}
