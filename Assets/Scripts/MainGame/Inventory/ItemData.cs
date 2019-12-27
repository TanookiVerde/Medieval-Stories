using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Custom/ItemData")]
public class ItemData : ScriptableObject
{
    public string inkTag;
    public string title;

    public Sprite icon;
    public string description;
    public int max;
    public ItemType itemType;

    //Se for do tipo recoveryHealth
    public int recoveryAmount;
}
public enum ItemType
{
    RECOVERY, DESCRIPTION
}
