using UnityEngine.EventSystems;
using UnityEngine;

public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler
{
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private Transform originalParent;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        originalParent = transform.parent; // Save original parent
        canvasGroup.blocksRaycasts = false;
        transform.SetParent(transform.root); // Move to top level of hierarchy
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / transform.root.GetComponent<Canvas>().scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;
        transform.SetParent(originalParent); // Return to original parent if not dropped on a new slot
    }

    public void OnDrop(PointerEventData eventData)
    {
        InventorySlot targetSlot = eventData.pointerCurrentRaycast.gameObject.GetComponent<InventorySlot>();

        if (targetSlot != null)
        {
            InventorySlot originalSlot = transform.parent.GetComponent<InventorySlot>();
            if (originalSlot != null && originalSlot != targetSlot)
            {
                SwapItems(originalSlot, targetSlot);
            }
        }
    }

    private void SwapItems(InventorySlot originalSlot, InventorySlot targetSlot)
    {
        Inventory inventory = FindObjectOfType<InventoryUI>().Inventory;

        // Swap items in inventory
        ItemBase tempItem = inventory._items[originalSlot.index];
        inventory._items[originalSlot.index] = inventory._items[targetSlot.index];
        inventory._items[targetSlot.index] = tempItem;

        // Update the slots
        originalSlot.AddItem(inventory._items[originalSlot.index]);
        targetSlot.AddItem(inventory._items[targetSlot.index]);

        FindObjectOfType<InventoryUI>().UpdateInventoryUI();
    }
}