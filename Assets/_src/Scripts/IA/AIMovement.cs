using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIMovement : MonoBehaviour
{
    private NavMeshAgent nav;

    [Header("Player Info")]
    public Transform player;

    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (player == null) return;

        Chase();
    }
    

    void Chase()
    {
        nav.SetDestination(player.position);
    }
}
