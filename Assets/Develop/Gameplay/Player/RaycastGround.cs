using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastGround
{
    private float _distance;
    private Transform _playerTransform;
    private LayerMask _groundMask;

    public RaycastGround(float distance, Transform playerTransform, LayerMask groundMask)
    {
        _distance = distance;
        _playerTransform = playerTransform;
        _groundMask = groundMask;
    }

    public bool IsGrounded()
    {
        Debug.DrawRay(_playerTransform.position, _playerTransform.up * -1 * _distance, Color.red);
        if (Physics.Raycast(_playerTransform.position, _playerTransform.up * -1, _distance, _groundMask.value))
        {
            Debug.DrawRay(_playerTransform.position, _playerTransform.up * -1 * _distance, Color.green);
            return true;
        }

        return false;
    }
}
