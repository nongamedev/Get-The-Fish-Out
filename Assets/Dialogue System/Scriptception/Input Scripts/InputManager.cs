using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

// This script acts as a single point for all other scripts to get
// the current input from. It uses Unity's new Input System and
// functions should be mapped to their corresponding controls
// using a PlayerInput component with Unity Events.

[RequireComponent(typeof(PlayerInput))]
public class InputManager : MonoBehaviour
{
    //private Vector2 moveDirection = Vector2.zero;  
    private bool interactPressed = false;
    private bool submitPressed = false;
    private bool attackPressed = false;
    private bool dashPressed = false;
    private bool exitPressed = false;

    private static InputManager _instance;
    public static InputManager Instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            interactPressed = true;
        }
        else if (context.canceled)
        {
            interactPressed = false;
        }
    }

    public void OnSubmit(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            submitPressed = true;
        }
        else if (context.canceled)
        {
            submitPressed = false;
        }
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            attackPressed = true;
        }
        else if (context.canceled)
        {
            attackPressed = false;
        }
    }


    //public void MovePressed(InputAction.CallbackContext context)
    //{
    //    if (context.performed)
    //    {
    //        moveDirection = context.ReadValue<Vector2>();
    //    }
    //    else if (context.canceled)
    //    {
    //        moveDirection = context.ReadValue<Vector2>();
    //    }
    //}
    //public Vector2 GetMoveDirection()
    //{
    //    return moveDirection;
    //}

    // for any of the below 'Get' methods, if we're getting it then we're also using it,
    // which means we should set it to false so that it can't be used again until actually
    // pressed again.



    public void OnDash(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            dashPressed = true;
        }
        else if (context.canceled)
        {
            dashPressed = false;
        }
    }
    public void OnExit(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            exitPressed = true;
        }
        else if (context.canceled)
        {
            exitPressed = false;
        }
    }

    //Get pressed inputs


    public bool GetInteractPressed()
    {
        bool result = interactPressed;
        interactPressed = false;
        return result;
    }

    public bool GetSubmitPressed()
    {
        bool result = submitPressed;
        submitPressed = false;
        return result;
    }
    public bool GetAttackPressed()
    {
        bool result = attackPressed;
        attackPressed = false;
        return result;
    }

    public bool GetDashPressed()
    {
        bool result = dashPressed;
        dashPressed = false;
        return result;
    }
    public bool GetExitPressed()
    {
        bool result = exitPressed;
        exitPressed = false;
        return result;
    }

    public void RegisterSubmitPressed()
    {
        submitPressed = false;
    }

}
