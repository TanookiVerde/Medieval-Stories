﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    [SerializeField]
    private string playerInventoryName;
    public List<ItemData> playerItems;
    void Start()
    {
        //GetPlayerItems();
    }
    public void LoadPlayerItems()
    {
        string s = PlayerPrefs.GetString(playerInventoryName);
        string item = "";
        for(int i = 0; i < s.Length; i++)
        {
            if(s[i] == ',')
            {
                print(item);
                AddItem(item);
                item = "";
            }
            else
            {
                item += s[i];
            }
        }
    }
    public void SavePlayerItems()
    {
        string s = "";
        foreach(ItemData i in playerItems)
        {
            s += i.inkTag + ",";
        }
        PlayerPrefs.SetString(playerInventoryName, s);
    }
    public void DeleteAllItems()
    {
        playerItems = new List<ItemData>();
        PlayerPrefs.SetString(playerInventoryName, "");
    }
    public void AddItem(string itemName)
    {
        ItemDataBase idb = FindObjectOfType<InventoryMenu>().allItems;
        int counter = 0;
        foreach(ItemData id in idb.allItems)
        {
            if(id.inkTag == itemName)
            {
                foreach(ItemData idp in playerItems)
                {
                    if(idp.inkTag == itemName)
                        counter++;
                }
                if(counter < id.max)
                {
                    playerItems.Add(id);
                    print("Added Item: " + id.inkTag);
                    FindObjectOfType<NewItemPanel>().Show(id);
                }
                counter = 0;
            }
        }
    }
    public void RemoveItem(string itemName)
    {
        //ToDo
    }
}
