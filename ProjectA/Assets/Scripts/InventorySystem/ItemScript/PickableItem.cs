using InventorySystem;
using UnityEngine;

public class PickableItem : ItemIteractBase
{
    [SerializeField] ItemObject item;
    [SerializeField] int amount;

    public override void Interact()
    {
        inventory.AddItem(item, amount);
        Destroy(gameObject);
    }
}
