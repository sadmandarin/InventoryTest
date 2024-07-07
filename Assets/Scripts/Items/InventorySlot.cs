using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    [SerializeField] private Image icon;
    [SerializeField] private Text amountText;
    [SerializeField] private ItemBase item;
    public int index;

    public void AddItem(ItemBase newItem)
    {
        item = newItem;
        icon.sprite = item._itemImage;
        icon.enabled = true;
        if (item._itemCount > 1)
        {
            amountText.text = item._itemCount.ToString();
            amountText.enabled = true;
        }
    }

    public void ClearSlot()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;
        amountText.text = "";
        amountText.enabled = false;
    }
}
