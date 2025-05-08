using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    public bool IsInteractive { get; }

    public void Interact();

    public void OnView();

    public void OnLoseView();
}
