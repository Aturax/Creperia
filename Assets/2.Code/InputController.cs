using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    [SerializeField] private InputAction _moveHorizontalInput = null;
    [SerializeField] private InputAction _moveVerticalInput = null;
    [SerializeField] private InputAction _actionInput = null;

    private void OnEnable()
    {
        _moveHorizontalInput.Enable();
        _actionInput.Enable();
        _moveVerticalInput.Enable();
    }

    private void OnDisable()
    {
        _moveHorizontalInput.Disable();
        _actionInput.Disable();
        _moveVerticalInput.Disable();
    }

    public float MoveHorizontalInput()
    {
        return _moveHorizontalInput.ReadValue<float>();
    }

    public float MoveVerticalInput() 
    {
        return _moveVerticalInput.ReadValue<float>();
    }

    public bool ActionInput() 
    {
        return _actionInput.ReadValue<float>() > 0;
    }
}
