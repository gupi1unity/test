using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutinePerformer : MonoBehaviour, ICoroutinePerformer
{
    public void Awake()
    {
        DontDestroyOnLoad(this);
    }

    public Coroutine StartPerform(IEnumerator coroutineFunction) => StartCoroutine(coroutineFunction);

    public void StopPerform(Coroutine coroutine) => StopCoroutine(coroutine);
}
