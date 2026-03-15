using System;
using System.Collections;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField] private float _openedAngle;
    [SerializeField] private float _closedAngle;
    [SerializeField] private float _rotationSpeed;

    [SerializeField] private bool _isOpened;

    private Quaternion _openedRotation;
    private Quaternion _closedRotation;
    private Coroutine _coroutine;

    private void Start()
    {
        Vector3 currentEuler = transform.localEulerAngles;

        _isOpened = false;
        _openedRotation = Quaternion.Euler(currentEuler.x, _openedAngle, currentEuler.z);
        _closedRotation = Quaternion.Euler(currentEuler.x, _closedAngle, currentEuler.z);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent(out Rigidbody _))
        {
            if (_isOpened == false)
            {
                if (_coroutine != null)
                {
                    StopCoroutine(_coroutine);
                }

                _coroutine = StartCoroutine(RotationDoorTimer(_openedRotation));
            }
        }
    }

    private IEnumerator RotationDoorTimer(Quaternion targetRotation)
    {
        float time = 0;
        while (time < 1)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * _rotationSpeed);
            yield return null;
        }

        transform.rotation = targetRotation;
    }

}
