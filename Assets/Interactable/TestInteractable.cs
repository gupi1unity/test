using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInteractable : MonoBehaviour, IInteractable
{
    public bool IsInteractive { get; }

    public void Interact()
    {
        Debug.Log($"Interacted with {gameObject.name}");
    }

    public void OnView()
    {
        Debug.Log($"Looking at {gameObject.name}");
    }

    public void OnLoseView()
    {
        Debug.Log($"Stop looking at {gameObject.name}");
    }
}
