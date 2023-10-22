using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public abstract class ItemIteractBase : MonoBehaviour
{
    private const string Player = "Player";

    [SerializeField] protected Collider2D coll;
    [SerializeField] protected GameObject icon;
    protected Inventory inventory;

    protected bool canInteract;

    private void Start()
    {
        coll.isTrigger = true;
    }
    private void InputManager_OnInteract_Performed(object sender, EventArgs e)
    {
        Interact();
    }
    public abstract void Interact();

    /* 玩家是否在範圍內 */
    #region OnTrigger
    private void OnTriggerEnter2D(Collider2D _other)
    {
        if (_other.gameObject.tag == Player)
        {
            inventory = _other.gameObject.GetComponent<Inventory>();
            if (inventory != null)
            {
                if (icon != null)
                {
                    icon.SetActive(true);
                }
                InputManager.Instance.OnInteract_Performed += InputManager_OnInteract_Performed;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D _other)
    {
        if (_other.gameObject.tag == Player)
        {
            if (inventory != null)
            {
                inventory = null;
            }
            if (icon != null)
            {
                icon.SetActive(false);
            }
            InputManager.Instance.OnInteract_Performed -= InputManager_OnInteract_Performed;
        }
    }
    public void Destroy()
    {
        InputManager.Instance.OnInteract_Performed -= InputManager_OnInteract_Performed;
        Destroy(gameObject);
    }
    #endregion
}
