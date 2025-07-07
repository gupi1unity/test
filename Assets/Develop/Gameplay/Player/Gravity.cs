using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity
{
    private CharacterController _characterController;
    private Transform _playerPosition;
    private float _gravityModifier;
    private float _offset;

    private Vector3 _gravityVector;

    public Gravity(CharacterController characterController, Transform playerPosition, float gravityModifier)
    {
        _characterController = characterController;
        _playerPosition = playerPosition;
        _gravityModifier = gravityModifier;

        _offset = 0;
    }

    public Vector3 CalculateGravity()
    {
        if (_characterController.isGrounded == true)
        {
            _offset = 0;
            _gravityVector = Vector3.zero;
            return _gravityVector;
        }

        _offset -= _gravityModifier;

        _gravityVector = new Vector3(0, _offset, 0);

        return _gravityVector;
    }
}
