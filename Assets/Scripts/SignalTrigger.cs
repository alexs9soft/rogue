using System;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SignalTrigger : MonoBehaviour
{
    [SerializeField] private AudioSource _alertAudio;

    [SerializeField] private float _endValue;
    [SerializeField] private float _maxValue;
    [SerializeField] private float _minValue;
    [SerializeField] private float _step;

    private bool _isActive;

    private void Awake()
    {
        _alertAudio = GetComponent<AudioSource>();
    }

    private void Start()
    {
        _alertAudio.volume = _minValue;
        _isActive = false;
        _alertAudio.Stop();
    }

    private void Update()
    {
        if (_alertAudio.isPlaying)
            SetAlertVolume();

        if (_alertAudio.volume == 0f)
            _alertAudio.Stop();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Rogue _))
        {
            _isActive = !_isActive;
            PlayAlert();
        }
    }

    private void SetAlertVolume()
    {
        _alertAudio.volume = Mathf.MoveTowards(_alertAudio.volume, _endValue, _step);
    }

    private void PlayAlert()
    {
        _alertAudio.volume = _isActive ? _minValue : _maxValue;
        _endValue = _isActive ? _maxValue : _minValue;

        _alertAudio.Play();
    }
}
