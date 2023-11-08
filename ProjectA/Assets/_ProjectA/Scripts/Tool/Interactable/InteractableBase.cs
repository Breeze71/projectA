using System;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public abstract class InteractableBase : MonoBehaviour
{
    private const string Player = "Player";

    [SerializeField] protected Collider2D coll;

    protected bool canInteract;


    private void InputManager_OnInteract_Performed(object sender, EventArgs e)
    {
        Interact();        
    }
    protected abstract void Interact();

    private void OnTriggerEnter2D(Collider2D _other)
    {
        if(_other.gameObject.tag == Player)
        {
            InputManager.Instance.OnInteract_Performed += InputManager_OnInteract_Performed;

            EnterTrigger();
        }
    }

    private void OnTriggerExit2D(Collider2D _other) 
    {
        if(_other.gameObject.tag == Player)
        {
            InputManager.Instance.OnInteract_Performed -= InputManager_OnInteract_Performed;
            
            ExitTrigger();
        }
    }

    protected virtual void EnterTrigger() {}
    protected virtual void ExitTrigger() { }
}
