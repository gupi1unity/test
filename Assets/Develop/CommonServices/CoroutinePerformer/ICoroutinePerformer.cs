using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICoroutinePerformer
{
    public Coroutine StartPerform(IEnumerator coroutineFunction);

    public void StopPerform(Coroutine coroutine);
}
