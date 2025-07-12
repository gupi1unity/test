using Assets.Develop.CommonServices.SceneManagment;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameplayBootstrap : SceneBootstrap
{
    public override IEnumerator Run(IInputSceneArgs inputSceneArgs)
    {
        Debug.Log("GameplayBootstrap");

        yield return null;
    }
}
