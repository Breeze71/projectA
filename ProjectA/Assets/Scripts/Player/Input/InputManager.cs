using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static InputManager Instanse {get; private set;}

    private PlayerInput playerInput;

    #region Event
    public event EventHandler OnInteract_Performed;
    #endregion

    private void Awake() 
    {
        if(Instanse == null)
        {
            Instanse = this;
        }

        InitalizePlayerInput();
    }

    #region Init & Destory
    private void InitalizePlayerInput()
    {
        playerInput = new PlayerInput();
        playerInput.Player.Enable();

        playerInput.Player.Interact.performed += Interact_Performed;
    }
    private void OnDestroy() 
    {
        playerInput.Player.Interact.performed -= Interact_Performed;

        playerInput.Dispose();    
    }
    #endregion

    /* WASD 移動輸入 */
    public Vector2 GetPlayerMoveDirection()
    {
        return playerInput.Player.Move.ReadValue<Vector2>().normalized;
    }

    /* Iteract Event */
    private void Interact_Performed(InputAction.CallbackContext context)
    {
        OnInteract_Performed?.Invoke(this, EventArgs.Empty);
    }

}
