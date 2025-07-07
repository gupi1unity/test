using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ProjectInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<ResourcesAssetLoader>().AsSingle();

        Container.Bind<ICoroutinePerformer>().FromMethod(context =>
        {
            ResourcesAssetLoader resourcesAssetLoader = context.Container.Resolve<ResourcesAssetLoader>();
            CoroutinePerformer coroutinePerformerPrefab = resourcesAssetLoader.LoadResource<CoroutinePerformer>("Infrastructure/CoroutinePerformer");
            return Instantiate(coroutinePerformerPrefab);
        }).AsSingle();
    }
}
