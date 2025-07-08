using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class EntryPoint : MonoBehaviour
{
    [Inject] private ResourcesAssetLoader _assetLoader;
    [Inject] private ICoroutinePerformer _coroutinePerformer;
    [Inject] private SceneSwitcher _sceneSwitcher;

    private void Awake()
    {
        Debug.Log("EntryPoint initialized");

        _sceneSwitcher.SwitchSceneTo(SceneID.Gameplay);
    }
}
