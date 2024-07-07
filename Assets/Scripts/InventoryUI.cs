using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private Inventory _inventory;
    [SerializeField] private List<InventorySlot> _inventorySlots;

    public Inventory Inventory { get { return _inventory; } }

    void Start()
    {
        UpdateInventoryUI();
    }

    public void UpdateInventoryUI()
    {
        for (int i = 0; i < _inventorySlots.Count; i++)
        {
            _inventorySlots[i].index = i; // Устанавливаем индекс ячейки
            if (i < _inventory._items.Count)
            {
                _inventorySlots[i].AddItem(_inventory._items[i]);
            }
            else
            {
                _inventorySlots[i].ClearSlot();
            }
        }
    }
}
