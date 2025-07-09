using Assets.Develop.CommonServices.SceneManagment;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class MainProjectInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<ResourcesAssetLoader>().AsSingle().NonLazy();

        Container.Bind<ICoroutinePerformer>().FromMethod(context =>
        {
            ResourcesAssetLoader resourcesAssetLoader = context.Container.Resolve<ResourcesAssetLoader>();
            CoroutinePerformer coroutinePerformerPrefab = resourcesAssetLoader.LoadResource<CoroutinePerformer>("Infrastructure/CoroutinePerformer");
            return Instantiate(coroutinePerformerPrefab);
        }).AsSingle();

        Container.Bind<ILoadingCurtain>().FromMethod(context =>
        {
            ResourcesAssetLoader resourcesAssetLoader = context.Container.Resolve<ResourcesAssetLoader>();
            StandartLoadingCurtain standartLoadingCurtain = resourcesAssetLoader.LoadResource<StandartLoadingCurtain>("Infrastructure/StandartLoadingCurtain");
            return Instantiate(standartLoadingCurtain);
        }).AsSingle();

        Container.Bind<ISceneLoader>().To<DefaultSceneLoader>().AsSingle();

        Container.Bind<SceneSwitcher>().AsSingle();
    }
}
