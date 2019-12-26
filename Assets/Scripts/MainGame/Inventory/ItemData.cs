using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Custom/ItemData")]
public class ItemData : ScriptableObject
{
    public Sprite icon;
    public string title;
    public string description;
    public int max;
    public ItemType itemType;
}
public enum ItemType
{
    RECOVERY, DESCRIPTION
}
