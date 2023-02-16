using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    [SerializeField] private InputAction _moveInput = null;

    private void OnEnable()
    {
        _moveInput.Enable();
    }

    private void OnDisable()
    {
        _moveInput.Disable();
    }

    public float MoveInput()
    {
        return _moveInput.ReadValue<float>();
    }
}
