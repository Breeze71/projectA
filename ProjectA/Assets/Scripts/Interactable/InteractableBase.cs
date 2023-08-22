using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public abstract class InteractableBase : MonoBehaviour
{
    private const string Player = "Player";

    [SerializeField] protected CircleCollider2D coll;
    [SerializeField] protected GameObject icon;
    
    protected bool isInteractable = false;

    private void Start() 
    {
        InputManager.Instanse.OnInteract_Performed += InputManager_OnInteract_Performed;
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
        if(_other.gameObject.tag == Player)
        {
            icon.SetActive(true);

            isInteractable = true;
        }
    }
    private void OnTriggerExit2D(Collider2D _other) 
    {
        if(_other.gameObject.tag == Player)
        {
            icon.SetActive(false);

            isInteractable = false;
        }
    }
    #endregion

}
