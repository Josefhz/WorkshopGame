using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AICombat : MonoBehaviour
{
    [Header("Main Data")]
    [SerializeField] private EnemyScriptable brain;

    [Header("Attack Info")]
    [SerializeField] private bool canAttack;
    [SerializeField] private float currentAttackCooldown;

    [Header("Player Info")]
    [SerializeField] private Transform player;

    private NavMeshAgent nav;

    private void Start()
    {
        nav.stoppingDistance = brain.AttackRange;
    }

    void CheckAndAttack()
    {
        if (Vector3.Distance(transform.position, player.position) < brain.AttackRange)
        {
            if (canAttack)
            {
                Attack();
            }
            else
            {
                currentAttackCooldown -= Time.deltaTime;

                if (currentAttackCooldown <= 0)
                {
                    canAttack = true;
                    currentAttackCooldown = brain.attackSpeed;
                }

            }
        }
    }

    void Attack()
    {
        canAttack = false;

        player.GetComponent<IDamageable>().TakeDamage(Random.Range(brain.AttackDamage[0], brain.AttackDamage[1]));
    }
}
