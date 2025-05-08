using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator
{
    private float _speedX;
    private float _speedY;

    private Transform _cameraPivot;
    private Transform _playerTransform;

    private float _xRotation;
    private float _yRotation;

    public Rotator(float speedX, float speedY, Transform cameraPivot, Transform playerTransform)
    {
        _speedX = speedX;
        _speedY = speedY;
        _cameraPivot = cameraPivot;
        _playerTransform = playerTransform;
    }

    public void CalculateRotationDirection()
    {
        float horizontal = Input.GetAxisRaw("Mouse X") * Time.deltaTime * _speedX;
        float vertical = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * _speedY;

        _xRotation -= vertical;
        _xRotation = Mathf.Clamp(_xRotation, -90, 90);
        _yRotation += horizontal;

        _cameraPivot.transform.localRotation = Quaternion.Euler(_xRotation, _yRotation, 0);
        _playerTransform.transform.rotation *= Quaternion.Euler(0, horizontal, 0);
    }
}
