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
        rb.velocity = InputManager.Instanse.GetPlayerMoveDirection() * moveSpeed;
    }
}
