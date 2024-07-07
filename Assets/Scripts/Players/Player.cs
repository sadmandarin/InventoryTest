using UnityEngine;

[CreateAssetMenu(fileName = "Player", menuName = "Players/Player", order = 1)]
public class Player : PlayerBase
{
    [SerializeField] private int _headArmor;
    [SerializeField] private int _body_armor;

    protected override void Attack()
    {
        throw new System.NotImplementedException();
    }
}
