
using UnityEngine;

public interface IDamageable
{
    public void TakeDamage(int amount);
}

public interface IEnemy
{

}

public interface ITargetWeapon
{
    public void Init(Transform pTarget);
}

