using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public WeaponScriptable brain;

    public bool isReady = false;

    public virtual void Awake() { }

    public virtual void Init(Transform target = null) { }

    public virtual void Update() { }
}
