using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerController : MonoBehaviour
{
    private Gravity _gravity;
    private Mover _mover;
    private Rotator _rotator;
    private RaycastCamera _raycastCamera;
    private RaycastGround _raycastGround;
    private Headbob _headbob;

    private float _speedX;
    private float _speedY;

    private Transform _cameraPivot;
    private Transform _playerTransform;

    private float _xRotation;
    private float _yRotation;

    [Inject]
    public void Initialize(Gravity gravity, Mover mover, Rotator rotator, RaycastCamera raycastCamera, RaycastGround raycastGround, Headbob headbob)
    {
        _gravity = gravity;
        _mover = mover;
        _rotator = rotator;
        _raycastCamera = raycastCamera;
        _raycastGround = raycastGround;
        _headbob = headbob;
    }

    public void Update()
    {
        _mover.CalculateMoveDirection();
        _rotator.CalculateRotationDirection();
        _headbob.Update();

        if (_raycastCamera.CreateRay<IInteractable>(out IInteractable findedObject))
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                findedObject.Interact();
            }
        }
    }

    private void Rotate()
    {
        float horizontal = Input.GetAxisRaw("Mouse X") * Time.deltaTime * _speedX;
        float vertical = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * _speedY;

        _xRotation -= vertical;
        _xRotation = Mathf.Clamp(_xRotation, -90, 90);

        _cameraPivot.transform.localRotation = Quaternion.Euler(_xRotation, 0, 0);
        _playerTransform.transform.rotation *= Quaternion.Euler(0, horizontal, 0);
    }
}
