using UnityEngine;

public abstract class ArmorItemBase : ItemBase
{
    public int _armor;
    public bool _isEquiped;
    public ArmorType _armorType;

    public enum ArmorType 
    {
        Body,
        Head
    }

    protected abstract void Equip();
}
