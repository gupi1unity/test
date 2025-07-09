using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameplaySceneInstaller : MonoInstaller
{
    [SerializeField] private GameObject _playerPrefab;

    public override void InstallBindings()
    {

    }

    private void InstallPlayerBindings(DiContainer subContainer)
    {

    }
}
