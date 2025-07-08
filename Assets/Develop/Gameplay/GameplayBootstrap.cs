using Assets.Develop.CommonServices.SceneManagment;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayBootstrap : SceneBootstrap
{
    public override IEnumerator Run(IInputSceneArgs inputSceneArgs)
    {
        yield return new WaitForSeconds(1f);

        Debug.Log("GameplayBootstrap initialized");
    }
}
