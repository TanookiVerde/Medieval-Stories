using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Custom/LibraryData")]
public class LibraryData : ScriptableObject
{
    public List<BookData> allBooks;
}
