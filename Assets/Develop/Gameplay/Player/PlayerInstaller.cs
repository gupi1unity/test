using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private CharacterController _characterController;

    [SerializeField] private float _speedX = 500f;
    [SerializeField] private float _speedY = 500f;
    [SerializeField] private Transform _cameraPivot;
    [SerializeField] private Transform _playerTransform;

    [SerializeField] private float _cameraRayDistance = 100f;
    [SerializeField] private float _groundRayDistance = 0.5f;
    [SerializeField] private LayerMask _groundMask;
    [SerializeField] private Camera _camera;

    [SerializeField] private float _bobFrequency = 10f;
    [SerializeField] private float _bobAmplitude = 0.0015f;

    [SerializeField] private float _gravityModifier = 2f;

    public override void InstallBindings()
    {
        Container.Bind<Gravity>().AsSingle().WithArguments(_characterController, gameObject.transform, _gravityModifier);
        Container.Bind<Mover>().AsSingle().WithArguments(_speed, _characterController, transform, Container.Resolve<Gravity>());
        Container.Bind<Rotator>().AsSingle().WithArguments(_speedX, _speedY, _cameraPivot, _playerTransform);
        Container.Bind<RaycastCamera>().AsSingle().WithArguments(_camera, _cameraRayDistance);
        Container.Bind<RaycastGround>().AsSingle().WithArguments(_groundRayDistance, transform, _groundMask);
        Container.Bind<Headbob>().AsSingle().WithArguments(_cameraPivot, _characterController, _bobFrequency, _bobAmplitude, Container.Resolve<RaycastGround>());

        Debug.Log("PlayerInstaller initialized");
    }
}
