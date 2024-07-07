using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetPopUpWindow : MonoBehaviour
{
    [SerializeField] private ItemBase _item;
    [SerializeField] private Image _itemImage;

    [SerializeField] private Text _itemName;
    [SerializeField] private Text _itemWeight;
    [SerializeField] private Text _itemCharacktheristic;

    public ItemBase Item { get { return _item; } }
}
