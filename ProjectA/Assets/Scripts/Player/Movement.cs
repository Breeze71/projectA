using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("Component")]
    [SerializeField] private Rigidbody2D rb;

    [Header("Variale")]
    [SerializeField] private float moveSpeed;

    private void Update() 
    {
        int xInput = InputManager.Instance.xInput;
        int yInput = InputManager.Instance.yInput;
        
        rb.velocity = new Vector2(xInput, yInput) * moveSpeed;
    }
}
