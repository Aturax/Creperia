using UnityEngine;

public class Table : MonoBehaviour
{
    public Vector3 position;
    public Vector3 size;
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

