using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Image icon;
    [SerializeField] private Text amountText;
    [SerializeField] private ItemBase item;
    [SerializeField] private GameObject _popUpWindow;
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

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right && item != null)
        {
            ViewPopUpWindow();
        }
    }

    void ViewPopUpWindow()
    {
        Canvas canvas = FindObjectOfType<Canvas>();

        if (canvas != null)
        {
            GameObject popUp = Instantiate(_popUpWindow, canvas.transform);
            SetPopUpWindow popUpScript = popUp.GetComponent<SetPopUpWindow>();
            popUpScript.SetPopUP(item);
        }
    }
}
