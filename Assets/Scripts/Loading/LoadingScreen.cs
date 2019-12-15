using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScreen : MonoBehaviour
{
    [SerializeField] private CanvasGroup canvasGroup;

    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    public static void TransiteTo(string sceneName)
    {
        LoadingScreen me = FindObjectOfType<LoadingScreen>();
        if(me != null) 
            me.StartCoroutine(me.FadeIn(sceneName));
    }
    public static void TransiteFrom()
    {
        LoadingScreen me = FindObjectOfType<LoadingScreen>();
        if (me != null) 
            me.StartCoroutine(me.FadeOut());
    }
    public IEnumerator FadeIn(string sceneName)
    {
        canvasGroup.DOFade(1, 0.5f);
        canvasGroup.blocksRaycasts = true;
        yield return new WaitForSeconds(2f);
        SceneManager.LoadSceneAsync(sceneName);
    }
    public IEnumerator FadeOut()
    {
        canvasGroup.DOFade(0, 0.5f);
        canvasGroup.blocksRaycasts = false;
        yield return null;
    }
}
