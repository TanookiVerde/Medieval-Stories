using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class OpeningAnimation : MonoBehaviour
{
    private const float DURATION = 0.75f;
    private const float WAIT = 3f;

    [SerializeField] private TMP_Text bigText;
    [SerializeField] private TMP_Text text;

    public void Play()
    {
        var canvasGroup = GetComponent<CanvasGroup>();
        canvasGroup.DOFade(1, 0);
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
        bigText.DOFade(0, 0);
        text.DOFade(0, 0);
        StartCoroutine(Animation());
        FindObjectOfType<SkipButton>().StartSkip();
    }
    public void Stop()
    {
        var canvasGroup = GetComponent<CanvasGroup>();
        canvasGroup.DOFade(0, DURATION);
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
        StopCoroutine(Animation());
        FindObjectOfType<SkipButton>().StopSkip();
    }
    public IEnumerator Animation()
    {
        yield return new WaitForSeconds(WAIT);
        yield return BigText("Dezembro de 2019");
        yield return Text("Meu nome é Bernardo. Sou historiador e formado na University of Notinggard.");
        yield return Text("Por pelo menos dez anos eu pesquisei sobre os antigos deuses de uma antiga cultura local.");
        yield return Text("Em minha última espedição, quando subia o monte Rothjka, encontrei uma estranha ruina.");
        yield return Text("Olhei em volta e encontrei uma entrada estreita. Lá dentro identifiquei os restos de um laboratório.");
        yield return Text("Em cima da mesa, ferramentas de metal gastas e de formato estranho. Em um armário, quatro cadernos.");
        yield return Text("Todos eram espécies de diário em que o autor, Devon, escrevia histórias de sua vida.");
        yield return Text("Qual devo ler primeiro?");
        Stop();
    }
    private IEnumerator BigText(string txt)
    {
        bigText.text = txt;
        bigText.DOFade(1, DURATION);
        yield return new WaitForSeconds(DURATION + WAIT);
        bigText.DOFade(0, DURATION);
        yield return new WaitForSeconds(DURATION);
    }
    private IEnumerator Text(string txt)
    {
        float waitTime = Mathf.Clamp(WAIT * (txt.Length / 30), WAIT, 10);
        text.text = txt;
        text.DOFade(1, DURATION);
        yield return new WaitForSeconds(DURATION + waitTime);
        text.DOFade(0, DURATION);
        yield return new WaitForSeconds(DURATION);
    }
}
