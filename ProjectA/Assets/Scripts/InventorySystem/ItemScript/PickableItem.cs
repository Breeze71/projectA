using InventorySystem;
using UnityEngine;

public class PickableItem : ItemIteractBase
{
    [SerializeField] ItemObject item;
    [SerializeField] int amount;

    protected override void OnTriggerEnter2D(Collider2D _other)
    {
        if (_other.gameObject.GetComponent<Inventory>()!=null)
        {
            if (icon != null)
            {
                icon.SetActive(true);
            }
        }
    }
    protected override void OnTriggerExit2D(Collider2D _other)
    {
        if (_other.gameObject.GetComponent<Inventory>() != null)
        {
            if (icon != null)
            {
                icon.SetActive(false);
            }
            canInteract = false;
        }
    }
    public override void Interact()
    {
        if(InputManager.Instance.IsInteractKeyDown())
        {
            Inventory.instance.AddItem(item,amount);
            Destroy(gameObject);
        }
    }
}
