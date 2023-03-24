using UnityEngine;

public class MoveCharacter : MonoBehaviour
{
    [SerializeField] private float _speed = 0f;
    [SerializeField] private float _horizontalRange = 0f;
    private InputController _inputController = null;

    private bool _isEnabled = true;
    public bool IsEnabled
    {
        get { return _isEnabled; }
        set { _isEnabled = value; }
    }

    private void Awake()
    {
        _inputController = GetComponent<InputController>();
    }

    private void FixedUpdate()
    {
        if (_isEnabled)
            Move();
    }

    private void Move() 
    {
        Vector3 direction = new Vector3(_inputController.MoveHorizontalInput(), 0.0f, -_inputController.MoveVerticalInput()).normalized;
        transform.Translate(direction * _speed * Time.deltaTime);

        Vector3 position = Vector3.zero;
        position.x = Mathf.Clamp(transform.position.x, -_horizontalRange, _horizontalRange);
        position.y = transform.position.y;
        position.z = transform.position.z;

        transform.position = position;

        //float inputHorizontal = _inputController.MoveHorizontalInput();
        //float inputVertical = _inputController.MoveVerticalInput();

        //// Move the player horizontally
        //float newPositionX = transform.position.x + (inputHorizontal * _speed * Time.deltaTime);

        //// Clamp the horizontal position to the allowed range
        //newPositionX = Mathf.Clamp(newPositionX, -_horizontalRange, _horizontalRange);

        //// Move the player vertically
        //float newPositionZ = transform.position.z + (inputVertical * -_speed * Time.deltaTime);

        //transform.position = new Vector3(newPositionX, transform.position.y, newPositionZ);
    }
}
