using UnityEngine;

public class RotationMovement : MonoBehaviour
{
    [SerializeField] 
    private float _rotationValue = 50;
    
    private void Update()
    {
        transform.Rotate(Vector3.forward * Time.deltaTime * _rotationValue, Space.World);
    }
}