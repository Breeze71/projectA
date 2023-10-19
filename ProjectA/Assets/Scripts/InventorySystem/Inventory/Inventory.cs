

using InventorySystem;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Inventory :MonoBehaviour
{
    public event EventHandler OnItemListChanged;//����Ω�UI�{���X�q�\ �H���~�C�ܤƧ�sUI
    private List<InventorySlot> itemList = new List<InventorySlot>();

    public List<InventorySlot> GetItemList()
    {
        return itemList;
    }
    public void AddItem(ItemObject item,int amount)
    {
        if (item is IStackable)
        {
            //Debug.Log("���|�D��");
            AddStackableItem((IStackable)item, amount);
        }
        else
        {
            //Debug.Log("�W�[�D��");
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
            if (!(InventoryItem.item is IStackable))
            {
                continue;
            }
            if (item.GetType() == InventoryItem.item.GetType())
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
                        InventoryItem.AddAmount(AddItemAmount);
                        itemAlreadyExist = true;
                        break;
                    }
                }
                else
                {
                    InventoryItem.AddAmount(AddItemAmount);
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
