using InventorySystem;
using UnityEngine;

public class PickableItem :InteractableBase
{
    [SerializeField] ItemObject item;
    [SerializeField] int amount;

    public override void Interact()
    {
        if(InputManager.Instance.IsInteractKeyDown())
        {
            Inventory.instance.AddItem(item,amount);
            Destroy(gameObject);
        }
    }
}
