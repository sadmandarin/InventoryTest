using System.Collections.Generic;
using UnityEditor.PackageManager.UI;
using UnityEngine;

[CreateAssetMenu(fileName = "Inventory", menuName = "MainInventory", order = 1)]
public class Inventory : ScriptableObject
{
    public List<ItemBase> _items;

    [SerializeField] private int _totalPistolRound;
    [SerializeField] private int _totalSMGRound;
    [SerializeField] private int _totalFirstHealthKit;

    private void OnEnable()
    {
        TotalRound();
    }

    private void OnDisable()
    {
        ClearTotalRound();
    }

    public void AddItem(ItemBase item)
    {
        _items.Add(item);
    }

    public void TotalRound()
    {
        foreach (var item in _items)
        {
            if (item is PistolAmmo)
                _totalPistolRound += item._itemCount;

            if (item is SMGAmmo)
            {
                _totalSMGRound += item._itemCount;
            }

            if (item is FirstKit)
                _totalFirstHealthKit += item._itemCount;
        }
    }

    public void DeleteFromInventory(ItemBase item)
    {
        foreach (var _item in _items)
        {
            if (item.name == _item.name)
            {
                _items.Remove(item);
                break;
            }
        }
    }

    void ClearTotalRound()
    {
        _totalFirstHealthKit = 0;
        _totalPistolRound = 0;
        _totalSMGRound = 0;
    }
}
