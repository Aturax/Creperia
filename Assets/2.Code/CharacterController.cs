using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private float _speed = 0f;

    [SerializeField] private float _horizontalRange = 0f;
    public InputController _inputController = null;

  
    private void Awake()
    {
       
        _inputController = GetComponent<InputController>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Move();
    }

    void Move() 
    {
        float inputHorizontal = _inputController.MoveHorizontalInput();

        float inputVertical = _inputController.MoveVerticalInput();

        // Move the player horizontally
        float newPositionX = transform.position.x + (inputHorizontal * _speed * Time.deltaTime);

        // Clamp the horizontal position to the allowed range
        newPositionX = Mathf.Clamp(newPositionX, -_horizontalRange, _horizontalRange);

        // Move the player vertically
        float newPositionZ = transform.position.z + (inputVertical * -_speed * Time.deltaTime);

        transform.position = new Vector3(newPositionX, transform.position.y, newPositionZ);

    }
}
