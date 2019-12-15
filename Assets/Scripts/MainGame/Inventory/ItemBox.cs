using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;

public class ItemBox : MonoBehaviour
{
    [SerializeField] private Image itemIcon;
    [SerializeField] private TMP_Text itemName;
    [SerializeField] private TMP_Text itemQuantity;

    private ItemData data;

    public void FadeIn()
    {
        var canvasGroup = GetComponent<CanvasGroup>();
        canvasGroup.DOFade(0, 0);
        canvasGroup.DOFade(1, 1f);
    }
    public void SetContent(ItemData data, int quantity)
    {
        this.data = data;
        itemIcon.sprite = data.icon;
        itemName.text = data.title;
        itemQuantity.text = "x" + quantity;
    }
    public ItemData GetData()
    {
        return data;
    }
}
