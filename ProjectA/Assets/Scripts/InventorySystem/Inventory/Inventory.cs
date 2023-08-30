

using InventorySystem;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Inventory :MonoBehaviour
{
    public static Inventory instance;

    public event EventHandler OnItemListChanged;//之後用於UI程式碼訂閱 隨物品列變化更新UI
    private List<InventorySlot> itemList = new List<InventorySlot>();

    private void Awake()
    {
        instance = this;
    }

    public List<InventorySlot> GetItemList()
    {
        return itemList;
    }
    public void AddItem(ItemObject item,int amount)
    {
        if (item is IStackable)
        {
            AddStackableItem((IStackable)item, amount);
        }
        else
        {
            AddIndependentItem(item, amount);
        }
        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }

    private void AddStackableItem(IStackable item,int amount)
    {
        bool itemAlreadyExist = false;
        int AddItemAmount = amount;
        foreach (InventorySlot InventoryItem in itemList)
        {
            if (!(InventoryItem is IStackable))
            {
                continue;
            }
            if ((ItemObject)item == InventoryItem.item)
            {
                if (item.stackLimit !=0)
                {
                    if (InventoryItem.amount + AddItemAmount > item.stackLimit)
                    {
                        InventoryItem.amount = item.stackLimit;
                        AddItemAmount = InventoryItem.amount + AddItemAmount - item.stackLimit;
                    }
                    else
                    {
                        InventoryItem.amount += AddItemAmount;
                        itemAlreadyExist = true;
                        break;
                    }
                }
                else
                {
                    InventoryItem.amount += AddItemAmount;
                    itemAlreadyExist = true;
                    break;
                }
            }
        }
        if (!itemAlreadyExist)
        {
            itemList.Add(new InventorySlot((ItemObject)item, AddItemAmount));
        }
    }

    private void AddIndependentItem(ItemObject item,int amount)
    {
        for (int i = 0; i<amount;i++)
        {
            itemList.Add(new InventorySlot(item, amount));
        }
    }

    public void SubItem(ItemObject item)
    {
        //TODO discard item
    }
}

public class InventorySlot
{
    public ItemObject item;
    public int amount;
    public InventorySlot(ItemObject item, int amount)
    {
        this.item = item;
        this.amount = amount;
    }
    public void AddAmount(int value)
    {
        amount += value;
    }
}
