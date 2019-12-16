using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class BookBox : MonoBehaviour
{
    [SerializeField] private LibraryData library;
    [SerializeField] private BookData data;

    [SerializeField] private Image cover;
    [SerializeField] private TMP_Text title;
    [SerializeField] private TMP_Text author;

    private void Start()
    {
        SetContent();
    }
    private void SetContent()
    {
        title.text = data.bookName;
        author.text = data.authorName;
        cover.sprite = data.bookCover;
    }
    public void OpenBook()
    {
        PlayerPrefs.SetInt("SELECTED_BOOK", library.allBooks.IndexOf(data));
        LoadingScreen.TransiteTo("TextAdventure");
    }
}
