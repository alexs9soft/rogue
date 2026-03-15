using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(Mover), typeof(InputReader))]
public class Mover : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _moveSpeed;

    private InputReader _reader;

    private void Awake()
    {
        _reader = GetComponent<InputReader>();
    }

    private void OnEnable()
    {
        _reader.RotationMove += Rotate;
        _reader.DirectionMove += Move;
    }

    private void OnDisable()
    {
        _reader.RotationMove -= Rotate;
        _reader.DirectionMove -= Move;
    }

    private void Rotate(float rotation)
    {
        transform.Rotate(_rotationSpeed * rotation * Time.deltaTime * Vector3.up);
    }

    private void Move(float direction)
    {
        transform.Translate(_moveSpeed * direction * Time.deltaTime * Vector3.forward);
    }
}
