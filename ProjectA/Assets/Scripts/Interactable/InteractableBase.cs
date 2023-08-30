using System;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public abstract class InteractableBase : MonoBehaviour
{
    [SerializeField] protected CircleCollider2D coll;
    [SerializeField] protected GameObject icon;
    [SerializeField] protected GameObject player;
    protected Player playerScript;

    public virtual void Start() 
    {

        playerScript = player.GetComponent<Player>();
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
        if(_other.gameObject == player)
        {
            if (icon != null)
            {
                icon.SetActive(true);
            }

            InputManager.Instanse.OnInteract_Performed += InputManager_OnInteract_Performed;
        }
    }
    private void OnTriggerExit2D(Collider2D _other) 
    {
        if(_other.gameObject == player)
        {
            if (icon != null)
            {
                icon.SetActive(false);
            }

            InputManager.Instanse.OnInteract_Performed -= InputManager_OnInteract_Performed;
        }
    }
    #endregion

}
