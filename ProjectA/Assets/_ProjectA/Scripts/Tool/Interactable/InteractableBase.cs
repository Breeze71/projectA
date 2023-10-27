using System;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public abstract class InteractableBase : MonoBehaviour
{
    private const string Player = "Player";

    [SerializeField] protected Collider2D coll;
    [SerializeField] protected GameObject icon;

    private bool canInteract;
    protected bool hasInteracted = false; // 避免重複對話

    protected virtual void Update() 
    {
        if(!canInteract)    return;

        Interact();
    }

    public abstract void Interact();
    public virtual void ExitTrigger() { }

    protected virtual void OnTriggerEnter2D(Collider2D _other)
    {
        if(_other.gameObject.tag == Player)
        {
            icon.SetActive(true);

            canInteract = true;
        }
    }
    protected virtual void OnTriggerExit2D(Collider2D _other) 
    {
        if(_other.gameObject.tag == Player)
        {
            icon.SetActive(false);
            canInteract = false;

            ExitTrigger();
        }
    }
}
