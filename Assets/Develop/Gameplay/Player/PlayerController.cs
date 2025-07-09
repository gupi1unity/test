using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerController : MonoBehaviour
{
    [Inject] private Mover _mover;
    [Inject] private Rotator _rotator;
    [Inject] private RaycastCamera _raycastCamera;
    [Inject] private RaycastGround _raycastGround;
    [Inject] private Headbob _headbob;
    [Inject] private Gravity _gravity;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
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
