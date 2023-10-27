using UnityEngine;
using V;
using V.Tool.JuicyFeeling;

public class Movement : MonoBehaviour
{
    [Header("Component")]
    [SerializeField] private Rigidbody2D rb;

    [Header("References")]
    [SerializeField] private MovementSO movementSO;
    [SerializeField] private SquashAndStretch movementSquash;
    private float currentMoveSpeed;

    private void Start() 
    {
        InputManager.Instance.OnSprint_Started += InputManager_OnSprint_Started;
        InputManager.Instance.OnSprint_Canceled += InputManager_OnSprint_Canceled;

        currentMoveSpeed = movementSO.WalkSpeed;
        movementSquash.so = movementSO.walkSquash;
    }

    private void InputManager_OnSprint_Started()
    {
        currentMoveSpeed = movementSO.SprintSpeed;
        movementSquash.so = movementSO.sprintSquash;
        movementSquash.PlaySquashAndStretch();
    }

    private void InputManager_OnSprint_Canceled()
    {
        currentMoveSpeed = movementSO.WalkSpeed;
        movementSquash.so = movementSO.walkSquash;
        movementSquash.PlaySquashAndStretch();
    }

    private void Update() 
    {
        Vector2 _inputDirection = new Vector2(InputManager.Instance.XInput, 
            InputManager.Instance.YInput).normalized;

        rb.velocity = Vector2.Lerp(rb.velocity, 
            _inputDirection * currentMoveSpeed, movementSO.MoveLerp * Time.deltaTime);
    }
}
