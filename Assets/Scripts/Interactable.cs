using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    protected bool isInteractable = true;
    public bool IsInteractable => isInteractable;

    public void SetInteractable(bool isInteractable) => this.isInteractable = isInteractable;

    public abstract void OnInteract(PlayerLook playerLook);
}
