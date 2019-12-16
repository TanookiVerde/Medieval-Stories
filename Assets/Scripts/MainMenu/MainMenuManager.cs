using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MainMenuManager : MonoBehaviour
{
    private const float MOVE_DURATION = 1f;
    private const float MAIN_ZOOM = 208f;
    private const float BOOK_ZOOM = 235f;

    public Transform mainMenu;
    public Transform bookMenu;

    private void Start()
    {
        FindObjectOfType<OpeningAnimation>().Play();
        Camera.main.transform.DOMove(mainMenu.position, 0);
        Camera.main.DOOrthoSize(MAIN_ZOOM, 0);
    }
    public void Continue()
    {
        Camera.main.transform.DOMove(bookMenu.position, MOVE_DURATION);
        Camera.main.DOOrthoSize(BOOK_ZOOM, MOVE_DURATION);
    }
    public void Preferences()
    {

    }
    public void BackToMenu()
    {
        Camera.main.transform.DOMove(mainMenu.position, MOVE_DURATION);
        Camera.main.DOOrthoSize(MAIN_ZOOM, MOVE_DURATION);
    }
}
