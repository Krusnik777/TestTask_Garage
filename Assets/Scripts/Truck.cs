using UnityEngine;

public class Truck : Interactable
{
    [SerializeField] private ItemSpot[] m_itemSpots;

    public override void OnInteract(PlayerLook playerLook)
    {
        if (playerLook.PickedItem == null || !isInteractable) return;

        for (int i = 0; i < m_itemSpots.Length; i++)
        {
            if (m_itemSpots[i].IsEmpty)
            {
                m_itemSpots[i].InsertItem(playerLook.PickedItem);
                playerLook.ClearItem();
                break;
            }
        }
    }
}
