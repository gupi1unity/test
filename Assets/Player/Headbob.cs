using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Headbob
{
    private Transform _cameraPivot;
    private CharacterController _characterController;
    private RaycastGround _ground;

    private float _timer;
    private float _bobFrequency;
    private float _bobAmplitude;
    private Vector3 _startPosition;

    public Headbob(Transform cameraPivot, CharacterController characterController, float bobFrequency, float bobAmplitude, RaycastGround ground)
    {
        _cameraPivot = cameraPivot;
        _characterController = characterController;
        _bobFrequency = bobFrequency;
        _bobAmplitude = bobAmplitude;
        _ground = ground;

        _startPosition = _cameraPivot.transform.localPosition;
    }

    public void Update()
    {
        if (_characterController.velocity.magnitude > 0.1f && _ground.IsGrounded())
        {
            _timer += Time.deltaTime * _bobFrequency;

            float sin = Mathf.Sin(_timer) * _bobAmplitude;

            Debug.Log(sin);

            Vector3 headbobVector = new Vector3(0, sin, 0);

            _cameraPivot.localPosition = new Vector3(_cameraPivot.localPosition.x, _cameraPivot.localPosition.y + headbobVector.y, _cameraPivot.localPosition.z);
        }
        else
        {
            _timer = 0;
            _cameraPivot.localPosition = Vector3.Lerp(_cameraPivot.localPosition, _startPosition, Time.deltaTime * 5f);
        }
    }
}
