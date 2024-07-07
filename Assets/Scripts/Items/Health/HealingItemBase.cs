using UnityEngine;

public abstract class HealingItemBase : ItemBase
{
    public int _hpAdding;

    protected abstract void Healing();
}
