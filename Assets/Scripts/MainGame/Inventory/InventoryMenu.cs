using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class InventoryMenu : MonoBehaviour
{
    public ItemDataBase allItems;

    public Transform itemRoot;
    public bool opened;

    public GameObject itemPrefab;

    public RectTransform inventory;
    public RectTransform description;

    public void ToggleMenu()
    {
        if (opened)
            CloseMenu();
        else
            OpenMenu();
    }
    private void OpenMenu()
    {
        opened = true;
        OpenInventory();
        GetComponent<CanvasGroup>().DOFade(1, 0.5f);
        GetComponent<CanvasGroup>().interactable = true;
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        OnOpening();
    }
    public void CloseMenu()
    {
        opened = false;
        GetComponent<CanvasGroup>().DOFade(0, 0.5f);
        GetComponent<CanvasGroup>().interactable = false;
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }
    private void OnOpening()
    {
        Erase();
        StartCoroutine(CreateItems());
    }
    public void Erase()
    {
        for(int i = itemRoot.childCount-1; i >= 0; i--)
        {
            Destroy(itemRoot.GetChild(i).gameObject);
        }
    }
    private IEnumerator CreateItems()
    {
        var items = FindObjectOfType<ItemManager>().playerItems;
        var uniqueItems = new Dictionary<ItemData,int>();

        foreach (var i in items)
        {
            if (!uniqueItems.ContainsKey(i))
                uniqueItems.Add(i, 1);
            else
                uniqueItems[i]++;
        }
        foreach (var i in uniqueItems)
        {
            var item = Instantiate(itemPrefab, itemRoot).GetComponent<ItemBox>();
            item.SetContent(i.Key,i.Value);
            yield return new WaitForSeconds(0.25f);
        }
    }
    public void OpenInventory()
    {
        inventory.DOAnchorPosX(0, 0.25f);
        description.DOAnchorPosX(720, 0.25f);
    }
    public void OpenDescription()
    {
        inventory.DOAnchorPosX(-720, 0.25f);
        description.DOAnchorPosX(0, 0.25f);
    }
}
