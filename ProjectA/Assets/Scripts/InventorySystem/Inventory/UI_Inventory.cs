using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Inventory : MonoBehaviour
{
    [SerializeField] private Transform Container;
    [SerializeField] private Transform Template;

    private void Awake()
    {
        Inventory.instance.OnItemListChanged += Inventory_OnItemListChanged;
    }
    private void Inventory_OnItemListChanged(object sender,System.EventArgs e)
    {
        RefreshUI();
    }

    public void RefreshUI()
    {
        foreach(Transform child in Container)
        {
            if (child == Template)
            {
                continue;
            }
            Destroy(child.gameObject);
        }
        List<InventorySlot> itemlist =Inventory.instance.GetItemList();
        foreach (InventorySlot itemslot in itemlist)
        {
            Transform obj = Instantiate(Template,Container);
            Image itemIcon = obj.transform.Find("ItemIcon").GetComponent<UnityEngine.UI.Image>();
            TextMeshProUGUI itemAmount = obj.transform.Find("ItemAmount").GetComponent<TextMeshProUGUI>();

            itemIcon.sprite = itemslot.item.sprite;
            itemAmount.text = itemslot.amount.ToString();
        }
    }
}
