using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class ItemDescriptionMenu : MonoBehaviour
{
    public TMP_Text title;
    public TMP_Text description;

    public TMP_Text useButton;
    public CanvasGroup group;

    public void OpenItemDescription(ItemData data)
    {
        useButton.gameObject.SetActive(data.itemType == ItemType.RECOVERY);

        title.text = data.title;
        description.text = data.description;
    }
}
