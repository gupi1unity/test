using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandartLoadingCurtain : MonoBehaviour, ILoadingCurtain
{
    private void Awake()
    {
        DontDestroyOnLoad(this);

        gameObject.SetActive(false);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }
}
