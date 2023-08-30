using InventorySystem;
using UnityEngine;

public class PickableItem :InteractableBase
{
    [SerializeField] ItemObject item;
    [SerializeField] int amount;
    public override void Interact()
    {
        Inventory.instance.AddItem(item,amount);
        Destroy(gameObject);
    }
}
