using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class DeleteItemButton : ButtonBase
{
    private SetPopUpWindow _window;

    private InventoryUI _inventoryUI;

    [SerializeField] private Inventory _inventory;

    protected override void Start()
    {
        base.Start();

        _inventoryUI = FindObjectOfType<InventoryUI>();

        _window = GetComponentInParent<SetPopUpWindow>();
    }

    protected override void OnClick()
    {
        DeleteItem();

        Destroy(_window.gameObject);
    }

    void DeleteItem()
    {
        _inventory.DeleteFromInventory(_window.Item);

        DeleteAssetByName(_window.Item.name);

        _inventoryUI.UpdateInventoryUI();
    }

    public void DeleteAssetByName(string fileName)
    {
        // Получаем все файлы в папке Assets
        string[] guids = AssetDatabase.FindAssets(fileName);

        foreach (string guid in guids)
        {
            string path = AssetDatabase.GUIDToAssetPath(guid);
            if (Path.GetFileNameWithoutExtension(path) == fileName)
            {
                Object asset = AssetDatabase.LoadAssetAtPath<Object>(path);
                if (asset is ScriptableObject)
                {
                    bool deleteSuccessful = AssetDatabase.DeleteAsset(path);
                    if (deleteSuccessful)
                    {
                        Debug.Log("ScriptableObject удален: " + path);
                    }
                    else
                    {
                        Debug.LogError("Не удалось удалить ScriptableObject: " + path);
                    }
                    return;
                }
            }
        }

        Debug.LogWarning("Файл не найден: " + fileName);
    }
}

