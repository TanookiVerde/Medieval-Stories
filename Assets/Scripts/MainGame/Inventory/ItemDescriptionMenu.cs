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

    public ItemData data;

    public void OpenItemDescription(ItemData data)
    {
        this.data = data;

        useButton.gameObject.SetActive(data.itemType == ItemType.RECOVERY);

        title.text = data.title;
        description.text = data.description;
    }
    public void UseItem()
    {
        FindObjectOfType<ItemManager>().RemoveItem(data.title);
        if (data.itemType == ItemType.RECOVERY)
        {
            HealthManager.RecoverHealth(data.recoveryAmount);
        }
        FindObjectOfType<InventoryMenu>().OpenInventory();
    }
}
