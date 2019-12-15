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
        yield return new WaitForSeconds(0.5f);
        int itemQuantity = 3; //Temp
        for (int i = 0; i < itemQuantity; i++)
        {
            var item = Instantiate(itemPrefab, itemRoot);
            item.GetComponent<CanvasGroup>().DOFade(0, 0);
            item.GetComponent<CanvasGroup>().DOFade(1, 1f);
            yield return new WaitForSeconds(0.25f);
        }
    }
}
