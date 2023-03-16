using UnityEngine;

public class ActionController : MonoBehaviour
{
    [SerializeField] private bool _isServing = false;
    [SerializeField] private CharacterController _characterController = null;
    [SerializeField] private Table _currentTable;

    private float _cachedInput = 0f;
    private bool _isAnyTableServed = false;

    private void Awake()
    {
        _characterController._inputController = GetComponent<InputController>();
    }

    private void FixedUpdate()
    {
        ServePlate();
    }

    void ServePlate()
    {
        _cachedInput = _characterController._inputController.ActionInput();
        switch (_cachedInput)
        {
            case 1:
                if (!_isAnyTableServed)
                {
                    _isServing = true;
                    _isAnyTableServed = true;
                    _currentTable.Serve(); // Call the Serve() method on the Table object
                }
                break;
            case -1:
                if (_isServing && _currentTable != null)
                {
                    _isServing = false;
                    _currentTable.StopServing(); // Call the StopServing() method on the Table object
                    _currentTable = null;
                    _isAnyTableServed = false;
                }
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Table table = other.GetComponent<Table>(); // Get the Table component from the collider
        if (table != null && !table.isBeingServed)
        {
            _currentTable = table; // Set the current table to the Table component
            Debug.Log("Punto de servir");
        }
        else if (table != null)
        {
            Debug.Log("Can't serve to this table. Another table is being served.");
        }
    }
}
