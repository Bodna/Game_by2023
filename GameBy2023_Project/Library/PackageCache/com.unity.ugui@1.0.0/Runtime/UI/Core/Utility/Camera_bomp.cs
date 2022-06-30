using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_bomp : MonoBehaviour
{

    [SerializeField] private bool _enable = true;

    [SerializeField, Range(0, 0.1f)] private float _amplitude = 0.015f;
    private float _frequency = 10.0f;
    [SerializeField, Range(0, 30)] private float _frequencyRunning = 12.5f;
    [SerializeField, Range(0, 30)] private float _frequencyWalking = 10.5f;
    //variable to add to frequency when running

    [SerializeField] private Transform _camera = null;
    [SerializeField] private Transform _cameraHolder = null;

    private float _toggleSpeed = 3.0f;
    private Vector3 _startPos;
    private PlayerController _controller;
    private Rigidbody _rbController;



    private void Awake()
    {
        _controller = GetComponent<PlayerController>();
        _rbController = GetComponent<Rigidbody>();
        _startPos = _camera.localPosition;
    }



    void FixedUpdate()
    {
        if (!_enable) return;

        CheckMotion();
        ResetPosition();
        Debug.Log(_frequency);
        //_camera.LookAt(FocusTarget());
    }



    private void PlayMotion(Vector3 motion)
    {
        _camera.localPosition += motion;
    }



    private void CheckMotion()
    {
        float speed = new Vector3(_rbController.velocity.x, 0, _rbController.velocity.z).magnitude;

        if (speed < _toggleSpeed) return;
        if (!_controller.grounded) return;

        PlayMotion(FootStepMotion());
    }



    private Vector3 FootStepMotion()
    {
        if ((Mathf.Abs(_rbController.velocity.x) + Mathf.Abs(_rbController.velocity.z)) > 15)
            _frequency = _frequencyRunning;
        else
            _frequency = _frequencyWalking;

        Vector3 pos = Vector3.zero;
        pos.y += Mathf.Sin(Time.time * _frequency) * _amplitude;
        pos.x += Mathf.Cos(Time.time * _frequency / 2) * _amplitude * 2;
        return pos;
    }



    private void ResetPosition()
    {
        if (_camera.localPosition == _startPos) return;
        _camera.localPosition = Vector3.Lerp(_camera.localPosition, _startPos, 1 * Time.deltaTime);
    }



    /*
    private Vector3 FocusTarget()
    {
        Vector3 pos = new Vector3(transform.position.x, transform.position.y + _cameraHolder.localPosition.y, transform.position.z);
        pos += _cameraHolder.forward * 15.0f;
        return pos;
    }*/
}