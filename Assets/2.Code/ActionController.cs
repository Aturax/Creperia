using UnityEngine;

public class ActionController : MonoBehaviour
{
    [SerializeField] private bool _isServing = false;
    [SerializeField] private CharacterController _characterController = null;
    [SerializeField] private Table _currentTable = null;
    [SerializeField] private int _currentTableID = -1; // Initialize to -1 since ID should be a positive integer
    private InputController _inputController = null;

    private void Awake()
    {
        _inputController = GetComponent<InputController>();
    }

    private void Update()
    {
        if (_inputController.ActionInput() > 0f)
        {
            ServePlate();
        }
        else if (_inputController.ActionInput() < 0f)
        {
            StopServing();
        }
    }

    void ServePlate()
    {
        if (_currentTable != null && !_currentTable.isBeingServed)
        {
            _currentTable.Serve();
            _currentTable.isBeingServed = true;
            _currentTableID = _currentTable.id; // set the current table ID
            Debug.Log("Serving table " + _currentTableID);
        }
    }

    void StopServing()
    {
        if (_currentTable != null && _currentTable.isBeingServed)
        {
            _currentTable.StopServing();
            _currentTable.isBeingServed = false;
            Debug.Log("Stopped serving table " + _currentTableID);
            _currentTableID = -1; // reset current table ID
            _currentTable = null;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("He chocado");
        if (other.gameObject.TryGetComponent(out Table table))
        {
            if (_currentTable == null)
            {
                _currentTable = table; // Set the current table to the Table component
                Debug.Log("Punto de servir");
            }
            else
            {
                Debug.Log("Can't serve to this table. Another table is being served.");
            }

        }

    }
}

