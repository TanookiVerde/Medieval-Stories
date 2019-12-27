using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.UI;

public class NewItemPanel : MonoBehaviour
{
    private const float DURATION = 0.5f;
    private const float SHOW_POS = -65f;
    private const float HIDE_POS = 65f;

    [SerializeField] private TMP_Text title;

    public void Show(ItemData data)
    {
        StartCoroutine(ShowAnimation(data));
    }
    private IEnumerator ShowAnimation(ItemData data)
    {
        var rect = GetComponent<RectTransform>();
        title.text = data.title;
        rect.DOAnchorPosY(SHOW_POS, DURATION);
        yield return new WaitForSeconds(DURATION * 3f);
        rect.DOAnchorPosY(HIDE_POS, DURATION);
    }
}
