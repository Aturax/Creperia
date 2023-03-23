using UnityEngine;

public class Table : MonoBehaviour
{
    [SerializeField]public int id = 1;
    [SerializeField] private string pedido = "Crep";
    public bool isBeingServed;
    public void Serve()
    {
        isBeingServed = true;
        Debug.Log("Serving table");
    }

    public void StopServing()
    {
        isBeingServed = false;
        Debug.Log("Stopped serving ");
    }
}

