using UnityEngine;

public abstract class ItemBase : ScriptableObject
{
    public ItemType _itemType;
    public string _itemName;
    public Sprite _itemImage;
    public float _itemWeight;
    public float _maxCount;
    public int _itemCount;

    public string ItemName { get { return _itemName; } }
    public ItemType _ItemType { get { return _itemType; } }
    public Sprite ItemImage { get { return _itemImage; } }
    public int ItemCount { get { return _itemCount; } set { _itemCount = value; } }
    public float itemWeight { get { return _itemWeight; } }
    public float MaxCount {  get { return _maxCount; } }

    public enum ItemType
    {
        Ammunition,
        Armor,
        Health
    }
}
