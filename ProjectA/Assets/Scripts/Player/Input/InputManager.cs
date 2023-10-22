using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance { get; private set;}

    private PlayerInput playerInput;
    private const string KeyBoard = "Keyboard";
    #region Event
    public event EventHandler OnInteract_Performed;
    public event EventHandler OnStatusUI_Performed;
    #endregion

    #region IsGetKey
    private Vector2 moveInput;
    public int xInput { get; private set;}
    public int yInput { get; private set;}

    private Vector2 dashDirection;
    public Vector2Int dashDirection_Normolize { get; private set;}

    private bool isDashKeyDown;
    private bool isDashKey;

    private bool isInteractKeyDown;
    private bool isSubmitKeyDown;
    #endregion

    [SerializeField] private Camera cam;
    [SerializeField] private Player player;
    [SerializeField] private float inputHoldTime = .2f;

    private Coroutine dashHoldCoroutine;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }

        //playerInput = GetComponent<PlayerInput>();
    }

    public void MoveInput(InputAction.CallbackContext _context)
    {
        moveInput = _context.ReadValue<Vector2>();

        // 0 或 1
        if(Mathf.Abs(moveInput.x) > .5f)
        {
            xInput = (int)(moveInput * Vector2.right).normalized.x;
        }
        else
        {
            xInput = 0;
        }

        if(Mathf.Abs(moveInput.y) > .5f)
        {
            yInput = (int)(moveInput * Vector2.up).normalized.y;
        }
        else
        {
            yInput = 0;
        }
    }
    public void StatusUI_onoff(InputAction.CallbackContext _context)
    {
        if (_context.started)
        {
            OnStatusUI_Performed?.Invoke(this, EventArgs.Empty);
        }
    }

    #region Dash
    public void DashInput(InputAction.CallbackContext _context)
    {
        if(_context.started)
        {
            isDashKeyDown = true;
            isDashKey = true;

            if(dashHoldCoroutine == null)
            {
                dashHoldCoroutine = StartCoroutine(Coroutine_DashHold());
            }
            else
            {
                StopCoroutine(dashHoldCoroutine);
                dashHoldCoroutine = StartCoroutine(Coroutine_DashHold());
            }
        }

        else if(_context.canceled)
        {
            isDashKeyDown = false;
            isDashKey = false;
        }
    }
    private IEnumerator Coroutine_DashHold()
    {
        WaitForSeconds wait = new WaitForSeconds(inputHoldTime);

        yield return wait;
        isDashKeyDown = false;
    }
    public void DashDirectionInput_Normolize(InputAction.CallbackContext _context)
    {
        dashDirection = _context.ReadValue<Vector2>();
        /*
        if(playerInput.currentControlScheme == KeyBoard)
        {
            dashDirection = cam.ScreenToWorldPoint((Vector3)dashDirection) - player.transform.position;
        }
        */
        dashDirection_Normolize = Vector2Int.RoundToInt(dashDirection.normalized);
    }
    #endregion

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
    public bool IsDashKeyDown()
    {
        bool _result = isDashKeyDown;
        isDashKeyDown = false;

        return _result;
    }
    public bool IsDashKey()
    {
        return isDashKey;
    }

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
