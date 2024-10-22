using UnityEngine;

public class ItemSpot : MonoBehaviour
{
    private Item m_item;

    public bool IsEmpty => m_item == null;

    public void InsertItem(Item item)
    {
        if (m_item != null) return;

        m_item = item;

        var gameObject = Instantiate(m_item.Prefab, transform);
        gameObject.SetInteractable(false);
    }
}
