using UnityEngine;

public class TableInstantiator : MonoBehaviour
{
    [SerializeField] private GameObject _tablePrefab = null;

    private void Start()
    {
        // Instantiate a new table object from the prefab
        GameObject tableObject = Instantiate(_tablePrefab, transform.position, Quaternion.identity);

        // Set the properties of the Table component on the new object
        Table table = tableObject.GetComponent<Table>();
        if (table != null)
        {
            table.position = _tablePrefab.transform.position;
            table.size = new Vector3(1f, 0.5f, 1f);
            table.isBeingServed = false;
        }
    }
}

