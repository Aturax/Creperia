using UnityEngine;

public class Table : MonoBehaviour
{
    [SerializeField] private int _id = 1;
    [SerializeField] private Dish _dish = null;
    private bool _isBeingServed;

    public int ID { get { return _id; } }
    public bool IsBeingServed
    {
        get { return _isBeingServed; }
        set { _isBeingServed = value; }
    }
}
