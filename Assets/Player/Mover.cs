using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover
{
    private CharacterController _characterController;
    private float _speed;
    private Transform _playerTransform;
    private Gravity _gravity;

    public Mover(float speed, CharacterController characterController, Transform cameraPivot, Gravity gravity)
    {
        _speed = speed;
        _characterController = characterController;
        _playerTransform = cameraPivot;
        _gravity = gravity;
    }

    public void CalculateMoveDirection()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 inputVector = new Vector3(horizontal, 0, vertical);

        Vector3 moveDirection = _playerTransform.TransformDirection(Vector3.forward) * inputVector.z + _playerTransform.TransformDirection(Vector3.right) * inputVector.x;
        Vector3 moveDirectionNormalized = new Vector3(moveDirection.x, 0, moveDirection.z).normalized * _speed + _gravity.CalculateGravity();

        _characterController.Move(moveDirectionNormalized * Time.deltaTime);
    }
}
