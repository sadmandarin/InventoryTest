using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "Players/Enemy", order = 1)]
public class Enemy : PlayerBase
{
    [SerializeField] private int _attackCount;

    protected override void Attack()
    {
        throw new System.NotImplementedException();
    }
}
