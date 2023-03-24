using UnityEngine;

public class DishCharacter : MonoBehaviour
{
    [SerializeField] private Table _currentTable = null;
    [SerializeField] private Dish _currentDish = null;
    private InputController _inputController = null;

    private void Awake()
    {
        _inputController = GetComponent<InputController>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Table table) && _inputController.ActionInput())
        {
            if (_currentTable == null)
            {
                _currentTable = table; // Set the current table to the Table component
                table.IsBeingServed = true;
                Debug.Log("You got a new order...");
            }
            else if (_currentTable.ID == table.ID)
            {
                Debug.Log("Great! A customer is served");
                _currentTable = null;
                _currentDish = null;
            }
            else
            {
                Debug.Log("Can't serve to this table. Another table is being served.");
            }
        }
        else if (other.gameObject.CompareTag("Catch") && _inputController.ActionInput())
        {
            if (_currentTable!= null)
            {
                if (_currentDish.GetDish().Count == 0 || _currentDish == null)
                {
                    _currentDish = new();
                    _currentDish.CatchCrepe();
                    Debug.Log("Crepe catched!");
                }
                else
                {
                    Debug.Log("You already have a crepe on the dish...");
                }
            }
            else
            {
                Debug.Log("You need an order from a client first...");
            }
        }

    }
}
