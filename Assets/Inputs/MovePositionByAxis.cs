using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;


public class MovePositionByAxis : MonoBehaviour
{
    [SerializeField]
    float speed = 0.05f;

    [SerializeField]
    float jumppower = 300;

    [SerializeField]
    private Rigidbody physicsbody;

    private void Start()
    {
        InputManager.Instance.RegisterOnJumpInput(Jump);
    }
   
    private void OnDestroy()
    {
        InputManager.Instance.UnregisterOnJumpInput(Jump);
    }

    private void Jump(InputAction.CallbackContext callbackContext)
    {
        if(physicsbody.velocity.y ==0)
        physicsbody.AddForce(Vector3.up * 300);
    }

    private void Update()
    {
         Vector3 NewVelocity = InputManager.Instance.MovementInput * speed;
         NewVelocity.y = physicsbody.velocity.y;
         physicsbody.velocity = NewVelocity;
    }
}
