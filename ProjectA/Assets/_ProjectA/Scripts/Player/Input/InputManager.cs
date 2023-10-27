using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance { get; private set;}

    #region Event
    public event EventHandler OnInteract_Performed;
    public event EventHandler OnStatusUI_Performed;
    public event Action OnSprint_Started;
    public event Action OnSprint_Canceled;
    #endregion

    #region IsGetKey
    private Vector2 moveInput;
    public int XInput { get; private set;}
    public int YInput { get; private set;}

    private bool isInteractKeyDown;
    private bool isSubmitKeyDown;
    #endregion

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    public void MoveInput(InputAction.CallbackContext _context)
    {
        moveInput = _context.ReadValue<Vector2>();

        // 0 或 1
        if(Mathf.Abs(moveInput.x) > .5f)
        {
            XInput = (int)(moveInput * Vector2.right).normalized.x;
        }
        else
        {
            XInput = 0;
        }

        if(Mathf.Abs(moveInput.y) > .5f)
        {
            YInput = (int)(moveInput * Vector2.up).normalized.y;
        }
        else
        {
            YInput = 0;
        }
    }

    public void SprintInput(InputAction.CallbackContext _context)
    {
        if(_context.started)
        {
            OnSprint_Started?.Invoke();
            Debug.Log("Sprint");
        }
        else if(_context.canceled)
        {
            OnSprint_Canceled?.Invoke();
        }
    }

    public void StatusUI_onoff(InputAction.CallbackContext _context)
    {
        if (_context.started)
        {
            OnStatusUI_Performed?.Invoke(this, EventArgs.Empty);
            Debug.Log("StatusUI");
        }
    }

    public void InteractInput(InputAction.CallbackContext _context)
    {
        if (_context.started)
        {
            OnInteract_Performed?.Invoke(this, EventArgs.Empty);
            isInteractKeyDown = true;
        }
        else if(_context.canceled)
        {
            isInteractKeyDown = false;
        }
    }

    public void SubmitInput(InputAction.CallbackContext _context)
    {
        if(_context.started)
        {
            isSubmitKeyDown = true;
        }
        else if(_context.canceled)
        {
            isSubmitKeyDown = false;
        }
    }



    #region GetKeyFuction
    public bool IsInteractKeyDown()
    {
        bool _result = isInteractKeyDown;
        isInteractKeyDown = false;

        return _result;        
    }
    public bool IsSubmitKeyDown()
    {
        bool _result = isSubmitKeyDown;
        isSubmitKeyDown = false;

        return _result; 
    }
    #endregion
}
