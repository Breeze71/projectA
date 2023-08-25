using System;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public abstract class InteractableBase : MonoBehaviour
{
    [SerializeField] protected CircleCollider2D coll;
    [SerializeField] protected GameObject icon;
    [SerializeField] protected GameObject player;
    protected Player playerScript;
    protected bool isInteractable = false;

    public virtual void Start() 
    {
        InputManager.Instanse.OnInteract_Performed += InputManager_OnInteract_Performed;

        playerScript = player.GetComponent<Player>();
    }
    private void InputManager_OnInteract_Performed(object sender, EventArgs e)
    {
        if(isInteractable)
        {
            Interact();
        }    
    }
    public abstract void Interact();

    /* 玩家是否在範圍內 */
    #region OnTrigger
    private void OnTriggerEnter2D(Collider2D _other)
    {
        if(_other.gameObject == player)
        {
            icon.SetActive(true);

            isInteractable = true;
        }
    }
    private void OnTriggerExit2D(Collider2D _other) 
    {
        if(_other.gameObject == player)
        {
            icon.SetActive(false);

            isInteractable = false;
        }
    }
    #endregion

}
