using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetProjectile : Projectile
{
    public Vector3 targetPos;
    public Vector3 targetDir;

    public override void Awake()
    {
        base.Awake();
    }

    public override void Init(Transform pTarget)
    {
        base.Init();

        targetPos = pTarget.position;

        targetDir = (targetPos - transform.position).normalized;

        transform.forward = targetDir;

        isReady = true;
    }

    public override void Update() // METODO CHAMADO A TODO FRAME
    {
        if (isReady == false) return;

        base.Update();

        transform.position += Vector3.forward * Time.deltaTime * brain.projectileSpeed;
    }
}
