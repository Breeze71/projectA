using InventorySystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Stackable Object", menuName = "Inventory/Items/Stackable")]
public class Stackable_SO : ItemObject, IStackable
{
    [field: SerializeField] public int stackLimit { get; set; }
    public void UseItem()
    {
        //TODO　Use Supplies
        Debug.Log("使用道具");
    }
}
