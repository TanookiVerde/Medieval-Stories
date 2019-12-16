using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class BookMenu : MonoBehaviour
{
    private const float DURATION = 0.5f;

    public CanvasGroup blackBackground;

    private BookBox lastBookBox;
    private Vector3 lastRotation;
    private Vector2 lastAnchoredPosition;
    private Vector2 lastSizeDelta;

    public void SelectBook(BookBox box)
    {
        lastBookBox = box;
        blackBackground.DOFade(1, DURATION);
        blackBackground.blocksRaycasts = true;
        blackBackground.interactable = true;

        var rect = box.GetComponent<RectTransform>();

        lastRotation = rect.rotation.eulerAngles;
        rect.DORotate(Vector3.zero, DURATION);

        lastSizeDelta = rect.sizeDelta;
        rect.DOSizeDelta(Vector2.zero, DURATION);

        lastAnchoredPosition = rect.anchoredPosition;
        rect.DOAnchorPos(Vector2.zero + Vector2.up*110, DURATION);

        blackBackground.transform.SetAsLastSibling();
        rect.SetAsLastSibling();
    }
    public void CloseBook()
    {
        blackBackground.DOFade(0, DURATION);
        blackBackground.blocksRaycasts = false;
        blackBackground.interactable = false;

        lastBookBox.GetComponent<RectTransform>().DORotate(lastRotation, DURATION);
        lastBookBox.GetComponent<RectTransform>().DOSizeDelta(lastSizeDelta, DURATION);
        lastBookBox.GetComponent<RectTransform>().DOAnchorPos(lastAnchoredPosition, DURATION);
        lastBookBox.CloseBook();
    }
}
