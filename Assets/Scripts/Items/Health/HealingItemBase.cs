using UnityEngine;

public abstract class HealingItemBase : ItemBase
{
    public int HpAdding;

    protected abstract void Healing();
}
