using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInteractable : MonoBehaviour, IInteractable
{
    [SerializeField] private Material material;

    public bool IsInteractive { get; }

    public void Interact()
    {
        if (material.color == Color.red)
        {
            material.color = Color.green;
        }
        else if (material.color == Color.green)
        {
            material.color = Color.red;
        }
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
