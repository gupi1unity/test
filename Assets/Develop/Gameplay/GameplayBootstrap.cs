using Assets.Develop.CommonServices.SceneManagment;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameplayBootstrap : SceneBootstrap
{
    [Inject] private DiContainer _container;

    public override IEnumerator Run(IInputSceneArgs inputSceneArgs)
    {
        ResourcesAssetLoader resourcesAssetLoader = _container.Resolve<ResourcesAssetLoader>();

        PlayerController playerController = resourcesAssetLoader.LoadResource<PlayerController>("Player");

        yield return new WaitForSeconds(1f);
    }
}
