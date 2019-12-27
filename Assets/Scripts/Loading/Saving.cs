using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Saving : MonoBehaviour
{
    public CanvasGroup group;
    
    public void Open()
    {
        group.DOFade(1, 0.25f);
        group.blocksRaycasts = true;
    }
    public void Close()
    {
        group.DOFade(0, 0.25f);
        group.blocksRaycasts = false;
    }
}
