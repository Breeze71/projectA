using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager Instanse {get; private set;}

    private PlayerInput playerInput;

    private void Awake() 
    {
        Instanse = this;

        InitalizePlayerInput();
    }

    /* WASD 移動輸入 */
    public Vector2 GetPlayerMoveDirection()
    {
        return playerInput.Player.Move.ReadValue<Vector2>().normalized;
    }


    #region Init & Destory
    private void InitalizePlayerInput()
    {
        playerInput = new PlayerInput();
        playerInput.Player.Enable();
    }
    private void OnDestroy() 
    {
        playerInput.Dispose();    
    }
    #endregion
}
