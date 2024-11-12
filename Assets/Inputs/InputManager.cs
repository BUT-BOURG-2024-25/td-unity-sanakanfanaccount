using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;
using EnhancedTouch = UnityEngine.InputSystem.EnhancedTouch;


public class InputManager : MonoBehaviour
{
    [SerializeField]
    private InputActionReference MovementAction = null;
    [SerializeField]
    private InputActionReference JumpAction = null;
    [SerializeField]
    private InputActionReference ClickAction = null;
    [SerializeField]
    private Joystick JoystickAction= null;

    public static InputManager Instance { get { return _instance; } }
    private static InputManager _instance = null;
    public Vector3 MovementInput { get; private set; }

    public Action<Vector2> FingerDownAction = null;

    public void OnEnable()
    {
        EnhancedTouch.TouchSimulation.Enable();
        EnhancedTouch.EnhancedTouchSupport.Enable();

        EnhancedTouch.Touch.onFingerDown += OnFingerDown;
    }

    public void OnDisable()
    {
        EnhancedTouch.TouchSimulation.Disable();
        EnhancedTouch.EnhancedTouchSupport.Disable();

        EnhancedTouch.Touch.onFingerDown -= OnFingerDown;
    }

    private void OnFingerDown(EnhancedTouch.Finger finger)
    {
        Vector2 screenPosTouch = finger.currentTouch.screenPosition;
        RectTransform joystickRect =  JoystickAction.transform as RectTransform; 
        
        if(joystickRect.offsetMin.x <= screenPosTouch.x && joystickRect.offsetMax.x >= screenPosTouch.x
            && joystickRect.offsetMin.y <= screenPosTouch.y && joystickRect.offsetMax.y >= screenPosTouch.y)
        {
        }
        else
        {
            FingerDownAction.Invoke(screenPosTouch);
        }

        
        //joystickRect.offsetMax
    }

    public void RegisterOnJumpInput(Action<InputAction.CallbackContext> OnJumpAction)
    {
        JumpAction.action.performed += OnJumpAction;

    }

    public void RegisterOnClickInput(Action<InputAction.CallbackContext> OnClickAction, bool register)
    {
        if(register)
        ClickAction.action.performed += OnClickAction;
        else
        ClickAction.action.performed -= OnClickAction;

    }


    public void UnregisterOnJumpInput(Action<InputAction.CallbackContext> OnJumpAction)
    {
        JumpAction.action.performed -= OnJumpAction;
    }

    private void Awake()

    {
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
       Vector2 MoveInput = MovementAction.action.ReadValue<Vector2>();
       if(JoystickAction.Direction.x ==0 && JoystickAction.Direction.y == 0)
        {
            MovementInput = new Vector3(MoveInput.x, 0, MoveInput.y);
        }
        else
        {
            MovementInput = new Vector3(JoystickAction.Direction.x, 0, JoystickAction.Direction.y);
        }


    }
}
