using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    [Header("Main Data")]
    [SerializeField] private EnemyScriptable brain;

    [Header("Player Reference")]
    [SerializeField] private Transform playerTransform;

    [Header("Transform Data")]
    [SerializeField] private Transform GFXTransform;

    [Header("Scripts References")]
    private AIStates AIStatesScript;
    private AIMovement AIMovementScript;
    private AICombat AICombatScript;

    [Header("References Check")]
    [SerializeField] private bool referencesOk;


    public void Init(EnemyScriptable pBrain)
    {
        referencesOk = false;

        AIStatesScript = GetComponent<AIStates>();
        AIMovementScript = GetComponent<AIMovement>();
        AICombatScript = GetComponent<AICombat>();

        brain = pBrain;

        AICombatScript.Init(brain);

        InstantiateGraphics();
        FindPlayerReference();

        referencesOk = true;
    }

    private void Update()
    {
        if (referencesOk == false) return;
        if (playerTransform == null) return;

        if (AIStatesScript.States == AIStateType.CHASING)
        {
            ChaseBehaviour();
            return;
        }

        if (AIStatesScript.States == AIStateType.ATTACKING)
        {
            AttackBehaviour();
            return;
        }


    }

    void ChaseBehaviour()
    {
        var sucess = AIMovementScript.Chase(playerTransform);

        if (sucess == false)
            AIStatesScript.ChangeToState(AIStateType.ATTACKING);
    }

    void AttackBehaviour()
    {
        var sucess = AICombatScript.CheckAndAttack(playerTransform);

        if (sucess == false)
            AIStatesScript.ChangeToState(AIStateType.CHASING);
    }

    void InstantiateGraphics()
    {
        Instantiate(brain.GFX, GFXTransform);
    }

    void FindPlayerReference()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player")?.transform;


    }
}
