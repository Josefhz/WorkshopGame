using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "ScriptableObjects/WeaponData", order = 1)]
public class WeaponScriptable : ScriptableObject
{
    public float Damage;
    public float Range;
    public float AttackSpeed;
    public float CurrentCooldown;
    public float projectileSpeed;
    public WeaponType type;

    public GameObject proj;
}
