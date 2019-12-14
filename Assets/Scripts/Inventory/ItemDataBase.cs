using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Custom/ItemDataBase")]
public class ItemDataBase : ScriptableObject
{
    public List<ItemData> allItems;
}

