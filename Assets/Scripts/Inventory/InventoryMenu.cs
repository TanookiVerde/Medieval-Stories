using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class InventoryMenu : MonoBehaviour
{
    private const float OPENED_HEIGHT = 300;
    private const float CLOSED_HEIGHT = -150;

    public ItemDataBase allItems;

    public RectTransform rect;
    public Transform itemRoot;
    public bool opened;

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
        rect.DOAnchorPosY(OPENED_HEIGHT, 0.25f);
        OnOpening();
    }
    private void CloseMenu()
    {
        opened = false;
        rect.DOAnchorPosY(CLOSED_HEIGHT, 0.25f);
    }
    private void OnOpening()
    {
        //Listar Itens -> ToDo
    }
}
