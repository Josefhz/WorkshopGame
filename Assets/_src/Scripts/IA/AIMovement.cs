using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIMovement : MonoBehaviour
{
    private NavMeshAgent nav;

    void Awake()
    {
        nav = GetComponent<NavMeshAgent>();
    }

    public void Init(EnemyScriptable brain)
    {
        nav.speed = brain.speed;
    }

    public bool Chase(Transform target)
    {
        if (!target) return false;

        if (Vector3.Distance(transform.position, target.position) > nav.stoppingDistance)
        {
            nav.SetDestination(target.position);
            return true;
        }

        return false;       
    }
}
