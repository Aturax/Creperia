using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private float _speed = 0f;

    private InputController _inputController = null;
    private void Awake()
    {
        _inputController = GetComponent<InputController>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move() 
    {
        float input = _inputController.MoveInput();

        transform.position += transform.forward * input * _speed * Time.deltaTime;
    }
}
