using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using UnityEditor;
using UnityEditor.PackageManager.UI;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.UI;

public class ActionButton : ButtonBase
{
    private ItemBase _itemType;
    private InventoryUI _inventoryUI;
    private SetPopUpWindow _window;

    [SerializeField] private Text _buttonText;
    [SerializeField] private Inventory _inventory;
    [SerializeField] private Player _player;
    [SerializeField] private Sprite _pistolSprite;
    [SerializeField] private Sprite _smgSprite;

    protected override void Start()
    {
        _itemType = GetComponentInParent<SetPopUpWindow>().Item;

        _inventoryUI = FindObjectOfType<InventoryUI>();

        _window = GetComponentInParent<SetPopUpWindow>();

        if (_itemType is HealingItemBase)
        {
            _buttonText.text = "������";
        }

        else if (_itemType is ArmorItemBase)
        {
            _buttonText.text = "�����������";
        }

        else if (_itemType is AmmoBase)
        {
            _buttonText.text = "������";
        }

        base.Start();
    }

    protected override void OnClick()
    {
        if (_itemType is HealingItemBase)
        {
            HealingItemBase healingItem = _itemType as HealingItemBase;

            Heal();

            Debug.Log("�������");
        }

        else if (_itemType is ArmorItemBase)
        {
            ArmorItemBase armorItem  = _itemType as ArmorItemBase;

            Equip(armorItem);

            Debug.Log("�����");
        }

        else if (_itemType is PistolAmmo)
        {
            BuyPistolAmmo();

            _inventoryUI.UpdateInventoryUI();

            Debug.Log("������� ���������");
        }

        else if (_itemType is SMGAmmo)
        {
            BuySMGAmmo();

            _inventoryUI.UpdateInventoryUI();

            Debug.Log("������� ��������");
        }
    }

    private void BuySMGAmmo()
    {
        AmmoBase _smgAmmo = ScriptableObject.CreateInstance<SMGAmmo>();

        _smgAmmo._itemType = ItemBase.ItemType.Ammunition;
        _smgAmmo._itemName = "SMGAmmo";
        _smgAmmo._itemImage = _smgSprite;
        _smgAmmo._itemWeight = 0.03f;
        _smgAmmo._itemCount = 100;
        _smgAmmo._maxCount = 100;
        _smgAmmo._damage = 9;

        string _assetPath = GetUniquePath("Assets/SO/SMGAmmo.asset");

        AssetDatabase.CreateAsset(_smgAmmo, _assetPath);
        AssetDatabase.SaveAssets();

        _inventory.AddItem(_smgAmmo);
        EditorUtility.SetDirty(_inventory);
    }

    void BuyPistolAmmo()
    {
        AmmoBase _pistolAmmo = ScriptableObject.CreateInstance<PistolAmmo>();

        _pistolAmmo._itemType = ItemBase.ItemType.Ammunition;
        _pistolAmmo._itemName = "PistolAmmo";
        _pistolAmmo._itemImage = _pistolSprite;
        _pistolAmmo._itemWeight = 0.01f;
        _pistolAmmo._itemCount = 50;
        _pistolAmmo._maxCount = 50;
        _pistolAmmo._damage = 5;

        string _assetPath = GetUniquePath("Assets/SO/PistolAmmo.asset");

        AssetDatabase.CreateAsset(_pistolAmmo, _assetPath);
        AssetDatabase.SaveAssets();

        _inventory.AddItem(_pistolAmmo);
        EditorUtility.SetDirty(_inventory);

    }

    void Equip(ArmorItemBase armorItem)
    {
        if (armorItem._armorType == ArmorItemBase.ArmorType.Head)
        {
            _player._headArmor = armorItem._armor;

            _player.SetHeadArmor(armorItem);
        }
        else if (armorItem._armorType == ArmorItemBase.ArmorType.Body)
        {
            _player._body_armor = armorItem._armor;

            _player.SetBodyArmor(armorItem);
        }

        Destroy(_window.gameObject);
    }

    //����������� �������
    void Heal()
    {

    }

    private string GetUniquePath(string baseFilePath)
    {
        string path = baseFilePath;
        int counter = 1;

        while (File.Exists(path))
        {
            string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(baseFilePath);
            string extension = Path.GetExtension(baseFilePath);
            string directory = Path.GetDirectoryName(baseFilePath);

            path = Path.Combine(directory, $"{fileNameWithoutExtension} ({counter}){extension}");
            counter++;
        }

        return path;
    }
}
