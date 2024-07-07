using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Player", menuName = "Players/Player", order = 1)]
public class Player : PlayerBase
{
    public int _headArmor;
    public int _body_armor;

    private ArmorItemBase _bodyArmorItem;
    private ArmorItemBase _headArmorItem;

    public ArmorItemBase BodyArmorItem { get { return _bodyArmorItem; } }
    public ArmorItemBase HeadArmorItem {  get { return _headArmorItem; } }

    public event Action OnHeadArmorChanged;
    public event Action OnBodyArmorChanged;

    protected override void Attack()
    {
        throw new System.NotImplementedException();
    }

    public void SetBodyArmor(ArmorItemBase armorItem)
    {
        _bodyArmorItem = armorItem;

        OnBodyArmorChanged?.Invoke();
    }

    public void SetHeadArmor(ArmorItemBase armorItem)
    {
        _headArmorItem = armorItem;

        OnHeadArmorChanged?.Invoke();
    }
}
