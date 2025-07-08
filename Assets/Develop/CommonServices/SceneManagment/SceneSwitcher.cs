using Assets.Develop.CommonServices.SceneManagment;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public class SceneSwitcher
{
    private readonly ILoadingCurtain _loadingCurtain;
    private readonly ISceneLoader _sceneLoader;
    private readonly ICoroutinePerformer _coroutinePerformer;

    public SceneSwitcher(ILoadingCurtain loadingCurtain, ISceneLoader sceneLoader, ICoroutinePerformer coroutinePerformer)
    {
        _loadingCurtain = loadingCurtain;
        _sceneLoader = sceneLoader;
        _coroutinePerformer = coroutinePerformer;

        Debug.Log("SceneSwitcher created");
    }

    public void SwitchSceneTo(SceneID sceneID, IInputSceneArgs nextSceneArgs = null) => _coroutinePerformer.StartPerform(ProcessSwitchSceneTo(sceneID, nextSceneArgs));

    private IEnumerator ProcessSwitchSceneTo(SceneID sceneID, IInputSceneArgs nextSceneArgs = null)
    {
        _loadingCurtain.Show();

        yield return _sceneLoader.LoadAsync(SceneID.Empty);
        yield return _sceneLoader.LoadAsync(sceneID);

        SceneBootstrap sceneBootstrap = Object.FindAnyObjectByType<SceneBootstrap>();

        if (sceneBootstrap == null)
            throw new System.Exception(nameof(sceneBootstrap));

        yield return sceneBootstrap.Run(nextSceneArgs);

        _loadingCurtain.Hide();
    }
}
