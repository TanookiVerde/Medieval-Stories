using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class SkipButton : MonoBehaviour
{
    private const float TIME_TO_SKIP = 2f;
    private const float DECREASE_TAX = 2f;

    [SerializeField] private Image skipIcon;
    [SerializeField] private TMPro.TMP_Text skipText;

    public Coroutine skipCoroutine;

    public void StartSkip()
    {
        skipCoroutine = StartCoroutine(Skip());
    }
    public void StopSkip()
    {
        StopCoroutine(skipCoroutine);
    }
    public IEnumerator Skip()
    {
        float timePressed = 0;
        while (true)
        {
            if (Input.GetMouseButton(0))
                timePressed += Time.deltaTime;
            else
                timePressed -= Time.deltaTime * DECREASE_TAX;
            timePressed = Mathf.Clamp(timePressed, 0, TIME_TO_SKIP);
            skipIcon.fillAmount = timePressed / TIME_TO_SKIP;
            if(timePressed >= TIME_TO_SKIP)
            {
                FindObjectOfType<OpeningAnimation>().Stop();
                yield break;
            }
            if (timePressed > 0)
                skipText.DOFade(1, 0.5f);
            else
                skipText.DOFade(0, 0.5f);
            yield return null;
        }
    }
}
