using UnityEngine;

public class Customer : MonoBehaviour
{
    [Header("Dish")]
    [SerializeField] private Dish _dish;
    
    [Header("Atributes")]
    [SerializeField] private float _tip;
    [SerializeField] private float _patience;
    private float _timeWaiting;
    private bool _waiting = false;

    private void Start()
    {
        _timeWaiting = _patience;
    }

    private void Update()
    {
        if (!_waiting)
            return;

        _timeWaiting -= Time.deltaTime;

        if (_timeWaiting < 0)
            PatienceEnded();
    }

    private void Sitting()
    {
        _waiting = true;
    }

    private void PatienceEnded()
    {
        _waiting = false;
    }
}
