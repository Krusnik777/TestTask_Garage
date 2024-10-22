using UnityEngine;

public class PickupObject : Interactable
{
    [SerializeField] private Item m_item;

    public override void OnInteract(PlayerLook playerLook)
    {
        if (!isInteractable || playerLook.PickedItem != null) return;

        playerLook.SetItem(m_item);

        Destroy(gameObject);
    }
}
