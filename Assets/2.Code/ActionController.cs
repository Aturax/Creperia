using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionController : MonoBehaviour
{
    [SerializeField] private bool _isServing = false;
    [SerializeField] private CharacterController _characterController = null;

    private void Awake()
    {
        _characterController._inputController = GetComponent<InputController>();
    }

    private void Update()
    {
        ServePlate();
    }

    void ServePlate()
    {
        float input = _characterController._inputController.ActionInput();
        if (input == 1)
        {
            _isServing = true;
        }
        else if (input == -1)
        {
            _isServing = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject)
        {
            Debug.Log("Punto de servir");
        }
    }
}


