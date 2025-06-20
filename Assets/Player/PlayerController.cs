using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Mover _mover;
    private Rotator _rotator;
    private RaycastCamera _raycastCamera;
    private RaycastGround _raycastGround;
    private Headbob _headbob;
    private Gravity _gravity;

    [SerializeField] private float _speed = 5f;
    [SerializeField] private CharacterController _characterController;

    [SerializeField] private float _speedX = 5f;
    [SerializeField] private float _speedY = 5f;
    [SerializeField] private Transform _cameraPivot;
    [SerializeField] private Transform _playerTransform;

    [SerializeField] private float _cameraRayDistance = 100f;
    [SerializeField] private float _groundRayDistance = 100f;
    [SerializeField] private LayerMask _groundMask;
    [SerializeField] private Camera _camera;

    [SerializeField] private float _bobFrequency = 8f;
    [SerializeField] private float _bobAmplitude = 0.05f;

    [SerializeField] private float _gravityModifier;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        _gravity = new Gravity(_characterController, gameObject.transform, _gravityModifier);
        _mover = new Mover(_speed, _characterController, _cameraPivot, _gravity);
        _rotator = new Rotator(_speedX, _speedY, _cameraPivot, _playerTransform);
        _raycastCamera = new RaycastCamera(_camera);
        _raycastGround = new RaycastGround(_groundRayDistance, transform, _groundMask);
        _headbob = new Headbob(_cameraPivot, _characterController, _bobFrequency, _bobAmplitude, _raycastGround);
    }

    public void Update()
    {
        _mover.CalculateMoveDirection();
        _rotator.CalculateRotationDirection();
        _headbob.Update();

        Debug.Log(_raycastGround.IsGrounded());

        if (_raycastCamera.CreateRay<IInteractable>(_cameraRayDistance, out IInteractable findedObject))
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                findedObject.Interact();
            }
        }
    }
}
