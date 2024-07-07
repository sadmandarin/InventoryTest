using UnityEngine;

public abstract class PlayerBase : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private int _hp;

    protected abstract void Attack();
}
