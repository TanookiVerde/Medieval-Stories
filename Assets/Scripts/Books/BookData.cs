using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Custom/BookData")]
public class BookData : ScriptableObject
{
    public Sprite bookCover;
    public string bookName;
    public string authorName;
    public TextAsset inkFile;
}
