using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoamingProjectile : Projectile, ITargetWeapon
{
    public Transform target;

    public ParticleSystem explosion;

    public override void Awake()
    {
        base.Awake();
    }

    public override void Init(Transform pTarget)
    {
        base.Init();

        target = pTarget;

        isReady = true;

        Destroy(this.gameObject, 10f);
    }

    public override void Update() // METODO CHAMADO A TODO FRAME
    {
        if (isReady == false) return;
        if (target == null)
        {
            Destroy(this.gameObject);
            return;
        }

        base.Update();

        transform.position = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime * brain.projectileSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("ON TRIGGER ENTER CALLED");

        if (other.gameObject.tag != "Enemy") return;

        // dar dano

        other.gameObject.GetComponent<IDamageable>().TakeDamage(brain.Damage);

        Destroy(this.gameObject);
    }

    private void OnDestroy()
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
    }
}
