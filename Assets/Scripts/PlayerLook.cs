using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    [SerializeField] private Camera m_camera;
    [SerializeField] private float m_distance = 3f;
    [SerializeField] private LayerMask m_mask;
    [SerializeField] private Transform m_itemHolder;

    private Item item;
    public Item PickedItem => item;

    public void SetItem(Item item)
    {
        this.item = item;

        Instantiate(item.Prefab, m_itemHolder);
    }
    public void ClearItem()
    {
        item = null;

        if (m_itemHolder.childCount > 0)
        {
            var objectInHand = m_itemHolder.GetComponentInChildren<PickupObject>();

            if (objectInHand != null) Destroy(objectInHand.gameObject);
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = new Ray(m_camera.transform.position, m_camera.transform.forward);

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, m_distance, m_mask))
            {
                if (hit.collider.TryGetComponent(out Interactable interactable))
                {
                    interactable.OnInteract(this);
                }
            }
        }
    }
}
