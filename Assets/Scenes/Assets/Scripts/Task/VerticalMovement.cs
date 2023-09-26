using UnityEngine;

public class VerticalMovement : MonoBehaviour
{
    [SerializeField]
    private float _speed = 10;
    [SerializeField] 
    private float _movementDelta = 3;

    private Vector3 _up;
    private Vector3 _down;

    private float _currentTime;
    private bool _isMovingUp;
    private float _oneWayTime;

    private void Awake()
    {
        _up = new Vector3(transform.position.x , transform.position.y + _movementDelta, transform.position.z);
        _down = new Vector3(transform.position.x, transform.position.y - _movementDelta, transform.position.z);
        _oneWayTime = Vector3.Distance(_up, _down) / _speed;
    }

    private void Update()
    {
        _currentTime += _isMovingUp ? Time.deltaTime : -Time.deltaTime;
        var progress = Mathf.PingPong(_currentTime, _oneWayTime) / _oneWayTime;
        transform.position = Vector3.Lerp(_up, _down, progress);
    }
}