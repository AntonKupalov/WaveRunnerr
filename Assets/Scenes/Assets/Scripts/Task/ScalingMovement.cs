using UnityEngine;

public class ScalingMovement : MonoBehaviour
{
    [SerializeField]
    private float _speed = 10;
    [SerializeField] 
    private float _scalingDelta = 3;

    private Vector3 _up;
    private Vector3 _down;

    private float _currentTime;
    private bool _isIncreasing;
    private float _oneWayTime;

    private void Awake()
    {
        _up = new Vector3(transform.localScale.x + _scalingDelta, transform.localScale.y + _scalingDelta, 
            transform.localScale.z + _scalingDelta);
        _down = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);
        _oneWayTime = Vector3.Distance(_up, _down) / _speed;
    }

    private void Update()
    {
        _currentTime += _isIncreasing ? Time.deltaTime : -Time.deltaTime;
        var progress = Mathf.PingPong(_currentTime, _oneWayTime) / _oneWayTime;
        transform.localScale = Vector3.Lerp(_up, _down, progress);
    }
}