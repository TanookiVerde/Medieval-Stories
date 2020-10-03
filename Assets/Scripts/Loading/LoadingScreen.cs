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

    [Header("Feather Animation")]
    [SerializeField] private GameObject featherIcon;
    [SerializeField] private float featherXInit;
    [SerializeField] private float featherXMax;
    [SerializeField] private float featherVelocity;

    [SerializeField] private float featherRotInit;
    [SerializeField] private float featherRotMax;
    [SerializeField] private float featherRotationVelocity;

    private Coroutine animation;

    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    public static void TransiteTo(string sceneName)
    {
        LoadingScreen me = FindObjectOfType<LoadingScreen>();
        if (me != null)
        {
            me.StartCoroutine(me.FadeIn(sceneName));
            me.animation = me.StartCoroutine(me.ILoadingAnimation());
        }
    }
    public static void TransiteFrom()
    {
        LoadingScreen me = FindObjectOfType<LoadingScreen>();
        if (me != null)
        {
            me.StartCoroutine(me.FadeOut());
            if(me.animation != null)
                me.StopCoroutine(me.animation);
        }
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
    private IEnumerator ILoadingAnimation()
    {
        int horizontalBias = 1;
        int rotationBias = 1;
        RectTransform rectTransform = featherIcon.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = new Vector2(featherXInit, rectTransform.anchoredPosition.y);
        while (true)
        {
            // Movimento Horizontal
            rectTransform.anchoredPosition += Vector2.right * horizontalBias * featherVelocity * Time.deltaTime;
            if (rectTransform.anchoredPosition.x >= featherXMax || 
                rectTransform.anchoredPosition.x <= featherXInit)
                horizontalBias *= -1;

            // Rotação
            rectTransform.Rotate(Vector3.forward * rotationBias * featherRotationVelocity * Time.deltaTime);
            if (rectTransform.rotation.eulerAngles.z <= featherRotMax ||
                rectTransform.rotation.eulerAngles.z >= featherRotInit)
                rotationBias *= -1;
            yield return null;
        }
    }
}
