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

    [Inject]
    public void Initialize(Gravity gravity, Mover mover, Rotator rotator, RaycastCamera raycastCamera, RaycastGround raycastGround, Headbob headbob)
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

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
}
