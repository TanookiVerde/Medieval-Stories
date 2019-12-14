using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    [SerializeField]
    private Dictionary<int, string> items;
    public Dictionary<int, string> Items { get => items; set => items = value; }

    public void AddItem()
    {

    }
}
