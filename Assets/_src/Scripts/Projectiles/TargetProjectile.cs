using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetProjectile : Projectile, ITargetWeapon
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

        Destroy(this.gameObject, 10f);
    }

    public override void Update() // METODO CHAMADO A TODO FRAME
    {
        if (isReady == false) return;

        base.Update();

        transform.position += targetDir * Time.deltaTime * brain.projectileSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("ON TRIGGER ENTER CALLED");

        if (other.gameObject.tag != "Enemy") return;

        // dar dano

        other.gameObject.GetComponent<IDamageable>().TakeDamage(brain.Damage);

        Destroy(this.gameObject);
    }
}
