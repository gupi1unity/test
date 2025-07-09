using Assets.Develop.CommonServices.SceneManagment;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameplayBootstrap : SceneBootstrap
{
    [Inject] private Mover _mover;
    [Inject] private Rotator _rotator;
    [Inject] private Gravity _gravity;
    [Inject] private RaycastCamera _raycastCamera;
    [Inject] private RaycastGround _raycastGround;
    [Inject] private Headbob _headbob;
    [Inject] private PlayerController _playerController;

    public override IEnumerator Run(IInputSceneArgs inputSceneArgs)
    {
        yield return new WaitForSeconds(1f);
    }
}
