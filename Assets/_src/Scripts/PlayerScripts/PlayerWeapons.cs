using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapons : MonoBehaviour
{
    public List<WeaponScriptable> Weapons;

    public WeaponScriptable[] AllWeapons;

    public LayerMask EnemiesLayer;

    public void AddRandomWeapon()
    {
        Weapons.Add(AllWeapons[Random.Range(0, AllWeapons.Length)]);
    }

    public void UpgradeWeapon(WeaponScriptable weapon)
    {

    }

    public void UseWeapon(WeaponScriptable weapon)
    {

    }

    private void Start()
    {
        InvokeRepeating("UseTargetWeapons", 0f, 1f);
    }

    private void UseTargetWeapons()
    {
        if (Weapons.Count <= 0) return; // se eu não tenho armas, retorna.

        foreach(WeaponScriptable weapon in Weapons)
        {
            if (weapon.type != WeaponType.NeedTarget) continue;

            var nearbyEnemies = Physics.OverlapSphere(transform.position, weapon.Range, EnemiesLayer);

            if (nearbyEnemies.Length <= 0) continue;

            var closestTarget = nearbyEnemies[0];
            var closestDistance = 99999f;

            foreach (Collider enemy in nearbyEnemies)
            {
                var distance = Vector3.Distance(transform.position, enemy.transform.position);

                if ( distance < closestDistance)
                {
                    closestTarget = enemy;
                    closestDistance = distance;
                }
            }

            var projectile = Instantiate(weapon.proj, transform.position, Quaternion.identity);

            projectile.GetComponent<ITargetWeapon>().Init(closestTarget.transform);
             
        }
    }
}
