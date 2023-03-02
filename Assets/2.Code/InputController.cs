using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    [SerializeField] private InputAction _moveInput = null;
    [SerializeField] private InputAction _actionInput = null;

    private void OnEnable()
    {
        _moveInput.Enable();
        _actionInput.Enable();
    }

    private void OnDisable()
    {
        _moveInput.Disable();
        _actionInput.Enable();
    }

    public float MoveInput()
    {
        return _moveInput.ReadValue<float>();
    }

    public float ActionInput() 
    {

        return _actionInput.ReadValue<float>();
    }
}
