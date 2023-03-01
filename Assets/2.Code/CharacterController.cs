using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private float _speed = 0f;

    [SerializeField] private float _horizontalRange = 0f;


    private InputController _inputController = null;
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
        float input = _inputController.MoveInput();

       // transform.position += transform.right * input * _speed * Time.deltaTime;

        // Move the player horizontally
        float newPosition = transform.position.x + (input * _speed * Time.deltaTime);

        // Clamp the horizontal position to the allowed range
        newPosition = Mathf.Clamp(newPosition, -_horizontalRange, _horizontalRange);

        transform.position = new Vector3(newPosition, transform.position.y, transform.position.z);

    }
}
