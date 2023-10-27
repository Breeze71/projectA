using InventorySystem;
using UnityEngine;

public class PickableItem : ItemIteractBase
{
    [SerializeField] ItemObject item;
    [SerializeField] int quantity;

    public override void Interact()
    {
        inventory.AddItem(item, quantity);
        Destroy(gameObject);
    }
}
