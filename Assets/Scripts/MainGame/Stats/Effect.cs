using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class Effect : MonoBehaviour
{
    private const float EFFECT_DURATION = 0.75f;

    [SerializeField] private float layer1InitialY;
    [SerializeField] private float layer1FinalY;

    [SerializeField] private float layer2InitialY;
    [SerializeField] private float layer2FinalY;

    public CanvasGroup group;
    public RectTransform layer1;
    public RectTransform layer2;

    public void BeginEffect()
    {
        StartCoroutine(EffectAnimation());
    }
    private IEnumerator EffectAnimation()
    {
        group.DOFade(0, 0);
        group.DOFade(1, EFFECT_DURATION/2);

        layer1.DOAnchorPosY(layer1InitialY, 0);
        layer2.DOAnchorPosY(layer2InitialY, 0);

        layer1.DOAnchorPosY(layer1FinalY, EFFECT_DURATION / 2);
        layer2.DOAnchorPosY(layer2FinalY, EFFECT_DURATION / 2);

        yield return new WaitForSeconds(EFFECT_DURATION / 4);

        group.DOFade(0, EFFECT_DURATION/2);
    }
}
