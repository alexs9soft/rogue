using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    private float _rotation;
    private float _direction;

    public event Action<float> RotationMove;
    public event Action<float> DirectionMove;

    private void Update()
    {
        _rotation = Input.GetAxis("Horizontal");
        _direction = Input.GetAxis("Vertical");

        if (_rotation != 0f)
            RotationMove?.Invoke(_rotation);

        if (_direction != 0f)
            DirectionMove?.Invoke(_direction);
    }
}
