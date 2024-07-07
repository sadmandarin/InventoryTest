using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using UnityEditor;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.UI;

public class ActionButton : ButtonBase
{
    private ItemBase _itemType;

    [SerializeField] private Text _buttonText;
    [SerializeField] private Inventory _inventory;

    [SerializeField] private Sprite _pistolSprite;
    [SerializeField] private Sprite _smgSprite;

    protected override void Start()
    {
        _itemType = GetComponentInParent<SetPopUpWindow>().Item;

        if (_itemType is HealingItemBase)
        {
            _buttonText.text = "Лечить";
        }

        else if (_itemType is ArmorItemBase)
        {
            _buttonText.text = "Экипировать";
        }

        else if (_itemType is AmmoBase)
        {
            _buttonText.text = "Купить";
        }

        base.Start();
    }

    protected override void OnClick()
    {
        if (_itemType is HealingItemBase)
        {
            Debug.Log("Лечение");
        }

        else if (_itemType is ArmorItemBase)
        {
            Debug.Log("Армор");
        }

        else if (_itemType is PistolAmmo)
        {
            BuyPistolAmmo();

            Debug.Log("Патроны пистолета");
        }

        else if (_itemType is SMGAmmo)
        {
            BuySMGAmmo();

            Debug.Log("Патроны автомата");
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
